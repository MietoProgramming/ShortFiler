using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptionMenuForm
{
    public partial class SettingsForm : Form
    {
        int red, green, blue;
        double opacity;
        Form baseForm;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            opacity = trackBarOpacity.Value / 100.0;
            red = trackBarRedColor.Value;
            green = trackBarGreenColor.Value;
            blue = trackBarBlueColor.Value;
            this.BackColor = Color.FromArgb(red, green, blue);
            baseForm.BackColor = Color.FromArgb(red, green, blue);
            Panel panel = new Panel();
            foreach (Control control in baseForm.Controls)
            {
                
                if (control is Panel && control.Name == "TopBar")
                {
                    panel = (Panel)control;
                }
            }
            int redtop, greentop, bluetop;
            if (red <= 30) { redtop = 0; }
            else { redtop = red - 30; }
            if (green <= 30) { greentop = 0; }
            else { greentop = green - 30; }
            if (blue <= 30) { bluetop = 0; }
            else { bluetop = blue - 30; }
            Console.WriteLine("Done TopBar");
            panel.BackColor = Color.FromArgb(redtop, greentop, bluetop);
            baseForm.Opacity = opacity;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            opacity = trackBarOpacity.Value;
            labelOpacityValue.Text = opacity.ToString();
        }

        private void trackBarRedColor_Scroll(object sender, EventArgs e)
        {
            red = trackBarRedColor.Value;
            labelRedColorValue.Text = red.ToString();
        }

        private void trackBarGreenColor_Scroll(object sender, EventArgs e)
        {
            green = trackBarGreenColor.Value;
            labelGreenColorValue.Text = green.ToString();
        }

        private void trackBarBlueColor_Scroll(object sender, EventArgs e)
        {
            blue = trackBarBlueColor.Value;
            labelBlueColorValue.Text = blue.ToString();
        }

        public SettingsForm(Form form)
        {
            InitializeComponent();
            baseForm = form;
        }

        private void OptionMenuForm_Load(object sender, EventArgs e)
        {
            opacity = baseForm.Opacity * 100;
            red = baseForm.BackColor.R;
            green = baseForm.BackColor.G;
            blue = baseForm.BackColor.B;
            labelOpacityValue.Text = opacity.ToString();
            labelRedColorValue.Text = red.ToString();
            labelGreenColorValue.Text = green.ToString();
            labelBlueColorValue.Text = blue.ToString();
            trackBarOpacity.Value = Convert.ToInt32(opacity);
            trackBarRedColor.Value = red;
            trackBarGreenColor.Value = green;
            trackBarBlueColor.Value = blue;
            this.BackColor = Color.FromArgb(red, green, blue);
        }
    }
}
