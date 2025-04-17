using Application.Repositories.Context;
using Application.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
  public class VaccinePackageRepository
  {
    private readonly AppDbContext _context;

    public VaccinePackageRepository(AppDbContext context)
    {
      _context = context;
    }
    public async Task<VaccinePackage> CreateAsync(VaccinePackage package)
    {
      _context.VaccinePackages.Add(package);
      await _context.SaveChangesAsync();
      return package;
    }
    public async Task<VaccinePackage?> GetByIdAsync(int packageId)
    {
      return await _context.VaccinePackages
          .Include(p => p.VaccinePackageDetails)
          .Include(p => p.CreatedByUser)
          .FirstOrDefaultAsync(p => p.PackageID == packageId);
    }
    public async Task<IEnumerable<VaccinePackage>> GetAllAsync()
    {
      return await _context.VaccinePackages
          .Include(p => p.VaccinePackageDetails)
          .Include(p => p.CreatedByUser)
          .ToListAsync();
    }
    public async Task<IEnumerable<VaccinePackage>> SearchAsync(string keyword)
    {
      return await _context.VaccinePackages
          .Where(p => p.PackageName.Contains(keyword) || (p.Description != null && p.Description.Contains(keyword)))
          .Include(p => p.VaccinePackageDetails)
          .Include(p => p.CreatedByUser)
          .ToListAsync();
    }
    public async Task<bool> UpdateAsync(VaccinePackage package)
    {
      var existing = await _context.VaccinePackages.FindAsync(package.PackageID);
      if (existing == null) return false;

      existing.PackageName = package.PackageName;
      existing.Description = package.Description;
      existing.Price = package.Price;
      existing.CreatedByUserID = package.CreatedByUserID;
      existing.CreatedDate = package.CreatedDate;
      existing.EffectiveFrom = package.EffectiveFrom;
      existing.EffectiveTo = package.EffectiveTo;

      _context.VaccinePackages.Update(existing);
      await _context.SaveChangesAsync();
      return true;
    }
    public async Task<bool> DeleteAsync(int packageId)
    {
      var package = await _context.VaccinePackages.FindAsync(packageId);
      if (package == null) return false;

      _context.VaccinePackages.Remove(package);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}
