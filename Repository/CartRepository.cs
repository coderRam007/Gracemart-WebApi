using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
public class CartRepository : ICartRepository
{
    private readonly IMongoCollection<CartData> _cartCollection;

    public CartRepository()
    {
        _cartCollection = new MongoClient("mongodb+srv://rama:ramasara1212@cluster0.cmbqdhn.mongodb.net/").GetDatabase("EcommerceDB")
                            .GetCollection<CartData>("cartCollection");
        Debug.WriteLine("Debug working");
    }

    public async Task<List<CartData>> GetCartByUserNameAsync(string userName)
    {
        return await _cartCollection.Find(cart => cart.userName == userName).ToListAsync();
    }

    public async Task SaveCartAsync(CartData cartData)
    {
        // Remove existing items for this user
    var filter = Builders<CartData>.Filter.Eq(u => u.userName, cartData.userName);
    var update = Builders<CartData>.Update.Set(u => u.Items, cartData.Items);
    await _cartCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });

    }
}
