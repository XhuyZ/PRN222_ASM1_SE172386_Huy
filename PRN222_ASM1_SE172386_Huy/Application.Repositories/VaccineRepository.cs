using Application.Repositories.Basic;
using Application.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class VaccineRepository : GenericRepository<Vaccine>
    {
        public VaccineRepository()
        {

        }
        public async Task<List<Vaccine>> GetAllAsync()
        {
            var items = _context.Vaccines.Include(c => c.VaccineId);
            return await base.GetAllAsync();
        }


    }
}

