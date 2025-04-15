using Application.Repositories.Basic;
using Application.Repositories.Models;
namespace Application.Repositories
{
    public class UserAccountRepository : GenericRepository<System_UserAccount>
    {
        public UserAccountRepository()
        {

        }
        public async Task<System_UserAccount> GetUserAccount(string username, string password)
        {
            return await _context.System_UserAccounts.FirstOrDefault(u => u.UserName == username && u.Password == password && u.IsActive == true);

        }

    }
}

