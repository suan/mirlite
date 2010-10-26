namespace UsbApp
{
    partial class Sniffer
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
            this.lb_recieved = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.lb_vendor = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lb_product = new System.Windows.Forms.Label();
            this.lb_senddata = new System.Windows.Forms.Label();
            this.lb_messages = new System.Windows.Forms.Label();
            this.tb_vendor = new System.Windows.Forms.TextBox();
            this.tb_product = new System.Windows.Forms.TextBox();
            this.gb_filter = new System.Windows.Forms.GroupBox();
            this.lb_message = new System.Windows.Forms.ListBox();
            this.gb_details = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventByte2 = new System.Windows.Forms.TextBox();
            this.eventByte1 = new System.Windows.Forms.TextBox();
            this.lb_read = new System.Windows.Forms.ListBox();
            this.usb = new UsbLibrary.UsbHidPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.messageIdByte1 = new System.Windows.Forms.TextBox();
            this.messageIdByte2 = new System.Windows.Forms.TextBox();
            this.lenByte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataPayload = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_filter.SuspendLayout();
            this.gb_details.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_recieved
            // 
            this.lb_recieved.AutoSize = true;
            this.lb_recieved.Location = new System.Drawing.Point(229, 16);
            this.lb_recieved.Name = "lb_recieved";
            this.lb_recieved.Size = new System.Drawing.Size(82, 13);
            this.lb_recieved.TabIndex = 4;
            this.lb_recieved.Text = "Recieved Data:";
            // 
            // btn_send
            // 
            this.btn_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send.Location = new System.Drawing.Point(685, 319);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(48, 23);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lb_vendor
            // 
            this.lb_vendor.AutoSize = true;
            this.lb_vendor.Location = new System.Drawing.Point(9, 22);
            this.lb_vendor.Name = "lb_vendor";
            this.lb_vendor.Size = new System.Drawing.Size(95, 13);
            this.lb_vendor.TabIndex = 5;
            this.lb_vendor.Text = "Device Vendor ID:";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(322, 43);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lb_product
            // 
            this.lb_product.AutoSize = true;
            this.lb_product.Location = new System.Drawing.Point(9, 48);
            this.lb_product.Name = "lb_product";
            this.lb_product.Size = new System.Drawing.Size(98, 13);
            this.lb_product.TabIndex = 6;
            this.lb_product.Text = "Device Product ID:";
            // 
            // lb_senddata
            // 
            this.lb_senddata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_senddata.AutoSize = true;
            this.lb_senddata.Location = new System.Drawing.Point(264, 305);
            this.lb_senddata.Name = "lb_senddata";
            this.lb_senddata.Size = new System.Drawing.Size(52, 13);
            this.lb_senddata.TabIndex = 5;
            this.lb_senddata.Text = "Event ID:";
            // 
            // lb_messages
            // 
            this.lb_messages.AutoSize = true;
            this.lb_messages.Location = new System.Drawing.Point(8, 16);
            this.lb_messages.Name = "lb_messages";
            this.lb_messages.Size = new System.Drawing.Size(80, 13);
            this.lb_messages.TabIndex = 7;
            this.lb_messages.Text = "Usb Messages:";
            // 
            // tb_vendor
            // 
            this.tb_vendor.Location = new System.Drawing.Point(114, 19);
            this.tb_vendor.Name = "tb_vendor";
            this.tb_vendor.Size = new System.Drawing.Size(189, 20);
            this.tb_vendor.TabIndex = 1;
            this.tb_vendor.Text = "1DA8";
            // 
            // tb_product
            // 
            this.tb_product.Location = new System.Drawing.Point(114, 45);
            this.tb_product.Name = "tb_product";
            this.tb_product.Size = new System.Drawing.Size(189, 20);
            this.tb_product.TabIndex = 2;
            this.tb_product.Text = "1301";
            // 
            // gb_filter
            // 
            this.gb_filter.Controls.Add(this.btn_ok);
            this.gb_filter.Controls.Add(this.lb_product);
            this.gb_filter.Controls.Add(this.lb_vendor);
            this.gb_filter.Controls.Add(this.tb_vendor);
            this.gb_filter.Controls.Add(this.tb_product);
            this.gb_filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_filter.ForeColor = System.Drawing.Color.White;
            this.gb_filter.Location = new System.Drawing.Point(0, 0);
            this.gb_filter.Name = "gb_filter";
            this.gb_filter.Size = new System.Drawing.Size(769, 80);
            this.gb_filter.TabIndex = 5;
            this.gb_filter.TabStop = false;
            this.gb_filter.Text = "Filter for Device:";
            // 
            // lb_message
            // 
            this.lb_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_message.FormattingEnabled = true;
            this.lb_message.Location = new System.Drawing.Point(11, 32);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(212, 329);
            this.lb_message.TabIndex = 6;
            // 
            // gb_details
            // 
            this.gb_details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_details.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_details.Controls.Add(this.button1);
            this.gb_details.Controls.Add(this.label4);
            this.gb_details.Controls.Add(this.dataPayload);
            this.gb_details.Controls.Add(this.label3);
            this.gb_details.Controls.Add(this.lenByte);
            this.gb_details.Controls.Add(this.messageIdByte2);
            this.gb_details.Controls.Add(this.messageIdByte1);
            this.gb_details.Controls.Add(this.label2);
            this.gb_details.Controls.Add(this.label1);
            this.gb_details.Controls.Add(this.eventByte2);
            this.gb_details.Controls.Add(this.eventByte1);
            this.gb_details.Controls.Add(this.lb_read);
            this.gb_details.Controls.Add(this.lb_messages);
            this.gb_details.Controls.Add(this.lb_message);
            this.gb_details.Controls.Add(this.lb_senddata);
            this.gb_details.Controls.Add(this.lb_recieved);
            this.gb_details.Controls.Add(this.btn_send);
            this.gb_details.ForeColor = System.Drawing.Color.White;
            this.gb_details.Location = new System.Drawing.Point(12, 86);
            this.gb_details.Name = "gb_details";
            this.gb_details.Size = new System.Drawing.Size(745, 388);
            this.gb_details.TabIndex = 6;
            this.gb_details.TabStop = false;
            this.gb_details.Text = "Device Details:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "0x00";
            // 
            // eventByte2
            // 
            this.eventByte2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eventByte2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventByte2.Location = new System.Drawing.Point(297, 321);
            this.eventByte2.MaxLength = 2;
            this.eventByte2.Name = "eventByte2";
            this.eventByte2.Size = new System.Drawing.Size(24, 20);
            this.eventByte2.TabIndex = 10;
            this.eventByte2.Text = "00";
            // 
            // eventByte1
            // 
            this.eventByte1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eventByte1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventByte1.Location = new System.Drawing.Point(267, 321);
            this.eventByte1.MaxLength = 2;
            this.eventByte1.Name = "eventByte1";
            this.eventByte1.Size = new System.Drawing.Size(24, 20);
            this.eventByte1.TabIndex = 9;
            this.eventByte1.Text = "00";
            // 
            // lb_read
            // 
            this.lb_read.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_read.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_read.FormattingEnabled = true;
            this.lb_read.ItemHeight = 14;
            this.lb_read.Location = new System.Drawing.Point(232, 32);
            this.lb_read.Name = "lb_read";
            this.lb_read.Size = new System.Drawing.Size(501, 270);
            this.lb_read.TabIndex = 8;
            // 
            // usb
            // 
            this.usb.ProductId = 81;
            this.usb.VendorId = 1105;
            this.usb.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usb_OnSpecifiedDeviceRemoved);
            this.usb.OnDeviceArrived += new System.EventHandler(this.usb_OnDeviceArrived);
            this.usb.OnDeviceRemoved += new System.EventHandler(this.usb_OnDeviceRemoved);
            this.usb.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.usb_OnDataRecieved);
            this.usb.OnSpecifiedDeviceArrived += new System.EventHandler(this.usb_OnSpecifiedDeviceArrived);
            this.usb.OnDataSend += new System.EventHandler(this.usb_OnDataSend);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Message ID:";
            // 
            // messageIdByte1
            // 
            this.messageIdByte1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.messageIdByte1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageIdByte1.Location = new System.Drawing.Point(331, 321);
            this.messageIdByte1.MaxLength = 2;
            this.messageIdByte1.Name = "messageIdByte1";
            this.messageIdByte1.Size = new System.Drawing.Size(24, 20);
            this.messageIdByte1.TabIndex = 13;
            this.messageIdByte1.Text = "00";
            // 
            // messageIdByte2
            // 
            this.messageIdByte2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.messageIdByte2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageIdByte2.Location = new System.Drawing.Point(361, 321);
            this.messageIdByte2.MaxLength = 2;
            this.messageIdByte2.Name = "messageIdByte2";
            this.messageIdByte2.Size = new System.Drawing.Size(24, 20);
            this.messageIdByte2.TabIndex = 14;
            this.messageIdByte2.Text = "00";
            // 
            // lenByte
            // 
            this.lenByte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lenByte.Enabled = false;
            this.lenByte.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lenByte.Location = new System.Drawing.Point(396, 321);
            this.lenByte.MaxLength = 2;
            this.lenByte.Name = "lenByte";
            this.lenByte.Size = new System.Drawing.Size(24, 20);
            this.lenByte.TabIndex = 15;
            this.lenByte.Text = "00";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Len:";
            // 
            // dataPayload
            // 
            this.dataPayload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPayload.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPayload.Location = new System.Drawing.Point(429, 322);
            this.dataPayload.Name = "dataPayload";
            this.dataPayload.Size = new System.Drawing.Size(250, 20);
            this.dataPayload.TabIndex = 17;
            this.dataPayload.Text = " ";
            this.dataPayload.TextChanged += new System.EventHandler(this.dataPayload_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Data:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Try";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Sniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(769, 486);
            this.Controls.Add(this.gb_filter);
            this.Controls.Add(this.gb_details);
            this.Name = "Sniffer";
            this.Text = "Sniffer";
            this.gb_filter.ResumeLayout(false);
            this.gb_filter.PerformLayout();
            this.gb_details.ResumeLayout(false);
            this.gb_details.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_recieved;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label lb_vendor;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lb_product;
        private System.Windows.Forms.Label lb_senddata;
        private System.Windows.Forms.Label lb_messages;
        private System.Windows.Forms.TextBox tb_vendor;
        private System.Windows.Forms.TextBox tb_product;
        private System.Windows.Forms.GroupBox gb_filter;
        private System.Windows.Forms.ListBox lb_message;
        private System.Windows.Forms.GroupBox gb_details;
        private UsbLibrary.UsbHidPort usb;
        private System.Windows.Forms.ListBox lb_read;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox eventByte2;
        private System.Windows.Forms.TextBox eventByte1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lenByte;
        private System.Windows.Forms.TextBox messageIdByte2;
        private System.Windows.Forms.TextBox messageIdByte1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dataPayload;
        private System.Windows.Forms.Button button1;

    }
}

