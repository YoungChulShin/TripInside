using System;
using SQLite;
using TripInside.Database;
using TripInside.iOS;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace TripInside.iOS
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "TripInsideDb.db3";
            string dbpath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(dbpath);
            }
    }
}
