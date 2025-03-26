using MongoDB.Driver;
namespace mDBConn.Repository;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserModel> _userCollection;

    public UserRepository()
    {
       _userCollection = new MongoClient("mongodb+srv://rama:ramasara1212@cluster0.cmbqdhn.mongodb.net/")
    .GetDatabase("EcommerceDB")
    .GetCollection<UserModel>("userCollection");

    }

    public async Task<IEnumerable<UserModel>> GetUsers()
    {
        return await _userCollection.Find(user => true).ToListAsync();
    }

    public async Task<UserModel> AddUser(UserModel user)
    {
        await _userCollection.InsertOneAsync(user);
        return user;
    }

        public async Task<UserModel> GetUser(string userName)
    {
        return await _userCollection.Find(user => user.userName == userName).FirstOrDefaultAsync();
    }

   
}