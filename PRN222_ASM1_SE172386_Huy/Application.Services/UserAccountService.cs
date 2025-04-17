using Application.Repositories.Entities;
using Application.Repositories;

namespace Application.Services
{
    public class UserAccountService
    {
        private readonly UserAccountRepository _repository;
        public UserAccountService() => _repository = new UserAccountRepository();

        public async Task<System_UserAccount> GetUserAccount(string username, string password)
        {
            return await _repository.GetUserAccount(username, password);
        }

    }
}

