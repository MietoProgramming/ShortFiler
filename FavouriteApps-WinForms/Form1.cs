﻿using System;
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
using Lib;

namespace FavouriteApps_WinForms
{
    public partial class Form1 : Form
    {
        int hidedToTopBar = 0;
        bool mouseDown = false;
        int openHeight = 672;
        int height, width;
        int windowX, windowY;
        List<AppModel> icons;
        string basepath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Icons\\";
        

        public Form1()
        {
            SettingsModel setmod = SqliteDataAccess.LoadStartPoint(); 
            windowX = setmod.x;
            windowY = setmod.y;
            width = setmod.width;
            height = setmod.height;
            //hidedToTopBar = setmod.hided;
            InitializeComponent();
            LoadIcons();
            this.SetDesktopLocation(windowX, windowY);
            //TopBar_MouseDoubleClick();
            this.Width = width;
            this.Height = height;
        }

        public void LoadIcons()
        {
            icons = SqliteDataAccess.LoadIcons();
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            Console.WriteLine("Start");
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox picbox = control as PictureBox;
                    pictureBoxes.Add(picbox);
                }
            }
            pictureBoxes.Reverse();
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Image = Image.FromFile(String.Join("", new string[] { basepath, icons[i].name }));
            }
            Console.WriteLine("Stop");
        }
        public string GetPath(int i)
        {
            return SqliteDataAccess.GetPath(i);
        }

        private void choosingFileToPictureBox(PictureBox element , int pictureBoxNumber) 
        {
            string path = GetPath(pictureBoxNumber);
            int filled;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog.FileName;
                element.Image = Image.FromFile(String.Join("", new string[] { basepath, "Undefined name.png" }));
            }            
            var icon = IconFromFilePath(path);
            string iconName = String.Join("", new string[] { Path.GetFileName(path), ".png" });
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
                filled = 1;
                AppModel app = new AppModel();
                app.id = pictureBoxNumber;
                app.filled = filled;
                app.path = path;
                app.name = iconName;
                SqliteDataAccess.SaveIcon(app);
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
            int filled = SqliteDataAccess.GetFillState(picboxNb);
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (filled == 0)
                {
                    choosingFileToPictureBox(picbox, picboxNb);
                }
                else if (filled == 1)
                {
                    OpenApp(picboxNb);
                }
                else 
                {
                    MessageBox.Show("Bad state:" + filled.ToString() + " Correct: 0 or 1.");
                }
            }
            else if (me.Button == System.Windows.Forms.MouseButtons.Right) 
            {
                picbox.Image = Image.FromFile(String.Join("", new string[] { basepath, "Undefined name.png" }));
                AppModel app = new AppModel();
                app.id = picboxNb;
                app.path = "";
                app.filled = 0;
                app.name = "Undefined name.png";
                SqliteDataAccess.SaveIcon(app);
            }
        }


        private void OpenApp(int number)
        {
            try
            {
                Process.Start(GetPath(number));
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
            SettingsModel setmod = new SettingsModel();
            setmod.x = windowX;
            setmod.y = windowY;
            setmod.height = height;
            setmod.width = width;
            setmod.hided = hidedToTopBar;
            SqliteDataAccess.SaveStartPoint(setmod);
            GC.Collect();
            this.Close();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && mouseOnRightBorder())
            {
                this.Width = MousePosition.X - windowX ;
                TopBar.Width = MousePosition.X - windowX;
                width = this.Width;
            }
            else if (mouseDown && mouseOnBottomBorder()) {
                this.Height = MousePosition.Y - windowY;
                height = this.Height;
                openHeight = height;
            }
        }

        private bool mouseOnBottomBorder()
        {
            int point = MousePosition.Y - (windowY + this.Height - 15);
            bool ret = point > 0 ? true : false;
            return ret;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private bool mouseOnRightBorder() {
            int point = MousePosition.X - (windowX + this.Width - 15);
            bool ret = point > 0 ? true :  false;
            return ret;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            PictureBox picbox = (PictureBox)sender;
            int nb = Convert.ToInt32(picbox.Tag);
            string name = SqliteDataAccess.GetNameOfApp(nb);
            if (name == null) { nameLabel.Text = "Undefined name"; }
            else { nameLabel.Text = name.ToString().Replace(".png",""); }
            
        }

        private void TopBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (hidedToTopBar == 1)
            {
                hidedToTopBar = 0;
                this.Height = height;
                
            }
            else {
                hidedToTopBar = 1;
                this.Height = TopBar.Height;
            }
        }

        private void TopBar_MouseDoubleClick()
        {
            if (hidedToTopBar == 1)
            {
                hidedToTopBar = 0;
                this.Height = height;

            }
            else
            {
                hidedToTopBar = 1;
                this.Height = TopBar.Height;
            }
        }
    }
}
