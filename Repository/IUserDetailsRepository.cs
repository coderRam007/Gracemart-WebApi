public interface IUserDetailsRepository
{
    Task<UserDetails<String>> SaveUserDetails(UserDetails<String> userDetails);
    Task<UserDetails<String>> GetUserDetails(string userName);
    void UpdateUserDetails(UserDetails<String> userDetails);
    void UpdateProfileImage(string userName, string profileImage);
}