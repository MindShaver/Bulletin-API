using System.Security.Authentication;
using MongoDB.Driver;

namespace BulletinsApi.MongoDB
{
    public class MongoDatabaseProvider
    {
        public virtual IMongoDatabase GetDatabase()
        {
            const string connectionString = @"mongodb://react-app-bulletins:68146ninammGwcV618Fp0tkbgPrzBNuj1ijhK1huDPBtf4kA2ZSCRRIFb12KClZidoBM2HrqdmIgmAtajeAIBw==@react-app-bulletins.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };

            var mongoClient = new MongoClient(settings);

            return mongoClient.GetDatabase("bulletins");
        }
    }
}
