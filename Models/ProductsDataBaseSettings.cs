namespace WebAPIProdutoMongoDB.Models
{
    public class ProductsDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;

    }
}
