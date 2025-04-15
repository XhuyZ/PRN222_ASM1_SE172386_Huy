using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Models;

public partial class VaccinePackage
{
    [Key]
    public int VaccinePackageID { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? PackageName { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? PackageDescription { get; set; }

    public int? PackageStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PackageCode { get; set; }

    public int? PackageLevel { get; set; }

    [InverseProperty("VaccinePackage")]
    public virtual ICollection<VaccinePackageDetail> VaccinePackageDetails { get; set; } = new List<VaccinePackageDetail>();
}
