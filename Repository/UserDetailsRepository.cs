using MongoDB.Driver;

public class UserDetailsRepository : IUserDetailsRepository
{
    
    private readonly IMongoCollection<UserDetails<String>> _userDetailsCollection;

       public UserDetailsRepository()
    {
        _userDetailsCollection = new MongoClient("mongodb+srv://rama:ramasara1212@cluster0.cmbqdhn.mongodb.net/").GetDatabase("EcommerceDB")
                            .GetCollection<UserDetails<String>>("userDetailsCollection");

    }

    public async Task<UserDetails<String>> SaveUserDetails(UserDetails<String> userDetails)
    {
        await _userDetailsCollection.InsertOneAsync(userDetails);
        return userDetails;
        
    }
    

    public async Task<UserDetails<String>> GetUserDetails(string userName)
    {
        return await _userDetailsCollection.Find(user => user.userName == userName).FirstOrDefaultAsync();
    }
     public void UpdateUserDetails(UserDetails<String> userDetails){
        Console.WriteLine("update invoked in repo");
        userDetails._id=_userDetailsCollection.Find(profiles => profiles.userName == userDetails.userName).FirstOrDefault()._id;
        _userDetailsCollection.ReplaceOne(profiles=>profiles.userName==userDetails.userName,userDetails);
    }

     public void UpdateProfileImage(string userName,string profileImage){
        var filter = Builders<UserDetails<string>>.Filter.Eq(u => u.userName, userName);
        var update = Builders<UserDetails<string>>.Update.Set(u => u.profileImage, profileImage);
        _userDetailsCollection.UpdateOneAsync(filter, update);
    }
}