using System;
using SQLite;
using TripInside.Models;
using Xamarin.Forms;

namespace TripInside.Models.DBModels
{
    [Table("TripHistory")]
    public class TripHistory : BaseModel
    {
        [PrimaryKey, Indexed]
        public DateTime RegisterDate { get; set; }

        [NotNull, Indexed]
        public int Id { get; set; }

        [NotNull]
        public string Weather { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        [NotNull]
        public string Contents { get; set; }
        
        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public byte[] Image3 { get; set; }

        public byte[] Image4 { get; set; }

        public byte[] Image5 { get; set; }
    }
}
