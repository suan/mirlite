namespace mirlite
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbThingNames = new System.Windows.Forms.ComboBox();
            this.thingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsThingPrograms = new mirlite.dsThingPrograms();
            this.thingsOnPlaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnToggleChoreo = new System.Windows.Forms.Button();
            this.thingsOnRemoveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbOnRemove = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.wtbAddOnRemoveName = new mirlite.WatermarkTextBox();
            this.btnAddOnRemove = new System.Windows.Forms.Button();
            this.btnBrowseOnRemove = new System.Windows.Forms.Button();
            this.wtbAddOnRemovePath = new mirlite.WatermarkTextBox();
            this.dgvThingProgramsOnRemove = new System.Windows.Forms.DataGridView();
            this.dgvOnRemoveThing_RFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnRemoveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnRemoveFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnRemoveTriggerEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnRemoveEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvOnRemoveDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbOnPlace = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBrowseOnPlace = new System.Windows.Forms.Button();
            this.wtbAddOnPlaceName = new mirlite.WatermarkTextBox();
            this.btnAddOnPlace = new System.Windows.Forms.Button();
            this.wtbAddOnPlacePath = new mirlite.WatermarkTextBox();
            this.dgvThingProgramsOnPlace = new System.Windows.Forms.DataGridView();
            this.dgvOnPlaceThing_RFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnPlaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnPlaceFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnPlaceTriggerEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnPlaceEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvOnPlaceDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbPrograms = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.selectProgramDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageDeleteObject = new System.Windows.Forms.PictureBox();
            this.mirDetectTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusImage = new System.Windows.Forms.PictureBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.minimizePref = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.toggleChoreoTimer = new System.Windows.Forms.Timer(this.components);
            this.tlpPlacedThings = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlacedThingsTitle = new System.Windows.Forms.Label();
            this.lblReconnectRequired = new System.Windows.Forms.Label();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.thingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsThingPrograms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thingsOnPlaceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thingsOnRemoveBindingSource)).BeginInit();
            this.gbOnRemove.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThingProgramsOnRemove)).BeginInit();
            this.gbOnPlace.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThingProgramsOnPlace)).BeginInit();
            this.gbPrograms.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageDeleteObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cbThingNames
            // 
            this.cbThingNames.DataSource = this.thingsBindingSource;
            this.cbThingNames.DisplayMember = "name";
            this.cbThingNames.FormattingEnabled = true;
            this.cbThingNames.Location = new System.Drawing.Point(12, 12);
            this.cbThingNames.Name = "cbThingNames";
            this.cbThingNames.Size = new System.Drawing.Size(232, 21);
            this.cbThingNames.TabIndex = 1;
            this.cbThingNames.ValueMember = "RFID";
            this.cbThingNames.SelectedIndexChanged += new System.EventHandler(this.cbThingNames_SelectedIndexChanged);
            this.cbThingNames.TextUpdate += new System.EventHandler(this.cbThingNames_TextUpdate);
            // 
            // thingsBindingSource
            // 
            this.thingsBindingSource.DataMember = "things";
            this.thingsBindingSource.DataSource = this.dsThingPrograms;
            this.thingsBindingSource.Filter = "";
            // 
            // dsThingPrograms
            // 
            this.dsThingPrograms.DataSetName = "dsThingPrograms";
            this.dsThingPrograms.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // thingsOnPlaceBindingSource
            // 
            this.thingsOnPlaceBindingSource.DataMember = "programs";
            this.thingsOnPlaceBindingSource.DataSource = this.dsThingPrograms;
            this.thingsOnPlaceBindingSource.Filter = "";
            // 
            // btnToggleChoreo
            // 
            this.btnToggleChoreo.Location = new System.Drawing.Point(12, 409);
            this.btnToggleChoreo.Name = "btnToggleChoreo";
            this.btnToggleChoreo.Size = new System.Drawing.Size(258, 23);
            this.btnToggleChoreo.TabIndex = 5;
            this.btnToggleChoreo.Text = "Turn off lights and sound";
            this.btnToggleChoreo.UseVisualStyleBackColor = true;
            this.btnToggleChoreo.Click += new System.EventHandler(this.btnToggleChoreo_Click);
            // 
            // thingsOnRemoveBindingSource
            // 
            this.thingsOnRemoveBindingSource.DataMember = "programs";
            this.thingsOnRemoveBindingSource.DataSource = this.dsThingPrograms;
            this.thingsOnRemoveBindingSource.Filter = "";
            // 
            // gbOnRemove
            // 
            this.gbOnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOnRemove.AutoSize = true;
            this.gbOnRemove.Controls.Add(this.tableLayoutPanel4);
            this.gbOnRemove.Controls.Add(this.dgvThingProgramsOnRemove);
            this.gbOnRemove.Location = new System.Drawing.Point(3, 295);
            this.gbOnRemove.Name = "gbOnRemove";
            this.gbOnRemove.Size = new System.Drawing.Size(627, 287);
            this.gbOnRemove.TabIndex = 28;
            this.gbOnRemove.TabStop = false;
            this.gbOnRemove.Text = "When Object Removed";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.Controls.Add(this.wtbAddOnRemoveName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnAddOnRemove, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnBrowseOnRemove, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.wtbAddOnRemovePath, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 256);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(621, 28);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // wtbAddOnRemoveName
            // 
            this.wtbAddOnRemoveName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wtbAddOnRemoveName.ForeColor = System.Drawing.Color.Empty;
            this.wtbAddOnRemoveName.Location = new System.Drawing.Point(3, 6);
            this.wtbAddOnRemoveName.Name = "wtbAddOnRemoveName";
            this.wtbAddOnRemoveName.Size = new System.Drawing.Size(162, 20);
            this.wtbAddOnRemoveName.TabIndex = 1;
            this.wtbAddOnRemoveName.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.wtbAddOnRemoveName.WatermarkText = "Name (Optional)";
            this.wtbAddOnRemoveName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wtbAddOnRemoveName_KeyPress);
            // 
            // btnAddOnRemove
            // 
            this.btnAddOnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOnRemove.Image")));
            this.btnAddOnRemove.Location = new System.Drawing.Point(592, 3);
            this.btnAddOnRemove.MaximumSize = new System.Drawing.Size(23, 23);
            this.btnAddOnRemove.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnAddOnRemove.Name = "btnAddOnRemove";
            this.btnAddOnRemove.Size = new System.Drawing.Size(23, 23);
            this.btnAddOnRemove.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnAddOnRemove, "Add");
            this.btnAddOnRemove.UseVisualStyleBackColor = true;
            this.btnAddOnRemove.Click += new System.EventHandler(this.btnAddOnRemove_Click);
            // 
            // btnBrowseOnRemove
            // 
            this.btnBrowseOnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseOnRemove.Image")));
            this.btnBrowseOnRemove.Location = new System.Drawing.Point(563, 3);
            this.btnBrowseOnRemove.MaximumSize = new System.Drawing.Size(23, 23);
            this.btnBrowseOnRemove.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnBrowseOnRemove.Name = "btnBrowseOnRemove";
            this.btnBrowseOnRemove.Size = new System.Drawing.Size(23, 23);
            this.btnBrowseOnRemove.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnBrowseOnRemove, "Browse...");
            this.btnBrowseOnRemove.UseVisualStyleBackColor = true;
            this.btnBrowseOnRemove.Click += new System.EventHandler(this.btnBrowseOnRemove_Click);
            // 
            // wtbAddOnRemovePath
            // 
            this.wtbAddOnRemovePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wtbAddOnRemovePath.ForeColor = System.Drawing.Color.Empty;
            this.wtbAddOnRemovePath.Location = new System.Drawing.Point(171, 6);
            this.wtbAddOnRemovePath.Name = "wtbAddOnRemovePath";
            this.wtbAddOnRemovePath.Size = new System.Drawing.Size(386, 20);
            this.wtbAddOnRemovePath.TabIndex = 2;
            this.wtbAddOnRemovePath.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.wtbAddOnRemovePath.WatermarkText = "Path";
            this.wtbAddOnRemovePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wtbAddOnRemovePath_KeyPress);
            // 
            // dgvThingProgramsOnRemove
            // 
            this.dgvThingProgramsOnRemove.AllowUserToAddRows = false;
            this.dgvThingProgramsOnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThingProgramsOnRemove.AutoGenerateColumns = false;
            this.dgvThingProgramsOnRemove.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThingProgramsOnRemove.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThingProgramsOnRemove.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvThingProgramsOnRemove.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThingProgramsOnRemove.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThingProgramsOnRemove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThingProgramsOnRemove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvOnRemoveThing_RFID,
            this.dgvOnRemoveName,
            this.dgvOnRemoveFilePath,
            this.dgvOnRemoveTriggerEvent,
            this.dgvOnRemoveEnabled,
            this.dgvOnRemoveDelete});
            this.dgvThingProgramsOnRemove.DataSource = this.thingsOnRemoveBindingSource;
            this.dgvThingProgramsOnRemove.GridColor = System.Drawing.SystemColors.Control;
            this.dgvThingProgramsOnRemove.Location = new System.Drawing.Point(6, 19);
            this.dgvThingProgramsOnRemove.Name = "dgvThingProgramsOnRemove";
            this.dgvThingProgramsOnRemove.RowHeadersVisible = false;
            this.dgvThingProgramsOnRemove.Size = new System.Drawing.Size(615, 234);
            this.dgvThingProgramsOnRemove.TabIndex = 0;
            this.dgvThingProgramsOnRemove.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellContentClick);
            this.dgvThingProgramsOnRemove.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellEndEdit);
            this.dgvThingProgramsOnRemove.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellMouseEnter);
            this.dgvThingProgramsOnRemove.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellMouseLeave);
            this.dgvThingProgramsOnRemove.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvThingProgramsOnRemove_DefaultValuesNeeded);
            this.dgvThingProgramsOnRemove.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvThingPrograms_RowsAdded);
            // 
            // dgvOnRemoveThing_RFID
            // 
            this.dgvOnRemoveThing_RFID.DataPropertyName = "thing_RFID";
            this.dgvOnRemoveThing_RFID.HeaderText = "thing_RFID";
            this.dgvOnRemoveThing_RFID.Name = "dgvOnRemoveThing_RFID";
            this.dgvOnRemoveThing_RFID.Visible = false;
            // 
            // dgvOnRemoveName
            // 
            this.dgvOnRemoveName.DataPropertyName = "name";
            this.dgvOnRemoveName.HeaderText = "Name";
            this.dgvOnRemoveName.Name = "dgvOnRemoveName";
            // 
            // dgvOnRemoveFilePath
            // 
            this.dgvOnRemoveFilePath.DataPropertyName = "filePath";
            this.dgvOnRemoveFilePath.FillWeight = 250F;
            this.dgvOnRemoveFilePath.HeaderText = "Path to File";
            this.dgvOnRemoveFilePath.Name = "dgvOnRemoveFilePath";
            // 
            // dgvOnRemoveTriggerEvent
            // 
            this.dgvOnRemoveTriggerEvent.DataPropertyName = "trigger_event";
            this.dgvOnRemoveTriggerEvent.HeaderText = "trigger_event";
            this.dgvOnRemoveTriggerEvent.Name = "dgvOnRemoveTriggerEvent";
            this.dgvOnRemoveTriggerEvent.Visible = false;
            // 
            // dgvOnRemoveEnabled
            // 
            this.dgvOnRemoveEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvOnRemoveEnabled.DataPropertyName = "enabled";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.dgvOnRemoveEnabled.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOnRemoveEnabled.HeaderText = "Enabled?";
            this.dgvOnRemoveEnabled.MinimumWidth = 60;
            this.dgvOnRemoveEnabled.Name = "dgvOnRemoveEnabled";
            this.dgvOnRemoveEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnRemoveEnabled.Width = 60;
            // 
            // dgvOnRemoveDelete
            // 
            this.dgvOnRemoveDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.dgvOnRemoveDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOnRemoveDelete.FillWeight = 50.36496F;
            this.dgvOnRemoveDelete.HeaderText = "";
            this.dgvOnRemoveDelete.Image = ((System.Drawing.Image)(resources.GetObject("dgvOnRemoveDelete.Image")));
            this.dgvOnRemoveDelete.MinimumWidth = 20;
            this.dgvOnRemoveDelete.Name = "dgvOnRemoveDelete";
            this.dgvOnRemoveDelete.ReadOnly = true;
            this.dgvOnRemoveDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnRemoveDelete.Width = 20;
            // 
            // gbOnPlace
            // 
            this.gbOnPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOnPlace.AutoSize = true;
            this.gbOnPlace.Controls.Add(this.tableLayoutPanel3);
            this.gbOnPlace.Controls.Add(this.dgvThingProgramsOnPlace);
            this.gbOnPlace.Location = new System.Drawing.Point(3, 3);
            this.gbOnPlace.Name = "gbOnPlace";
            this.gbOnPlace.Size = new System.Drawing.Size(627, 286);
            this.gbOnPlace.TabIndex = 29;
            this.gbOnPlace.TabStop = false;
            this.gbOnPlace.Text = "When Object Placed";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Controls.Add(this.btnBrowseOnPlace, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.wtbAddOnPlaceName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAddOnPlace, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.wtbAddOnPlacePath, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 255);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(621, 28);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // btnBrowseOnPlace
            // 
            this.btnBrowseOnPlace.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseOnPlace.Image")));
            this.btnBrowseOnPlace.Location = new System.Drawing.Point(563, 3);
            this.btnBrowseOnPlace.MaximumSize = new System.Drawing.Size(23, 23);
            this.btnBrowseOnPlace.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnBrowseOnPlace.Name = "btnBrowseOnPlace";
            this.btnBrowseOnPlace.Size = new System.Drawing.Size(23, 23);
            this.btnBrowseOnPlace.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnBrowseOnPlace, "Browse...");
            this.btnBrowseOnPlace.UseVisualStyleBackColor = true;
            this.btnBrowseOnPlace.Click += new System.EventHandler(this.btnBrowseOnPlace_Click);
            // 
            // wtbAddOnPlaceName
            // 
            this.wtbAddOnPlaceName.AcceptsReturn = true;
            this.wtbAddOnPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wtbAddOnPlaceName.ForeColor = System.Drawing.Color.Empty;
            this.wtbAddOnPlaceName.Location = new System.Drawing.Point(3, 6);
            this.wtbAddOnPlaceName.Name = "wtbAddOnPlaceName";
            this.wtbAddOnPlaceName.Size = new System.Drawing.Size(162, 20);
            this.wtbAddOnPlaceName.TabIndex = 1;
            this.wtbAddOnPlaceName.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.wtbAddOnPlaceName.WatermarkText = "Name (Optional)";
            this.wtbAddOnPlaceName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wtbAddOnPlaceName_KeyPress);
            // 
            // btnAddOnPlace
            // 
            this.btnAddOnPlace.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOnPlace.Image")));
            this.btnAddOnPlace.Location = new System.Drawing.Point(592, 3);
            this.btnAddOnPlace.MaximumSize = new System.Drawing.Size(23, 23);
            this.btnAddOnPlace.MinimumSize = new System.Drawing.Size(23, 23);
            this.btnAddOnPlace.Name = "btnAddOnPlace";
            this.btnAddOnPlace.Size = new System.Drawing.Size(23, 23);
            this.btnAddOnPlace.TabIndex = 4;
            this.btnAddOnPlace.Tag = "";
            this.toolTip.SetToolTip(this.btnAddOnPlace, "Add");
            this.btnAddOnPlace.UseVisualStyleBackColor = true;
            this.btnAddOnPlace.Click += new System.EventHandler(this.btnAddOnPlace_Click);
            // 
            // wtbAddOnPlacePath
            // 
            this.wtbAddOnPlacePath.AcceptsReturn = true;
            this.wtbAddOnPlacePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wtbAddOnPlacePath.ForeColor = System.Drawing.Color.Empty;
            this.wtbAddOnPlacePath.Location = new System.Drawing.Point(171, 6);
            this.wtbAddOnPlacePath.Name = "wtbAddOnPlacePath";
            this.wtbAddOnPlacePath.Size = new System.Drawing.Size(386, 20);
            this.wtbAddOnPlacePath.TabIndex = 2;
            this.wtbAddOnPlacePath.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.wtbAddOnPlacePath.WatermarkText = "Path";
            this.wtbAddOnPlacePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wtbAddOnPlacePath_KeyPress);
            // 
            // dgvThingProgramsOnPlace
            // 
            this.dgvThingProgramsOnPlace.AllowUserToAddRows = false;
            this.dgvThingProgramsOnPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThingProgramsOnPlace.AutoGenerateColumns = false;
            this.dgvThingProgramsOnPlace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThingProgramsOnPlace.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThingProgramsOnPlace.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvThingProgramsOnPlace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThingProgramsOnPlace.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThingProgramsOnPlace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThingProgramsOnPlace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvOnPlaceThing_RFID,
            this.dgvOnPlaceName,
            this.dgvOnPlaceFilePath,
            this.dgvOnPlaceTriggerEvent,
            this.dgvOnPlaceEnabled,
            this.dgvOnPlaceDelete});
            this.dgvThingProgramsOnPlace.DataSource = this.thingsOnPlaceBindingSource;
            this.dgvThingProgramsOnPlace.GridColor = System.Drawing.SystemColors.Control;
            this.dgvThingProgramsOnPlace.Location = new System.Drawing.Point(6, 16);
            this.dgvThingProgramsOnPlace.Name = "dgvThingProgramsOnPlace";
            this.dgvThingProgramsOnPlace.RowHeadersVisible = false;
            this.dgvThingProgramsOnPlace.Size = new System.Drawing.Size(615, 239);
            this.dgvThingProgramsOnPlace.TabIndex = 0;
            this.dgvThingProgramsOnPlace.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellContentClick);
            this.dgvThingProgramsOnPlace.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellEndEdit);
            this.dgvThingProgramsOnPlace.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellMouseEnter);
            this.dgvThingProgramsOnPlace.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThingPrograms_CellMouseLeave);
            this.dgvThingProgramsOnPlace.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvThingPrograms_DefaultValuesNeeded);
            this.dgvThingProgramsOnPlace.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvThingPrograms_RowsAdded);
            // 
            // dgvOnPlaceThing_RFID
            // 
            this.dgvOnPlaceThing_RFID.DataPropertyName = "thing_RFID";
            this.dgvOnPlaceThing_RFID.HeaderText = "thing_RFID";
            this.dgvOnPlaceThing_RFID.Name = "dgvOnPlaceThing_RFID";
            this.dgvOnPlaceThing_RFID.Visible = false;
            // 
            // dgvOnPlaceName
            // 
            this.dgvOnPlaceName.DataPropertyName = "name";
            this.dgvOnPlaceName.HeaderText = "Name";
            this.dgvOnPlaceName.Name = "dgvOnPlaceName";
            // 
            // dgvOnPlaceFilePath
            // 
            this.dgvOnPlaceFilePath.DataPropertyName = "filePath";
            this.dgvOnPlaceFilePath.FillWeight = 250F;
            this.dgvOnPlaceFilePath.HeaderText = "Path to File";
            this.dgvOnPlaceFilePath.Name = "dgvOnPlaceFilePath";
            // 
            // dgvOnPlaceTriggerEvent
            // 
            this.dgvOnPlaceTriggerEvent.DataPropertyName = "trigger_event";
            this.dgvOnPlaceTriggerEvent.HeaderText = "trigger_event";
            this.dgvOnPlaceTriggerEvent.Name = "dgvOnPlaceTriggerEvent";
            this.dgvOnPlaceTriggerEvent.Visible = false;
            // 
            // dgvOnPlaceEnabled
            // 
            this.dgvOnPlaceEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvOnPlaceEnabled.DataPropertyName = "enabled";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.NullValue = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.dgvOnPlaceEnabled.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOnPlaceEnabled.FillWeight = 81.21828F;
            this.dgvOnPlaceEnabled.HeaderText = "Enabled?";
            this.dgvOnPlaceEnabled.MinimumWidth = 60;
            this.dgvOnPlaceEnabled.Name = "dgvOnPlaceEnabled";
            this.dgvOnPlaceEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnPlaceEnabled.Width = 60;
            // 
            // dgvOnPlaceDelete
            // 
            this.dgvOnPlaceDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.dgvOnPlaceDelete.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOnPlaceDelete.FillWeight = 53.51811F;
            this.dgvOnPlaceDelete.HeaderText = "";
            this.dgvOnPlaceDelete.Image = ((System.Drawing.Image)(resources.GetObject("dgvOnPlaceDelete.Image")));
            this.dgvOnPlaceDelete.MinimumWidth = 20;
            this.dgvOnPlaceDelete.Name = "dgvOnPlaceDelete";
            this.dgvOnPlaceDelete.ReadOnly = true;
            this.dgvOnPlaceDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnPlaceDelete.Width = 20;
            // 
            // gbPrograms
            // 
            this.gbPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrograms.Controls.Add(this.tableLayoutPanel2);
            this.gbPrograms.Location = new System.Drawing.Point(276, 12);
            this.gbPrograms.Name = "gbPrograms";
            this.gbPrograms.Size = new System.Drawing.Size(639, 604);
            this.gbPrograms.TabIndex = 27;
            this.gbPrograms.TabStop = false;
            this.gbPrograms.Text = "Programs/Scripts";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gbOnRemove, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.gbOnPlace, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(633, 585);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // selectProgramDialog
            // 
            this.selectProgramDialog.FileName = "openFileDialog1";
            this.selectProgramDialog.Filter = "All Files|*.*|Programs|*.exe|Common Scripts|*.com;*.bat;*.cmd;*.vbs;*.vbe;*.js;*." +
                "wsf;*.wsh|Other Scripts|*.pl;*.py;*.rb;*.sh";
            this.selectProgramDialog.Title = "Choose a program or script";
            // 
            // imageDeleteObject
            // 
            this.imageDeleteObject.Image = ((System.Drawing.Image)(resources.GetObject("imageDeleteObject.Image")));
            this.imageDeleteObject.Location = new System.Drawing.Point(250, 13);
            this.imageDeleteObject.MaximumSize = new System.Drawing.Size(20, 20);
            this.imageDeleteObject.MinimumSize = new System.Drawing.Size(20, 20);
            this.imageDeleteObject.Name = "imageDeleteObject";
            this.imageDeleteObject.Size = new System.Drawing.Size(20, 20);
            this.imageDeleteObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageDeleteObject.TabIndex = 36;
            this.imageDeleteObject.TabStop = false;
            this.toolTip.SetToolTip(this.imageDeleteObject, "Delete");
            this.imageDeleteObject.Visible = false;
            this.imageDeleteObject.Click += new System.EventHandler(this.imageDeleteObject_Click);
            this.imageDeleteObject.MouseEnter += new System.EventHandler(this.imageDeleteObject_MouseEnter);
            this.imageDeleteObject.MouseLeave += new System.EventHandler(this.imageDeleteObject_MouseLeave);
            // 
            // mirDetectTimer
            // 
            this.mirDetectTimer.Interval = 1000;
            this.mirDetectTimer.Tick += new System.EventHandler(this.mirDetectTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "mir:lite";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // statusImage
            // 
            this.statusImage.Image = ((System.Drawing.Image)(resources.GetObject("statusImage.Image")));
            this.statusImage.Location = new System.Drawing.Point(69, 260);
            this.statusImage.Name = "statusImage";
            this.statusImage.Size = new System.Drawing.Size(143, 143);
            this.statusImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.statusImage.TabIndex = 31;
            this.statusImage.TabStop = false;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemExit});
            this.menuItem1.Text = "mir:lite";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 0;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.minimizePref});
            this.menuItem2.Text = "Preferences";
            // 
            // minimizePref
            // 
            this.minimizePref.Index = 0;
            this.minimizePref.Text = "Minimize to system tray";
            this.minimizePref.Click += new System.EventHandler(this.minimizePref_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem5});
            this.menuItem4.Text = "Help";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "Report a problem...";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // toggleChoreoTimer
            // 
            this.toggleChoreoTimer.Interval = 1500;
            this.toggleChoreoTimer.Tick += new System.EventHandler(this.toggleChoreoTimer_Tick);
            // 
            // tlpPlacedThings
            // 
            this.tlpPlacedThings.AutoScroll = true;
            this.tlpPlacedThings.ColumnCount = 1;
            this.tlpPlacedThings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlacedThings.Location = new System.Drawing.Point(12, 467);
            this.tlpPlacedThings.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.tlpPlacedThings.Name = "tlpPlacedThings";
            this.tlpPlacedThings.RowCount = 2;
            this.tlpPlacedThings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlacedThings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlacedThings.Size = new System.Drawing.Size(258, 149);
            this.tlpPlacedThings.TabIndex = 35;
            // 
            // lblPlacedThingsTitle
            // 
            this.lblPlacedThingsTitle.AutoSize = true;
            this.lblPlacedThingsTitle.Location = new System.Drawing.Point(12, 448);
            this.lblPlacedThingsTitle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPlacedThingsTitle.Name = "lblPlacedThingsTitle";
            this.lblPlacedThingsTitle.Size = new System.Drawing.Size(123, 13);
            this.lblPlacedThingsTitle.TabIndex = 37;
            this.lblPlacedThingsTitle.Text = "Currently placed objects:";
            // 
            // lblReconnectRequired
            // 
            this.lblReconnectRequired.AutoSize = true;
            this.lblReconnectRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReconnectRequired.Location = new System.Drawing.Point(179, 435);
            this.lblReconnectRequired.Name = "lblReconnectRequired";
            this.lblReconnectRequired.Size = new System.Drawing.Size(91, 12);
            this.lblReconnectRequired.TabIndex = 39;
            this.lblReconnectRequired.Text = "* Reconnect required";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "Give feedback/Contact author...";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 628);
            this.Controls.Add(this.lblReconnectRequired);
            this.Controls.Add(this.lblPlacedThingsTitle);
            this.Controls.Add(this.imageDeleteObject);
            this.Controls.Add(this.tlpPlacedThings);
            this.Controls.Add(this.statusImage);
            this.Controls.Add(this.gbPrograms);
            this.Controls.Add(this.btnToggleChoreo);
            this.Controls.Add(this.cbThingNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "mir:lite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.thingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsThingPrograms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thingsOnPlaceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thingsOnRemoveBindingSource)).EndInit();
            this.gbOnRemove.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThingProgramsOnRemove)).EndInit();
            this.gbOnPlace.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThingProgramsOnPlace)).EndInit();
            this.gbPrograms.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageDeleteObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbThingNames;
        private System.Windows.Forms.Button btnToggleChoreo;
        private mirlite.dsThingPrograms dsThingPrograms;
        private System.Windows.Forms.BindingSource thingsOnPlaceBindingSource;
        private System.Windows.Forms.BindingSource thingsOnRemoveBindingSource;
        private System.Windows.Forms.BindingSource thingsBindingSource;
        private System.Windows.Forms.GroupBox gbOnRemove;
        private System.Windows.Forms.DataGridView dgvThingProgramsOnRemove;
        private System.Windows.Forms.GroupBox gbOnPlace;
        private System.Windows.Forms.DataGridView dgvThingProgramsOnPlace;
        private System.Windows.Forms.GroupBox gbPrograms;
        private System.Windows.Forms.Button btnAddOnRemove;
        private System.Windows.Forms.Button btnAddOnPlace;
        private System.Windows.Forms.Button btnBrowseOnPlace;
        private System.Windows.Forms.Button btnBrowseOnRemove;
        private WatermarkTextBox wtbAddOnRemovePath;
        private WatermarkTextBox wtbAddOnRemoveName;
        private WatermarkTextBox wtbAddOnPlacePath;
        private WatermarkTextBox wtbAddOnPlaceName;
        private System.Windows.Forms.OpenFileDialog selectProgramDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer mirDetectTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox statusImage;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem minimizePref;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.Timer toggleChoreoTimer;
        private System.Windows.Forms.TableLayoutPanel tlpPlacedThings;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnPlaceThing_RFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnPlaceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnPlaceFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnPlaceTriggerEvent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvOnPlaceEnabled;
        private System.Windows.Forms.DataGridViewImageColumn dgvOnPlaceDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnRemoveThing_RFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnRemoveName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnRemoveFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnRemoveTriggerEvent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvOnRemoveEnabled;
        private System.Windows.Forms.DataGridViewImageColumn dgvOnRemoveDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox imageDeleteObject;
        private System.Windows.Forms.Label lblPlacedThingsTitle;
        private System.Windows.Forms.Label lblReconnectRequired;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem5;
    }
}

