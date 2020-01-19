using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Input;
using System.Collections;

namespace FavouriteApps_WinForms
{
    public partial class Form1 : Form
    {
        bool hidedToTopBar = false;
        bool mouseDown = false;
        int baseHeight = 100;
        int windowX = 500, windowY = 300;
        List<bool> filledPicBoxTable = new List<bool>(259);
        List<string> AppsList = new List<string>(259);
        string basepath = @"D:\C#_projects\FavouriteApps-WinForms\FavouriteApps-WinForms\FavouriteApps-WinForms\bin\Debug\Icons\";

        public Form1()
        {
            this.SetDesktopLocation(windowX, windowY);
            InitializeComponent();
            for (int i = 0; i < 260; i++)
            {
                filledPicBoxTable.Add(false);
                AppsList.Add("");
            }
        }

        public string GetPath(int i)
        {
            return AppsList[i];
        }

        private void choosingFileToPictureBox(PictureBox element , int pictureBoxNumber) {

            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AppsList[pictureBoxNumber-1] = openFileDialog.FileName;
                element.Image = Image.FromFile(String.Join("", new string[] { basepath, "default.png" }));
            }            
            var path = AppsList[pictureBoxNumber - 1];
            var icon = IconFromFilePath(path);
            string iconName = String.Join("", new string[] { Path.GetFileName(path), ".png" });
            Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase));
            if (icon != null)
            {
                // Save it to disk, or do whatever you want with it.
                if (!File.Exists(String.Join("", new string[] { basepath, iconName })))
                {
                    using (var stream = new System.IO.FileStream(String.Join("", new string[] { basepath, iconName }), System.IO.FileMode.CreateNew))
                    {
                        icon.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                element.Image = Image.FromFile(String.Join("", new string[] { basepath, iconName }));
                filledPicBoxTable[pictureBoxNumber - 1] = true;
            }

            Bitmap IconFromFilePath(string filePath)
            {
                var result = (Icon)null;
                var final = (Bitmap)null;

                try
                {
                    result = Icon.ExtractAssociatedIcon(filePath);
                    final = result.ToBitmap();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Something went wrong with converting icon to bitmap");
                    // swallow and return nothing. You could supply a default Icon here as well
                }

                return final;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            PictureBox picbox = (PictureBox)sender;
            int picboxNb = Convert.ToInt32(picbox.Tag.ToString());
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (filledPicBoxTable[picboxNb-1] == false)
                {
                    choosingFileToPictureBox(picbox, picboxNb);
                }
                else
                {
                    OpenApp(picboxNb);
                }
            }
            else if (me.Button == System.Windows.Forms.MouseButtons.Right) {
                picbox.Image = Image.FromFile(String.Join("", new string[] { basepath, "default.png" }));
                filledPicBoxTable[picboxNb - 1] = false;
                AppsList[picboxNb - 1] = "";
            }
        }


        private void OpenApp(int number)
        {
            try
            {
                Process.Start(GetPath(number - 1));
            }
            catch { }
        }

        private void TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void TopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                windowX = MousePosition.X - 100;
                windowY = MousePosition.Y - 10;
                this.SetDesktopLocation(windowX, windowY);
            }
        }

        private void TopBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && mouseOnRightBorder())
            {
                this.Width = MousePosition.X - windowX ;
                TopBar.Width = MousePosition.X - windowX;
            }
            else if (mouseDown && mouseOnBottomBorder()) {
                this.Height = MousePosition.Y - windowY;
                baseHeight = this.Height;
            }
        }

        private bool mouseOnBottomBorder()
        {
            int point = MousePosition.Y - (windowY + this.Height - 5);
            bool ret = point > 0 ? true : false;
            return ret;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private bool mouseOnRightBorder() {
            int point = MousePosition.X - (windowX + this.Width - 5);
            bool ret = point > 0 ? true :  false;
            return ret;
        }

        private void TopBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(TopBar.Height.ToString());
            if (hidedToTopBar)
            {
                hidedToTopBar = false;
                this.Height = baseHeight;
                
            }
            else {
                hidedToTopBar = true;
                this.Height = TopBar.Height;
            }
        }
    }
}
