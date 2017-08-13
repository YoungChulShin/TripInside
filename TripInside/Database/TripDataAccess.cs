using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using TripInside.Models.DBModels;
using Xamarin.Forms;

namespace TripInside.Database
{
    public static class TripDataAccess
    {
        private static SQLiteConnection _database;

        static TripDataAccess()
        {
            _database = DependencyService.Get<IDatabaseConnection>().DbConnection();
			_database.CreateTable<Trip>();
            _database.CreateTable<TripHistory>();
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

        public static int SaveTripHistory(TripHistory tripHistoryInstance)
        {
            if (tripHistoryInstance.Id != 0)
            {
                _database.Update(tripHistoryInstance);
            }
            else
            {
                _database.Insert(tripHistoryInstance);
            }

            return tripHistoryInstance.Id;
        }

        public static IEnumerable<TripHistory> GetTripHistorys(int tripID)
        {
            var query = from tripHistory in _database.Table<TripHistory>()
                        where tripHistory.Id == tripID
                        select tripHistory;

            return query.AsEnumerable();
        }

        public static int GetTripCount()
        {
            return GetTrips().Count();
        }

        public static int GetTripHistoryCount(int tripID)
        {
            return GetTripHistorys(tripID).Count();
        }
    }
}
