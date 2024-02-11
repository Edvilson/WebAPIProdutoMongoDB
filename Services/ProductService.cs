using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPIProdutoMongoDB.Models;

namespace WebAPIProdutoMongoDB.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IOptions<ProductsDataBaseSettings> productDataBaseSettings)
        {
            var _client = new MongoClient(
                productDataBaseSettings.Value.ConnectionString);

            var _dataBase = _client.GetDatabase(productDataBaseSettings.Value.DatabaseName);

            _productCollection = _dataBase.GetCollection<Product>(
                productDataBaseSettings.Value.ProductCollectionName);
        }

        public async Task<List<Product>> GetAsync() =>
            await _productCollection.Find(x => true).ToListAsync();
        public async Task<Product?> GetAsync(string id) =>
            await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreatAsync(Product model) =>
            await _productCollection.InsertOneAsync(model);
        public async Task UpdateAsync(string id, Product model) =>
            await _productCollection.ReplaceOneAsync(x => x.Id == id, model);
        public async Task RemoveAsync(string id) =>
            await _productCollection.DeleteOneAsync(x => x.Id == id);
    }
}
