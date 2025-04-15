using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Models;

public partial class VaccinePackageDetail
{
    [Key]
    public int Id { get; set; }

    public int? VaccineId { get; set; }

    public int? VaccinePackageID { get; set; }

    public int? PackagePrice { get; set; }

    public int? Quantity { get; set; }

    public int? Discount { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AdministrationRoute { get; set; }

    [Column(TypeName = "text")]
    public string? Notes { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BatchNumber { get; set; }

    [ForeignKey("VaccineId")]
    [InverseProperty("VaccinePackageDetails")]
    public virtual Vaccine? Vaccine { get; set; }

    [ForeignKey("VaccinePackageID")]
    [InverseProperty("VaccinePackageDetails")]
    public virtual VaccinePackage? VaccinePackage { get; set; }
}
