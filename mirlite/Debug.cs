using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mirror;
using Mirror.UsbLibrary;
using Orientation = Mirror.Orientation;
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
    public partial class MainForm
    {
        private void test()
        {
            LinkLabel ll = new LinkLabel();
            ll.Text = "some link";
            //listBox1.Controls.Add(ll);
            LinkLabel l2 = new LinkLabel();
            l2.Text = "some other link";
            LinkLabel l3 = new LinkLabel();
            l3.Text = "s3 other lidwadnk";
            tlpPlacedThings.Controls.Add(ll);
            //tableLayoutPanel1.Controls.Add(l2);
            //tableLayoutPanel1.Controls.Add(l3);
            //LinkLabel l4 = new LinkLabel();
            //l4.Text = "s4 other linfdsfsdk";
            //tableLayoutPanel1.Controls.Add(l4);
            //LinkLabel l5 = new LinkLabel();
            //l5.Text = "s5 other liwwwwwwwnk";
            //tableLayoutPanel1.Controls.Add(l5);
            //addStuff();
        }

        private void addStuff()
        {
            LinkLabel ll = new LinkLabel();
            ll.Text = "some link";
            //listBox1.Controls.Add(ll);
            LinkLabel l2 = new LinkLabel();
            l2.Text = "some other link";
            LinkLabel l3 = new LinkLabel();
            l3.Text = "s3 other lidwadnk";
            tlpPlacedThings.Controls.Add(ll);
            tlpPlacedThings.Controls.Add(l2);
            tlpPlacedThings.Controls.Add(l3);
            LinkLabel l4 = new LinkLabel();
            l4.Text = "s4 other linfdsfsdk";
            tlpPlacedThings.Controls.Add(l4);
            LinkLabel l5 = new LinkLabel();
            l5.Text = "s5 other liwwwwwwwnk";
            tlpPlacedThings.Controls.Add(l5);
        }

        private void debugMessage(String message)
        {
            MessageBox.Show(message, "debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
