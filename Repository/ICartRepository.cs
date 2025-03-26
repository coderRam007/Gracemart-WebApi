using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICartRepository
{
    Task<List<CartData>> GetCartByUserNameAsync(string userName);
    Task SaveCartAsync(CartData cartData);
}