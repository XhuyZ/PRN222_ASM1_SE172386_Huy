using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Entities;

[Table("VaccinePackage")]
public partial class VaccinePackage
{
    [Key]
    public int PackageID { get; set; }

    [StringLength(100)]
    public string PackageName { get; set; } = null!;

    [StringLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public int CreatedByUserID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EffectiveFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EffectiveTo { get; set; }

    [ForeignKey("CreatedByUserID")]
    [InverseProperty("VaccinePackages")]
    public virtual System_UserAccount CreatedByUser { get; set; } = null!;

    [InverseProperty("Package")]
    public virtual ICollection<VaccinePackageDetail> VaccinePackageDetails { get; set; } = new List<VaccinePackageDetail>();
}
