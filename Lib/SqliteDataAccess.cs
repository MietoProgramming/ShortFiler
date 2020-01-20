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
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))//TODO:  on load copy to list and in for loop adding photos (path and filled work)
            {
                var output = cnn.Query<AppModel>("SELECT * FROM apps");
                return output.ToList();
            }
        }

        public static void SaveIcon(AppModel app)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                Console.WriteLine("id: " + app.id + " path:" + app.path + " filled:" + app.filled);
                cnn.Execute("update apps set path = @path,filled = @filled where id=@id", app);
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
                return output[0].path;
            }

        }

        public static int GetFillState(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AppModel>("select filled from apps where id = @id", new {id = id }).ToList();
                return output[0].filled;
            }
        }


    }
}
