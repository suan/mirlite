using System;
using System.Collections.Generic;
using Mirror;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mirror.UsbLibrary;
using Orientation = Mirror.Orientation;
using System.Linq;      // try to get rid of this!

namespace mirlite
{
    public partial class MainForm
    {
        private void OnOrientationChanged(object sender, OrientationChangedEventArgs args)
        {
            BeginInvoke(new OnOrientationChangedDelegate(OnOrientationChangedMethod), args.Orientation);
        }

        private void OnOrientationChangedMethod(Orientation orientation)
        {
            if (orientation == Orientation.Down)
            {
                notifyIcon.Icon = global::mirlite.Properties.Resources.mirlite_flipped_16;
                statusImage.Image = global::mirlite.Properties.Resources.mirlite_image_flipped;
                btnToggleChoreo.Enabled = false;
                placedRFIDs.Clear();
                updatePlacedThings();
                updateImageDeleteObject();
            }
            else
            {
                if (!stateOverride) { updateStatusMarkers(); }
            }
        }

        private void OnTagShown(object sender, TagEventArgs args)
        {
            BeginInvoke(new OnTagShownDelegate(OnTagShownMethod), args.HexString);
        }

        private void OnTagHid(object sender, TagEventArgs args)
        {
            BeginInvoke(new OnTagHidDelegate(OnTagHidMethod), args.HexString);
        }

        private void OnTagShownMethod(string RFID)
        {
            updateCurThing(RFID, "onPlace");
        }

        private void OnTagHidMethod(string RFID)
        {
            updateCurThing(RFID, "onRemove");
        }

        private void updateCurThing(string RFID, string eventName = null)
        {
            // update placedRFIDs
            if (eventName == "onRemove" && placedRFIDs.Contains(RFID))
            {
                placedRFIDs.Remove(RFID);
            }
            else if (eventName == "onPlace")
            {
                addUnique(placedRFIDs, RFID);
            }
            else if (RFID == "mirDisconnected")
            {
                placedRFIDs.ForEach((placedRFID) =>
                    {
                        addUnique(prevPlacedRFIDs, (string)placedRFID.Clone());
                    });
                placedRFIDs.Clear();
            }
            else if (RFID == "mirConnected")
            {
                prevPlacedRFIDs.ForEach((placedRFID) =>
                {
                    addUnique(placedRFIDs, (string)placedRFID.Clone());
                });
                prevPlacedRFIDs.Clear();
            }
            updateImageDeleteObject();
            updateSafeToDisableChoreo(RFID);

            dsThingPrograms.thingsRow curThing = this.dsThingPrograms.things.FindByRFID(RFID);
            if (eventName != null && curThing == null)
            {
                curThing = this.dsThingPrograms.things.NewthingsRow();
                curThing.RFID = RFID;
                curThing.name = "Unnamed Object " + curThing.id;
                this.dsThingPrograms.things.Rows.Add(curThing);

                this.dsThingPrograms.things.WriteXml(Globals.thingsXmlPath, System.Data.XmlWriteMode.WriteSchema);
            }
            if (eventName != "onRemove") { cbThingNames.SelectedValue = curThing.RFID; }

            if (eventName != "mirConnected")
            {
                updatePlacedThings();
            }

            if (!dontRunProgs) { runPrograms(curThing, eventName); }
        }

        private void updateSafeToDisableChoreo(string RFID)
        {
            if (safeToDisableChoreo)
            {
                if (!RFIDisSafe(RFID))
                { 
                    safeToDisableChoreo = false;
                    updateToggleChoreoMarkers();
                    updateXmlNode(stateXml, "safeToDisableChoreo", safeToDisableChoreo);
                }
            }
            else
            {
                if (RFID == "mirConnected")
                { 
                    foreach (string placedRFID in placedRFIDs)
                    {
                        if (!RFIDisSafe(placedRFID)) { return; }
                    }
                    safeToDisableChoreo = true;
                    updateToggleChoreoMarkers();
                    updateXmlNode(stateXml, "safeToDisableChoreo", safeToDisableChoreo);
                }
            }
        }

        private bool RFIDisSafe(string RFID)
        {
            return RFID.Length == 16 ? false : true;
        }

        private void runPrograms(dsThingPrograms.thingsRow curThing, string eventName = null)
        {
            foreach (dsThingPrograms.programsRow program in curThing.GetChildRows("FK_things_programs"))
            {
                if (program.enabled && (eventName == null || program.trigger_event == eventName))
                {
                    Process progProcess = new Process();
                    try
                    {
                        progProcess.StartInfo.UseShellExecute = false;
                        // You can start any process, HelloWorld is a do-nothing example.
                        progProcess.StartInfo.FileName = program.filePath;
                        //myProcess.StartInfo.CreateNoWindow = true;
                        progProcess.Start();
                        // This code assumes the process you are starting will terminate itself. 
                        // Given that is is started without a window so you cannot terminate it 
                        // on the desktop, it must terminate itself or you can do it programmatically
                        // from this application using the Kill method.
                    }
                    catch (Exception e)
                    {
                        string errorHeader;
                        if (program.name == null || program.name == "")
                        {
                            errorHeader = "Problem launching script/program at " + program.filePath;
                        }
                        else
                        {
                            errorHeader = "Problem launching " + program.name;
                        }
                        MessageBox.Show(errorHeader + ":\n" + e.Message, Globals.errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public delegate void OnOrientationChangedDelegate(Orientation orientation);
        public delegate void SetDataToTextBox(byte[] data);
        public delegate void OnTagShownDelegate(string text);
        public delegate void OnTagHidDelegate(string text);
        public delegate void OnDeviceRemovedDelegate();

        void OnDataRecieved(object sender, MirrorEventReceivedArgs args)
        {
            //BeginInvoke(new SetDataToTextBox(DelegateMethod), args.Event.Buffer);
        }

        public void DelegateMethod(byte[] data)
        {
            var builder = new StringBuilder();
            foreach (var b in data)
            {
                builder.AppendFormat("{0:X2} ", b);
            }
            //lock (textBox1.Text) textBox1.Lines = textBox1.Lines.Union( new [] { builder.ToString()}).ToArray();
        }

        private void checkMirConnection(bool firstTime = false)
        {
            var mirrors = MirrorFactory.GetMirrors();
            if (mirrors.Count() > 0 && !isMirConnected) // just got connected
            {
                var description = (DeviceDescription<VioletMirror>)mirrors.First();
                if (description != null)
                {
                    if (firstTime) { stateOverride = true; }    // prevent eventual onOrientationChanged from overriding saved choreo state
                    initMirror(description);
                    if (!firstTime) { updateCurThing("mirConnected"); }
                    if (firstTime) { stateOverride = false; }
                }
            }
            else if (firstTime)
            {
                isMirConnected = false;
                updateStatusMarkers();
            }
        }

        private void initMirror(DeviceDescription<VioletMirror> description)
        {
            if (description.IsInUse)
            {
                DialogResult result;
                do
                {
                    mirDetectTimer.Stop();
                    result = MessageBox.Show(this, "Your mir:ror is in use by another program - please stop that program and try again.", Globals.errorTitle, MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel && description.IsInUse)
                    {
                        cleanExit();
                    }
                }
                while (result == DialogResult.Retry && description.IsInUse);
                mirDetectTimer.Start();
            }
            // Disposing old instance to ensure it's free
            if (Mirror != null) Mirror.Dispose();
            Mirror = null;

            Mirror = description.Create();
            Mirror.DataRecieved += OnDataRecieved;
            Mirror.TagShown += OnTagShown;
            Mirror.TagHid += OnTagHid;
            Mirror.OrientationChanged += OnOrientationChanged;
            Mirror.DeviceRemoved += OnDeviceRemoved;
            OnOrientationChangedMethod(Mirror.GetOrientation());
            mirDetectTimer.Stop();
            isMirConnected = true;
            updateStatusMarkers();
        }

        private void OnDeviceRemovedMethod()
        {
            Mirror.Dispose();
            Mirror = null;
            isMirConnected = false;
            updateStatusMarkers();
            mirDetectTimer.Start();
            updateCurThing("mirDisconnected");
        }

        private void OnDeviceRemoved(object sender, DeviceRemovedEventArgs e)
        {
            e.IsHandled = true;     // needs to happen FAST
            BeginInvoke(new OnDeviceRemovedDelegate(OnDeviceRemovedMethod));
        }

        
    }
}
