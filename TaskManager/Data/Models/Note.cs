using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Models
{
    public class Note : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("title")]
        public string Title { get; set; }

        [MapTo("content")]
        public string Content { get; set; }

        [MapTo("color")]
        public string Color { get; set; }


        [MapTo("timestamp")]
        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.Now;
    }
}