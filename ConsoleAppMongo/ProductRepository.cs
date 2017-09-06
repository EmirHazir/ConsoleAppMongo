using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMongo
{
    public class ProductRepository
    {
        MongoClient _client;

        IMongoDatabase db;

        IMongoCollection<Product> _collection;

        public ProductRepository()
        {
            _client = new MongoClient();

            db = _client.GetDatabase("Commerce");
            _collection = db.GetCollection<Product>("product");
        }

        //Insert()
        public async Task Insert(Product prod)
        {
            await _collection.InsertOneAsync(prod);
        }

        //remove()
        public async Task Delete(ObjectId id)
        {
            await _collection.DeleteOneAsync(x=>x._id == id);
        }

        //update()
        public async Task Update(Product prod)
        {
            await _collection.UpdateOneAsync(
                    Builders<Product>.Filter.Eq(x => x._id, prod._id),
                    Builders<Product>.Update.Set(x=>x.ProductName,prod.ProductName)      
                );
        }

        //Find()
        public async Task<List<Product>> FindAll()
        {
            var pList = await _collection.Find(new BsonDocument()).ToListAsync<Product>();

            return pList;
        }

        //FindOne()
        public async Task<List<Product>> FindById(ObjectId id)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Eq("_id", id);

            var _product = await _collection.Find(filter).ToListAsync<Product>();

            return _product;
        }


    }
}
