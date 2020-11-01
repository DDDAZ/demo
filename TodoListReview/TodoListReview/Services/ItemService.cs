using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListReview.Models;

namespace TodoListReview.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;
        public ItemService(IItemSettings settings)
        {
            var client = new MongoClient(settings.Address);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<Item>(settings.CollectionName);
        }

        public async Task<List<Item>> Get()
        {
            return await _items.Find(item => true).ToListAsync();
        }

        public async Task<Item> Get(long id)
        {
            return await _items.Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Item itemIn)
        {
            await _items.InsertOneAsync(itemIn);
        }

        public async Task Delete(long id)
        {
            await _items.DeleteOneAsync(item => item.Id == id);
        }

        public async Task Update(long id, Item newItem)
        {
            await _items.ReplaceOneAsync(item => item.Id == id, newItem);
        }
    }
}
