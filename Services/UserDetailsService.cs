using MongoDB.Bson;
public class UserDetailsService 
{
    private readonly IUserDetailsRepository _userDetailsRepository;

    public UserDetailsService(IUserDetailsRepository userDetailsRepository)
    {
        _userDetailsRepository = userDetailsRepository;
    }

    public async Task<UserDetails<String>> SaveUserDetails(UserDetails<IFormFile> model)
    {
        byte[] imageBytes=[] ;
        using (var memoryStream = new MemoryStream())
        {
            await model.profileImage.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }
     return await _userDetailsRepository.SaveUserDetails(new UserDetails<string>()
        {
            _id=ObjectId.GenerateNewId(),
            profileImage = Convert.ToBase64String(imageBytes),
            userName=model.userName,
            firstName=model.firstName,
            lastName=model.lastName,
            email=model.email,
            phone=model.phone,
            address=model.address,
            city=model.city,
            zip=model.zip,
            country=model.country
        });
    }
      public async Task<UserDetails<String>> GetUserDetails(string email)
    {
        return await _userDetailsRepository.GetUserDetails(email);
    }
    public void UpdateUserDetails(UserDetails<IFormFile> model){
        Console.WriteLine("Update invoked in service");
         byte[] imageBytes=[] ;
        using (var memoryStream = new MemoryStream())
        {
            model.profileImage.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }
     _userDetailsRepository.UpdateUserDetails(new UserDetails<String>()
        {
            _id=ObjectId.GenerateNewId(),
            profileImage = Convert.ToBase64String(imageBytes),
            userName=model.userName,
            firstName=model.firstName,
            lastName=model.lastName,
            email=model.email,
            phone=model.phone,
            address=model.address,
            city=model.city,
            zip=model.zip,
            country=model.country
        });
    }
     public void UpdateProfileImage(string userName,IFormFile profileImage){
         byte[] imageBytes=[] ;
        using (var memoryStream = new MemoryStream())
        {
            profileImage.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }
        var profileImageString=Convert.ToBase64String(imageBytes);
     _userDetailsRepository.UpdateProfileImage(userName,profileImageString);
    }
}