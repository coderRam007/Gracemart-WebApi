using Microsoft.AspNetCore.Mvc;
using Stripe;

[Route("api/payment")]
[ApiController]
public class PaymentController : ControllerBase
{
    [HttpPost]
    public IActionResult ProcessPayment([FromBody] PaymentRequest request)
    {
        StripeConfiguration.ApiKey = "your_secret_key_here"; // Replace with Stripe Secret Key

        var options = new PaymentIntentCreateOptions
        {
            Amount = request.Amount,
            Currency = "usd",
            PaymentMethod = request.PaymentMethodId,
            Confirm = true
        };

        var service = new PaymentIntentService();
        try
        {
            PaymentIntent intent = service.Create(options);
            return Ok(new { success = true, paymentId = intent.Id });
        }
        catch (StripeException e)
        {
            return BadRequest(new { success = false, error = e.Message });
        }
    }
}

public class PaymentRequest
{
    public long Amount { get; set; }
    public string PaymentMethodId { get; set; }
}
