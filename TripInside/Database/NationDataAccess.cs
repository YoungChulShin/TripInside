using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using TripInside.Models.DBModels;
using Xamarin.Forms;

namespace TripInside.Database
{
    public class NationDataAccess
    {
		private static SQLiteConnection _database;
		private static ObservableCollection<Nation> Nations { get; set; }

        public NationDataAccess()
        {
			_database = DependencyService.Get<IDatabaseConnection>().DbConnection();
			_database.CreateTable<Nation>();
			Nations = new ObservableCollection<Nation>(_database.Table<Nation>());
        }

        private static void SaveTrip()
		{
            
		}

		public static IEnumerable<Nation> GetNations()
		{
            var query = from nation in _database.Table<Nation>()
						select nation;

			return query.AsEnumerable();
		}
    }
}
