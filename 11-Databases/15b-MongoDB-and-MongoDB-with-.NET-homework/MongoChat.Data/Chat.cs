namespace MongoChat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using MongoChat.Model;

    public class Chat
    {
        public const string MongoTableName = "ChatPosts";

        public Chat(string mongoUrl, string mongoDatabaseName)
        {
            this.Client = new MongoClient(mongoUrl);
            this.Server = Client.GetServer();
            this.Db = Server.GetDatabase(mongoDatabaseName);
        }

        public MongoClient Client { get; private set; }

        public MongoServer Server { get; private set; }

        public MongoDatabase Db { get; private set; }

        public void AddPost(string user, string message)
        {
            var postCollections = this.Db.GetCollection<ChatPost>(MongoTableName);

            var post = new ChatPost(user, message);
            postCollections.Insert(post);
        }

        public ICollection<ChatPost> GetAllPost()
        {
            var postCollections = this.Db.GetCollection<ChatPost>(MongoTableName).FindAll().ToList();
            return postCollections;
        }

        public ICollection<ChatPost> GetLatestPost(DateTime dateFrom)
        {
            var postCollections = this.Db.GetCollection<ChatPost>(MongoTableName).FindAll().Where(p => p.Date >= dateFrom).ToList(); ;
            return postCollections;
        }
    }
}