﻿using MongoDB.Bson.Serialization.Attributes;

namespace FoodMartMongo.Entities
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }
      
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
