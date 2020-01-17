using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavouriteApps_WinForms
{
    public class Apps
    {
        private string[] AppsList = new string[5] { @"C:\Program Files (x86)\GPU-Z\GPU-Z.exe", @"C:\Program Files (x86)\GPU-Z\GPU-Z.exe", @"C:\Program Files (x86)\GPU-Z\GPU-Z.exe", @"C:\Program Files (x86)\GPU-Z\GPU-Z.exe", @"C:\Program Files (x86)\GPU-Z\GPU-Z.exe" };
        public string GetPath(int i) {
            return AppsList[i];
        }
    }
}
