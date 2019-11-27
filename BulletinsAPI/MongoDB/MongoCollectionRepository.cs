using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinsApi.MongoDB
{
    public class MongoCollectionRepository
    {
        private readonly IMongoCollection<BulletinsAPI.Models.Bulletin> _collection;

        public MongoCollectionRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<BulletinsAPI.Models.Bulletin>("bulletin_collection");
        }

        public virtual async Task<BulletinsAPI.Models.Bulletin> GetById(Guid id)
        {
            var results = await _collection.Find(x => x.Id == id).ToListAsync();
            return results.First();
        }

        public virtual void Insert(BulletinsAPI.Models.Bulletin bulletin)
        {
            _collection.InsertOne(bulletin);
        }

        public virtual void Delete(Guid id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }

        public virtual void Update(Guid id, BulletinsAPI.Models.Bulletin updateBulletin)
        {
            var filter = Builders<BulletinsAPI.Models.Bulletin>.Filter.Eq(x => x.Id, id);
            var update = Builders<BulletinsAPI.Models.Bulletin>.Update.Set(x => x.Votes, updateBulletin.Votes)
           .Set(x => x.Title, updateBulletin.Title)
           .Set(x => x.Description, updateBulletin.Description)
           .Set(x => x.Url, updateBulletin.Url)
           .Set(x => x.AvatarUrl, updateBulletin.AvatarUrl)
           .Set(x => x.BulletinImageUrl, updateBulletin.BulletinImageUrl);

            _collection.UpdateOne(filter, update);
        }

        public virtual async Task<IEnumerable<BulletinsAPI.Models.Bulletin>> GetList()
        {
                return await _collection
                    .Find(x => true)
                    .ToListAsync();
        }
    }
}
