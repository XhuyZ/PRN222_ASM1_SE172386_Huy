using Application.Repositories.Basic;
using Application.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class UserAccountRepository : GenericRepository<System_UserAccount>
    {
        public UserAccountRepository() { }

        public async Task<System_UserAccount?> GetUserAccount(string userName, string password)
        {
            //// Dont check IsActive
            //// return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password);

            return await _context.System_UserAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password && u.IsActive == true);

            //// return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);            

            //// return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password && u.IsActive == true);

            //// return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.EmployeeCode == userName && u.Password == password && u.IsActive == true);
        }

        public async Task<List<System_UserAccount>> GetAllUserAccounts()
        {
            return await _context.System_UserAccounts.ToListAsync();
        }
    }
}

