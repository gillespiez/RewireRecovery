using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using SQLite.Net;
using RewireRecovery.Droid.Implementations;
using RewireRecovery.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]

namespace RewireRecovery.Droid.Implementations
{
    public class AndroidSQLite //: ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            // Documents folder  
            var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLiteConnection(plat, path);

            // Return the database connection  
            return conn;
        }
    }
}