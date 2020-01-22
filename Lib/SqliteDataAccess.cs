using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Lib
{
    public class SqliteDataAccess
    {
        [STAThread]
        static void Main()
        {
        }
        public static List<AppModel> LoadIcons()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AppModel>("SELECT * FROM apps");
                cnn.Close();
                return output.ToList();
            }
        }

        public static SettingsModel LoadStartPoint()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SettingsModel>("SELECT * FROM settings").ToList();
                cnn.Close();
                return output[0];
            }
        }

        public static void SaveStartPoint(SettingsModel setmod)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update settings set x = @x,y = @y, height = @height, width = @width, hided = @hided", setmod);
                cnn.Close();
            }
        }

        public static void SaveIcon(AppModel app)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update apps set path = @path,filled = @filled, name=@name where id=@id", app);
                cnn.Close();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static string GetPath(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AppModel>("select path from apps where id = @id", new {id = id}).ToList();
                cnn.Close();
                return output[0].path;
            }

        }

        public static int GetFillState(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AppModel>("select filled from apps where id = @id", new {id = id }).ToList();
                cnn.Close();
                return output[0].filled;
            }
        }

        public static string GetNameOfApp(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AppModel>("select name from apps where id = @id", new { id = id }).ToList();
                cnn.Close();
                return output[0].name;
            }
        }
    }
}
