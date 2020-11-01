using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TodoListReview.Models
{
    public class Item
    {
        [BsonElement("id")]
        public long Id { get; set; }

        [BsonElement("start time")]
        public string StartingTime => DateTime.Now.ToString("yyyy-MM-dd");

        [BsonElement("issue")]
        public string Issue { get; set; }

        [BsonElement("cooperative")]
        public bool IsCooperative { get; set; }
    }
}
