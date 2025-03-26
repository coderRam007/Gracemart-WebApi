using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/[controller]")]
public class UserDetailsController : ControllerBase
{
    private readonly UserDetailsService _userDetailsService;

    public UserDetailsController(UserDetailsService userDetailsService)
    {
        _userDetailsService = userDetailsService;
    }

    [HttpGet("/getUserDetails")]
    public async Task<ActionResult<UserDetails<String>>> GetUser(string userName)
    {
        return Ok(await _userDetailsService.GetUserDetails(userName));
    }

    [HttpPost("/saveUserDetails")]
    public async Task<ActionResult<UserDetails<String>>> SaveUserDetails([FromForm] UserDetails<IFormFile> newUser){
        var insertedUser = await _userDetailsService.SaveUserDetails(newUser);
        return CreatedAtAction(nameof(GetUser), new { userName = insertedUser.userName }, insertedUser);
    }

    [HttpPatch("/updateUserDetails")]
    public ActionResult UpdateUserDetails([FromForm] UserDetails<IFormFile> updatedUserDetails){
        
        _userDetailsService.UpdateUserDetails(updatedUserDetails);
        Console.WriteLine("update invoked in controller");
        return Ok(updatedUserDetails);
    }
    
    [HttpPatch("/updateProfileImage")]
    [Consumes("multipart/form-data")]
    public ActionResult UpdateProfileImage( [FromForm] UpdatedProfileImage<IFormFile> updatedProfile){
        
        _userDetailsService.UpdateProfileImage(updatedProfile.userName,updatedProfile.profileImage);
        return Ok("success");
    }
}
