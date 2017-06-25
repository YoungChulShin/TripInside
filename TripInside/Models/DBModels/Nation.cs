using System;
using SQLite;
namespace TripInside.Models.DBModels
{
    [Table("Nation")]
    public class Nation
    {
        private string _Code;
        private string _Name;

        [PrimaryKey, NotNull]
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        [NotNull]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
    }
}
