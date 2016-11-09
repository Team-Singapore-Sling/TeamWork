using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Xml;

namespace ImportToMongo
{
    public class ImportToMongo
    {
        static void Main()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../MoviesImport.xml");

            XmlNode rootNode = doc.DocumentElement;

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MoviesDatabase");
            var collection = database.GetCollection<BsonDocument>("movies");

            var filter = new BsonDocument();

            //var result = collection.DeleteMany(filter);

            foreach (XmlNode movie in rootNode.ChildNodes)
            {
                string firstName = movie["directors"]["firstName"].InnerText;
                string lastName = movie["directors"]["lastName"].InnerText;
                string age = movie["directors"]["age"].InnerText;
                string salary = movie["directors"]["salary"].InnerText;

                var document = new BsonDocument
                    {
                        { "name", movie["name"].InnerText},
                        { "duration", movie["duration"].InnerText },
                        { "description", movie["description"].InnerText },
                        { "rating", movie["rating"].InnerText },
                        { "year", movie["year"].InnerText },
                    { "directors", new BsonDocument
                            {
                                { "fullName", firstName + " " + lastName },
                                { "age", age },
                                { "salary", salary }
                            }},
                    };

                BsonArray genres = new BsonArray();

                foreach (XmlNode genre in movie["genres"].ChildNodes)
                {
                    string genreName = genre.InnerText;

                    var genreInfo = new BsonDocument { { "name", genreName } };

                    genres.Add(genreInfo);
                }

                BsonArray actors = new BsonArray();

                var actorInfo = new BsonDocument { };

                foreach (XmlNode row in movie["actors"].ChildNodes)
                {
                    string textRow = row.InnerText;

                    string attributeName = row.Name;

                    actorInfo.Set(attributeName, textRow);
                    if (attributeName == "salary")
                    {
                        actors.Add(actorInfo);
                        actorInfo = new BsonDocument { };
                    }
                }

                document.Add("actors", actors);

                collection.InsertOne(document);
            }

            //print na data-ta
            var cursor = collection.Find(new BsonDocument()).ToCursor();

            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine(document);
            }
        }
    }
}

