namespace Application.Services.Interfaces;

public interface IUserAccountService
{
    Task<UserAccountService> GetUserAccount(string username, string password);
}