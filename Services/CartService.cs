using System.Collections.Generic;
using System.Threading.Tasks;

public class CartService 
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<List<CartData>> GetCartByUserNameAsync(string userName)
    {
        return await _cartRepository.GetCartByUserNameAsync(userName);
    }

    public async Task SaveCartAsync(CartData cartData)
    {
        await _cartRepository.SaveCartAsync(cartData);
    }
}
