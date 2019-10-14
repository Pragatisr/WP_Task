using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRental_WP.Models
{
    
    public class CarsModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("VehicleNo")]
        public string VehicleNo { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("SeatingCap")]
        public string SeatingCap { get; set; }
        [BsonElement("RentPerDay")]
        public string RentPerDay { get; set; }
        [BsonElement("BkdStatus")]
        public string BkdStatus { get; set; }
        [BsonElement("Image")]
        public string Img { get; set; }
    }
}