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

namespace FavouriteApps_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenApp(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenApp(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenApp(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenApp(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenApp(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            var basepath = @"D:\C#_projects\FavouriteApps-WinForms\FavouriteApps-WinForms\FavouriteApps-WinForms\bin\Debug\Icons\";
            //var path = @"C:\Program Files (x86)\GPU-Z\GPU-Z.exe";
            var path = @"C:\Program Files (x86)\GPU-Z\Google Chrome.lnk";
            var icon = IconFromFilePath(path);
            Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase));
            if (icon != null)
            {
                // Save it to disk, or do whatever you want with it.
                if (!File.Exists(String.Join("", new string[] { basepath, "icon2.png" })))
                {
                    using (var stream = new System.IO.FileStream(String.Join("", new string[] { basepath, "icon2.png" }), System.IO.FileMode.CreateNew))
                    {
                        icon.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    pictureBox2.Image = Image.FromFile(String.Join("", new string[] { basepath, "icon2.png" }));
                }
                //Console.WriteLine(String.Join("",new string[] { basepath, "icon2.ico" }));
                else {Console.WriteLine("File exists");}
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
                    // swallow and return nothing. You could supply a default Icon here as well
                }

                return final;
            }
        }

        private void OpenApp(int number)
        {
            Apps app = new Apps();
            Process.Start(app.GetPath(number));
        }

    }
}
