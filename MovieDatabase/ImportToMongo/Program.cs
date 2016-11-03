using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Xml;

namespace ImportToMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../XMLFile1.xml");

            XmlNode rootNode = doc.DocumentElement;

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MoviesDatabase");
            var collection = database.GetCollection<BsonDocument>("movies");

            var filter = new BsonDocument();
            var result = collection.DeleteMany(filter);

            foreach (XmlNode movie in rootNode.ChildNodes)
            {                
                string firstName = movie["Director"]["FirstName"].InnerText;
                string lastName = movie["Director"]["LastName"].InnerText;
                string age = movie["Director"]["Age"].InnerText;

                var document = new BsonDocument
                    {
                        { "name", movie["Name"].InnerText},
                        { "duration", movie["Duration"].InnerText },
                        { "description", movie["Description"].InnerText },
                        { "rating", movie["Rating"].InnerText },
                        { "year", movie["Year"].InnerText },
                        { "genre", movie["Genre"].InnerText },
                        { "director", new BsonDocument
                            {
                                { "fullName", firstName + " " + lastName },
                                { "age", age }
                            }}
                      
                    };
                BsonArray actors = new BsonArray();

                foreach (XmlNode actor in movie["Actors"].ChildNodes)
                {
                    string actorFirstName = actor["FirstName"].InnerText;
                    string actorLastName = actor["LastName"].InnerText;
                    string actorAge = actor["Age"].InnerText;

                    var actorsInfo = new BsonDocument { { "fullName", actorFirstName + " " + actorLastName }, { "age", actorAge } };

                    actors.Add(actorsInfo);
                }

                document.Add("actors", actors);
                
                collection.InsertOne(document);
            }

            var cursor = collection.Find(new BsonDocument()).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine(document);
            }
        }
    }
}
