using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using TripInside.Models;
using Xamarin.Forms;
using TripInside.Models.DBModels;

namespace TripInside.Database
{
    public static class TripDataAccess
    {
        private static SQLiteConnection _database;
        private static ObservableCollection<Trip> Trips { get; set; }

        static TripDataAccess()
        {
            _database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _database.CreateTable<Trip>();
            Trips = new ObservableCollection<Trip>(_database.Table<Trip>());
        }

        public static int SaveTrip(Trip tripInstance)
        {
            if (tripInstance.Id != 0)
            {
                _database.Update(tripInstance);
            }
            else
            {
                _database.Insert(tripInstance);
            }

            return tripInstance.Id;
        }

        public static IEnumerable<Trip> GetTrips()
        {
            var query = from trip in _database.Table<Trip>()
                        select trip;

            return query.AsEnumerable();                                                       
        }

        public static int GetTripCount()
        {
            return GetTrips().Count();
        }
    }
}
