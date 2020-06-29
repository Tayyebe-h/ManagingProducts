using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ManagingProducts.Models
{
    public class Product
    {
        public List<Store> Stores { get; set; } = new List<Store>();
        public Manufacture Manufacture { get; set; } = new Manufacture();
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
