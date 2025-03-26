using System.Collections.Generic;
public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetUsers();
    Task<UserModel> AddUser(UserModel user);
    Task<UserModel> GetUser(string userName);

    
}