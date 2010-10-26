using System;
using System.Collections.Generic;
using Mirror;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace mirlite
{
    public partial class MainForm
    {
        private void updateFilters()
        {
            //thingsOnPlaceBindingSource.EndEdit();
            thingsOnPlaceBindingSource.CancelEdit();    // prevents "phantom rows" bug
            thingsOnRemoveBindingSource.CancelEdit();
            thingsOnPlaceBindingSource.Filter = "thing_RFID = '" + cbThingNames.SelectedValue + "' AND trigger_event = 'onPlace'";
            thingsOnRemoveBindingSource.Filter = "thing_RFID = '" + cbThingNames.SelectedValue + "' AND trigger_event = 'onRemove'";
        }

        private void thingChangedUpdate()
        {
            if ((String)cbThingNames.SelectedValue == "mirDisconnected" || (String)cbThingNames.SelectedValue == "mirConnected")
            {
                cbThingNames.DropDownStyle = ComboBoxStyle.DropDownList;
                dgvThingProgramsOnRemove.Hide();
                gbOnRemove.Hide();
                gbOnPlace.Text = "";
            }
            else
            {
                cbThingNames.DropDownStyle = ComboBoxStyle.DropDown;
                dgvThingProgramsOnRemove.Show();
                gbOnRemove.Show();
                gbOnPlace.Text = "When Object Placed";
            }
            updateImageDeleteObject();
        }

        private void updateImageDeleteObject()
        {
            if ((String)cbThingNames.SelectedValue != "mirDisconnected" &&
                (String)cbThingNames.SelectedValue != "mirConnected" &&
                !placedRFIDs.Contains((String)cbThingNames.SelectedValue))
            {
                imageDeleteObject.Show();
            }
            else
            {
                imageDeleteObject.Hide();
            }
        }

        private void cleanExit()
        {
            Dispose();
            Environment.Exit(1);
        }

        private void updateStatusMarkers()
        {
            if (isMirConnected)
            {
                btnToggleChoreo.Enabled = true;
                if (lightsAndSoundOn)
                {
                    notifyIcon.Icon = global::mirlite.Properties.Resources.mirlite_glow_16;
                    statusImage.Image = global::mirlite.Properties.Resources.mirlite_image_glow;
                }
                else
                {
                    notifyIcon.Icon = global::mirlite.Properties.Resources.mirlite_muted_16;
                    statusImage.Image = global::mirlite.Properties.Resources.mirlite_image_muted;
                }
            }
            else
            {
                notifyIcon.Icon = global::mirlite.Properties.Resources.mirlite_disconnected_16;
                statusImage.Image = global::mirlite.Properties.Resources.mirlite_image_disconnected;
                btnToggleChoreo.Enabled = false;
                lightsAndSoundOn = true;
            }
            updateToggleChoreoMarkers();
        }

        private void updateToggleChoreoMarkers()
        {
            if (isMirConnected && !lightsAndSoundOn)
            {
                btnToggleChoreo.Text = "Turn on lights and sound";
                lblReconnectRequired.Hide();
            }
            else
            {
                if (safeToDisableChoreo)
                {
                    btnToggleChoreo.Text = "Turn off lights and sound";
                    lblReconnectRequired.Hide();
                }
                else
                {
                    btnToggleChoreo.Text = "Turn off lights and sound *";
                    lblReconnectRequired.Show();
                }
            }
        }

        private void updatePlacedThings()
        {
            tlpPlacedThings.Controls.Clear();
            if (placedRFIDs.Count == 0)
            {
                lblPlacedThingsTitle.Text = "No placed objects";

            }
            else
            {
                lblPlacedThingsTitle.Text = "Currently placed objects:";
                foreach (string placedRFID in placedRFIDs)
                {
                    tlpPlacedThings.Controls.Add(createThingLink(placedRFID));
                }
            }
        }

        private LinkToIDLabel createThingLink(string RFID)
        {
            LinkToIDLabel thingLink = new LinkToIDLabel();
            thingLink.Text = dsThingPrograms.things.FindByRFID(RFID).name;
            thingLink.id = RFID;
            thingLink.Click += new EventHandler(thingLink_Click);
            return thingLink;
        }

        void thingLink_Click(object sender, EventArgs e)
        {
            cbThingNames.SelectedValue = ((LinkToIDLabel)sender).id;
        }

        private void addOnPlaceProgram()
        {
            dsThingPrograms.thingsRow curThing = (dsThingPrograms.thingsRow)((DataRowView)thingsBindingSource.Current).Row;
            String on_event = (curThing.name == "mirConnected" || curThing.name == "mirDisconnected") ? "" : "onPlace";
            dsThingPrograms.programs.AddprogramsRow(wtbAddOnPlaceName.Text, wtbAddOnPlacePath.Text, curThing, on_event, true);
            wtbAddOnPlaceName.Text = "";
            wtbAddOnPlacePath.Text = "";
            dsThingPrograms.programs.WriteXml(Globals.programsXmlPath, System.Data.XmlWriteMode.WriteSchema);
        }
        private void addOnRemoveProgram()
        {
            dsThingPrograms.thingsRow curThing = (dsThingPrograms.thingsRow)((DataRowView)thingsBindingSource.Current).Row;
            dsThingPrograms.programs.AddprogramsRow(wtbAddOnRemoveName.Text, wtbAddOnRemovePath.Text, curThing, "onRemove", true);
            wtbAddOnRemoveName.Text = "";
            wtbAddOnRemovePath.Text = "";
            dsThingPrograms.programs.WriteXml(Globals.programsXmlPath, System.Data.XmlWriteMode.WriteSchema);
        }

        private void forceWtbEmpty(WatermarkTextBox wtb)
        {
            wtb.Text = "";
            dgvThingProgramsOnPlace.Focus();
            wtb.forceEmpty();
            wtb.Focus();
        }

        private void showAndFocusWindow()
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void addUnique(List<string> list, string str)
        {
            if (!list.Contains(str))
            {
                list.Add(str);
            }
        }
    }
}
