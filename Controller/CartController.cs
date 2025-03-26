using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    // ✅ Retrieve Cart Items from MongoDB
    [HttpGet("get/{userName}")]
public async Task<ActionResult> GetCart(string userName)
{
    var cartItems = await _cartService.GetCartByUserNameAsync(userName);
    if (!cartItems.Any())  // If the list is empty

        return Ok(new { message = "Cart is empty" });

    return Ok(cartItems);
    Debug.WriteLine("load call in backend",cartItems);
}


    // ✅ Save Cart to MongoDB
    [HttpPost("save")]
public async Task<ActionResult> SaveCart([FromBody] CartData cartData)
{
    
    if (cartData.Items == null) cartData.Items = new List<CartItem>();

    await _cartService.SaveCartAsync(cartData);
    return Ok(new { message = "Cart updated successfully" });
    Debug.WriteLine("savecart");
}

}

