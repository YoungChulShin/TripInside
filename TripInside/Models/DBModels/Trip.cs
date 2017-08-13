using System;
using SQLite;
using TripInside.Models;
using Xamarin.Forms;

namespace TripInside.Models.DBModels
{
    [Table("Trip")]
    public class Trip : BaseModel
    {
        private int _id;
        private string _name;
        private string _nationalCode;
        private DateTime _fromDate;
        private DateTime _toDate;
        private DateTime _createDate;

        [PrimaryKey, AutoIncrement, Indexed]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        [NotNull, Indexed]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        [NotNull, Indexed]
        public string NationalCode
        {
            get
            {
                return _nationalCode;
            }
            set
            {
                _nationalCode = value;
                OnPropertyChanged();
            }
        }

        [NotNull, Indexed]
        public DateTime FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
                OnPropertyChanged();
            }
        }

        [NotNull, Indexed]
        public DateTime ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
                OnPropertyChanged();
            }
        }
    }
}
