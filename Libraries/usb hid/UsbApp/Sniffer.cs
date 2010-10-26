using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UsbLibrary;

namespace UsbApp
{
    public partial class Sniffer : Form
    {
        public Sniffer()
        {
            InitializeComponent();
        }

        private void usb_OnDeviceArrived(object sender, EventArgs e)
        {
            this.lb_message.Items.Add("Found a Device");
        }

        private void usb_OnDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                this.lb_message.Items.Add("Device was removed");
            }
        }

        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            this.lb_message.Items.Add("My device was found");

            //setting string form for sending data
            
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usb.RegisterHandle(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            usb.ParseMessages(ref m);
            base.WndProc(ref m);	// pass message on to base form
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                this.usb.ProductId = Int32.Parse(this.tb_product.Text, System.Globalization.NumberStyles.HexNumber);
                this.usb.VendorId = Int32.Parse(this.tb_vendor.Text, System.Globalization.NumberStyles.HexNumber);
                this.usb.CheckDevicePresent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                //string text = this.tb_send.Text + " ";
                //text.Trim();
                //string[] arrText = text.Split(' ');
                byte[] data = new byte[65];
                data[0] = 0x00;
                data[1] = Convert.ToByte( eventByte1.Text, 16 ) ;
                data[2] = Convert.ToByte( eventByte2.Text,16);
                data[3] = Convert.ToByte(messageIdByte1.Text, 16) ;
                data[4] = Convert.ToByte(messageIdByte2.Text, 16);
                data[5] = Convert.ToByte(lenByte.Text, 16);
                var payload = ParseHexString(dataPayload.Text);
                payload.CopyTo(data, 6);
                /*for (int i = 0; i < arrText.Length; i++)
                {
                    if (arrText[i] != "")
                    {
                        int value = Int32.Parse(arrText[i], System.Globalization.NumberStyles.Number);
                        data[i] = (byte)Convert.ToByte(value);
                    }
                }*/

                if (this.usb.SpecifiedDevice != null)
                {
                    this.usb.SpecifiedDevice.SendData(data);
                }
                else
                {
                    MessageBox.Show("Sorry but your device is not present. Plug it in!! ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnSpecifiedDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                this.lb_message.Items.Add("My device was removed");
            }
        }

        private void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new DataRecievedEventHandler(usb_OnDataRecieved), new object[] { sender, args });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {

                string recData = "Data: ";
                bool allAreZeros = true;
                foreach (byte myData in args.data)
                {
                    if (myData != 0) allAreZeros = false;
                    var str = string.Format("{0:X} ", myData); 
                    if( str.Length == 2 ) str = "0" + str;
                    recData += str;
                }
                if( !allAreZeros ) this.lb_read.Items.Insert(0, recData);
            }
        }

        private void usb_OnDataSend(object sender, EventArgs e)
        {
            this.lb_message.Items.Add("Some data was send");
        }

        private void dataPayload_TextChanged(object sender, EventArgs e)
        {
            var bytes = ParseHexString(dataPayload.Text);
            lenByte.Text = bytes.Length.ToString("X");
            if (lenByte.Text.Length == 1) lenByte.Text = "0" + lenByte.Text;
        }
        public byte[] ParseHexString( string str )
        {
            str = str.Trim();
            if( str == "" ) return new byte[0];
            var strings = str.Split(' ');
            
            var bytes = new byte[strings.Length];
            int i = 0;
            foreach (var byteString in strings)
            {
                try
                {
                    bytes[i] = Convert.ToByte(byteString, 16);
                }
                catch
                {}
                i++;
            }
            return bytes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var current = Convert.ToByte(eventByte2.Text, 16);
            eventByte2.Text = (current + 1 ).ToString("X");
            if (eventByte2.Text.Length == 1) eventByte2.Text = "0" + eventByte2.Text;
            btn_send_Click(null, null);
     
        }
    }
}