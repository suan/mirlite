using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mirror;
using Mirror.UsbLibrary;
using Orientation=Mirror.Orientation;
// suan ADD
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace mirlite
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip notifyIconMenu = new ContextMenuStrip();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test();
            setupTrayMenu();
            if (!Directory.Exists(Globals.xmlFolder))
            {
                try
                {
                    Directory.CreateDirectory(Globals.xmlFolder);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(this, "Something went wrong while creating application directory at "+Globals.xmlFolder+"! mir:lite will now exit...",
                        Globals.errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cleanExit();
                }
            }

            if (xmlsExist())
            {
                loadData();
            }
            else
            {
                createXmls();
            }
            if (!File.Exists(Globals.preferencesXmlPath)) { writePreferences(prefsXml); }
            else { loadPreferences(prefsXml); }
            if (!File.Exists(Globals.stateXmlPath)) { writeState(stateXml); }
            else { loadState(stateXml); }

            updateToggleChoreoMarkers();
            curRFID = (string)cbThingNames.SelectedValue;
            thingsOnPlaceBindingSource.Filter = "thing_RFID = '" + cbThingNames.SelectedValue + "'";
            updateFilters();
            thingChangedUpdate();
            updatePlacedThings();
            // SUAN
            //mirDetectTimer.Stop();
            checkMirConnection(true);
            mirDetectTimer.Enabled = true;
        }

        private void btnToggleChoreo_Click(object sender, EventArgs e)
        {
            if (lightsAndSoundOn)
            {
                if (!safeToDisableChoreo)
                {
                    DialogResult result;
                    do
                    {
                        dontRunProgs = true;
                        result = MessageBox.Show(this, "Please remove all placed objects, then reconnect your mir:ror.\n(Associated programs and scripts will not be run)",
                                    Globals.genericTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    } while (result == System.Windows.Forms.DialogResult.OK && !safeToDisableChoreo);
                    dontRunProgs = false;
                    if (!safeToDisableChoreo) { return; }
                }
                if (!Mirror.SetChoreoOff())
                {
                    MessageBox.Show(this, "Something went wrong when trying to turn off lights and sound!\nTry reconnecting your mir:ror and try again.",
                        Globals.errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lightsAndSoundOn = false;
                updateStatusMarkers();
                updateXmlNode(stateXml, "lightsAndSoundOn", lightsAndSoundOn);
            }
            else
            {
                toggleChoreoTimer.Start();
                if (!Mirror.PlayChoreo())
                {
                    MessageBox.Show(this, "Something went wrong when trying to turn on lights and sound!\nTry reconnecting your mir:ror and try again.",
                        Globals.errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lightsAndSoundOn = true;
                updateStatusMarkers();
                btnToggleChoreo.Text = "Please wait...";
                btnToggleChoreo.Enabled = false;
                updateXmlNode(stateXml, "lightsAndSoundOn", lightsAndSoundOn);
            }
        }

        private void getOrientationButton_Click(object sender, EventArgs e)
        {
            var orientation = Mirror.GetOrientation();
            if (orientation == Orientation.Up) MessageBox.Show("Up!");
            else MessageBox.Show("Down!");
        }

        private void cbThingNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            curRFID = (string)cbThingNames.SelectedValue;
            updateFilters();
            thingChangedUpdate();
        }

        private void dgvThingPrograms_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["dgvOnPlaceThing_RFID"].Value = cbThingNames.SelectedValue;
            e.Row.Cells["dgvOnPlaceTriggerEvent"].Value = "onPlace";
        }
        private void dgvThingProgramsOnRemove_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["dgvOnRemoveThing_RFID"].Value = cbThingNames.SelectedValue;
            e.Row.Cells["dgvOnRemoveTriggerEvent"].Value = "onRemove";
        }

        private void cbThingNames_TextUpdate(object sender, EventArgs e)
        {
            int cursorPos = cbThingNames.SelectionStart;    // HACK-ish!
            ((dsThingPrograms.thingsRow)((DataRowView)thingsBindingSource.Current).Row).name = cbThingNames.Text;
            cbThingNames.Select(cursorPos, 0);
            updatePlacedThings();
            this.dsThingPrograms.things.WriteXml(Globals.thingsXmlPath, System.Data.XmlWriteMode.WriteSchema);
        }
        
        private void dgvThingPrograms_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            ((BindingSource)dgv.DataSource).EndEdit();
            this.dsThingPrograms.programs.WriteXml(Globals.programsXmlPath, System.Data.XmlWriteMode.WriteSchema);
        }

        private void btnBrowseOnPlace_Click(object sender, EventArgs e)
        {
            if (selectProgramDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wtbAddOnPlacePath.Text = selectProgramDialog.FileName;
            }
        }
        private void btnBrowseOnRemove_Click(object sender, EventArgs e)
        {
            if (selectProgramDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wtbAddOnRemovePath.Text = selectProgramDialog.FileName;
            }
        }

        private void btnAddOnPlace_Click(object sender, EventArgs e)
        {
            addOnPlaceProgram();
        }
        private void btnAddOnRemove_Click(object sender, EventArgs e)
        {
            addOnRemoveProgram();
        }

        private void dgvThingPrograms_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            dgv.Rows[e.RowIndex].Cells[dgv.Rows[e.RowIndex].Cells.Count - 1].ToolTipText = "Delete";
        }

        private void dgvThingPrograms_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            DataGridView dgv = (DataGridView)sender;
            if (Regex.IsMatch(dgv.Columns[e.ColumnIndex].Name, "delete", RegexOptions.IgnoreCase))
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = global::mirlite.Properties.Resources.x_14x14;
            }
        }

        private void dgvThingPrograms_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            DataGridView dgv = (DataGridView)sender;
            if (Regex.IsMatch(dgv.Columns[e.ColumnIndex].Name, "delete", RegexOptions.IgnoreCase))
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = global::mirlite.Properties.Resources.x_12x12;
            }
        }

        private void dgvThingPrograms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            DataGridView dgv = (DataGridView)sender;
            if (Regex.IsMatch(dgv.Columns[e.ColumnIndex].Name, "delete", RegexOptions.IgnoreCase))
            {
                ((BindingSource)dgv.DataSource).RemoveAt(e.RowIndex);
                this.dsThingPrograms.programs.WriteXml(Globals.programsXmlPath, System.Data.XmlWriteMode.WriteSchema);
            }
            else if (Regex.IsMatch(dgv.Columns[e.ColumnIndex].Name, "enabled", RegexOptions.IgnoreCase))
            {
                dgv.EndEdit();
                //this.dsThingPrograms.programs.WriteXml(Globals.programsXmlPath, System.Data.XmlWriteMode.WriteSchema);    // already done in endEdit event...
            }
        }

        private void mirDetectTimer_Tick(object sender, EventArgs e)
        {
            checkMirConnection();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (minimizePref.Checked == true && FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showAndFocusWindow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkMirConnection();
            isMirConnected = true;
            mirDetectTimer.Enabled = true;
        }

        private void minimizePref_Click(object sender, EventArgs e)
        {
            minimizePref.Checked = minimizePref.Checked ? false : true;
            updateXmlNode(prefsXml, "minimizeToSystemTray", minimizePref.Checked);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            cleanExit();
        }

        private void toggleChoreoTimer_Tick(object sender, EventArgs e)
        {
            toggleChoreoTimer.Stop();
            updateStatusMarkers();
        }

        private void imageDeleteObject_Click(object sender, EventArgs e)
        {
            dsThingPrograms.thingsRow curThing = this.dsThingPrograms.things.FindByRFID(curRFID);
            foreach (dsThingPrograms.programsRow program in curThing.GetChildRows("FK_things_programs"))
            {
                this.dsThingPrograms.programs.Rows.Remove(program);
            }
            this.dsThingPrograms.things.Rows.Remove(curThing);

            this.dsThingPrograms.things.WriteXml(Globals.thingsXmlPath, XmlWriteMode.WriteSchema);
            this.dsThingPrograms.programs.WriteXml(Globals.programsXmlPath, XmlWriteMode.WriteSchema);
        }


        private void imageDeleteObject_MouseEnter(object sender, EventArgs e)
        {
            imageDeleteObject.Image = global::mirlite.Properties.Resources.x_14x14;
        }

        private void imageDeleteObject_MouseLeave(object sender, EventArgs e)
        {
            imageDeleteObject.Image = global::mirlite.Properties.Resources.x_12x12;
        }

        private void wtbAddOnPlacePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // == "enter"
            {
                if (wtbAddOnPlacePath.Text.Length > 0)
                {
                    addOnPlaceProgram();
                    forceWtbEmpty(wtbAddOnPlacePath);
                    e.Handled = true;   // prevent bell noise from playing
                }
            }
        }

        private void wtbAddOnPlaceName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // == "enter"
            {
                if (wtbAddOnPlaceName.Text.Length > 0 && wtbAddOnPlacePath.Text.Length > 0)
                {
                    addOnPlaceProgram();
                    forceWtbEmpty(wtbAddOnPlaceName);
                    e.Handled = true;   // prevent bell noise from playing
                }
            }
        }

        private void wtbAddOnRemoveName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // == "enter"
            {
                if (wtbAddOnRemoveName.Text.Length > 0 && wtbAddOnRemovePath.Text.Length > 0)
                {
                    addOnRemoveProgram();
                    forceWtbEmpty(wtbAddOnRemovePath);
                    e.Handled = true;   // prevent bell noise from playing
                }
            }
        }

        private void wtbAddOnRemovePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // == "enter"
            {
                if (wtbAddOnRemovePath.Text.Length > 0)
                {
                    addOnRemoveProgram();
                    forceWtbEmpty(wtbAddOnRemovePath);
                    e.Handled = true;   // prevent bell noise from playing
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OnDeviceRemovedMethod();
        }

        private void trayExit_Click(object sender, EventArgs e)
        {
            cleanExit();
        }

        private void trayShow_Click(object sender, EventArgs e)
        {
            showAndFocusWindow();
        }

        private void setupTrayMenu()
        {
            ToolStripMenuItem trayExit = new ToolStripMenuItem("Exit", null, new EventHandler(trayExit_Click), "trayExit");
            ToolStripMenuItem trayShow = new ToolStripMenuItem("Show", null, new EventHandler(trayShow_Click), "trayShow");
            notifyIconMenu.Items.Add(trayShow);
            notifyIconMenu.Items.Add(trayExit);
            notifyIcon.ContextMenuStrip = notifyIconMenu;
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/suan/mirlite/issues");
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:yeosuanaik@gmail.com");
        }
    }
}
