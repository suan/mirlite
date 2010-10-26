using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace mirlite
{
    public partial class WatermarkTextBox : TextBox
    {
        public WatermarkTextBox()
        {
            //InitializeComponent();
            this.Enter += this.UserControl1_Enter;
            this.Leave += this.UserControl1_Leave;
        }
        private string watermarkText;
        private Color watermarkColor;
        private Color foreColor;
        private bool empty;

        [Browsable(true)]
        public new Color ForeColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                if (!empty)
                    base.ForeColor = value;
            }
        }

        [Browsable(true)]
        public Color WatermarkColor
        {
            get { return watermarkColor; }
            set
            {
                watermarkColor = value;
                if (empty)
                {
                    base.ForeColor = watermarkColor;
                }
            }
        }

        [Browsable(true)]
        public string WatermarkText
        {
            get
            {
                return watermarkText;
            }
            set
            {
                watermarkText = value;
                if (base.Text.Length == 0)
                {
                    empty = true;
                    base.Text = watermarkText;
                    base.ForeColor = watermarkColor;
                }
                Invalidate();
            }
        }
        public override string Text
        {
            get
            {
                if (empty)
                    return "";
                return base.Text;
            }
            set
            {
                if (value == "")
                {
                    empty = true;
                    base.ForeColor = watermarkColor;
                    base.Text = watermarkText;
                }
                else
                {
                    empty = false;
                    base.ForeColor = foreColor;
                    base.Text = value;
                }
            }
        }
        private void UserControl1_Enter(object sender, EventArgs e)
        {
            if (empty)
            {
                empty = false;
                base.ForeColor = foreColor;
                base.Text = "";
            }
        }
        private void UserControl1_Leave(object sender, EventArgs e)
        {
            if (base.Text == "")
            {
                empty = true;
                base.ForeColor = watermarkColor;
                base.Text = watermarkText;
            }
            else
            {
                empty = false;
            }
        }

        // SUAN added... required HACK to make this behave when user presses 'enter' on it
        public void forceEmpty()
        {
            empty = true;
        }
    }


}
