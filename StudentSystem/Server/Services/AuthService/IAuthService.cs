namespace StudentSystem.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExist(string regnum);
        Task<ServiceResponse<string>> Login(string regnum, string password);
        Task<ServiceResponse<bool>> ChangePassword(int userId,string newPassword);
    }
}
