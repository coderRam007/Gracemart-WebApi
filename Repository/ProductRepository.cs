using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

public class ProductRepository : IProductRepository
{
    // Simulating a data source (you can replace this with a database or API call)
    private readonly IMongoCollection<ProductModel> _products;
     public ProductRepository()
    {
        _products = new MongoClient("mongodb+srv://rama:ramasara1212@cluster0.cmbqdhn.mongodb.net/").GetDatabase("EcommerceDB")
                            .GetCollection<ProductModel>("productCollection");

    }
    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        return await _products.Find(product=>true).ToListAsync();
    }
}
