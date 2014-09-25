namespace MongoChat.Model
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;

    public class ChatPost
    {
        public ChatPost(string user, string message)
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            this.User = user;
            this.Message = message;
            this.Date = DateTime.Now;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string User { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
