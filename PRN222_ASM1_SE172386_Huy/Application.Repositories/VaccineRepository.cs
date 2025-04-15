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
        public async Task<List<Vaccine>> GetVaccinesAsync()
        {
            var vaccines = await _context.Vaccines.Include(c => c.VaccineId).ToListAsync();
            return vaccines;
            // return await base.GetAllAsync();
        }

        public async Task<Vaccine> GetByIdVaccine(Guid code)
        {
            var vaccines = await _context.Vaccines
                                        .FirstOrDefaultAsync(c => c.VaccineId == code);

            return vaccines;
        }
        //search


    }
}

