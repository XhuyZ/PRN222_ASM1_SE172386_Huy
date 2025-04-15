using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Models;

public partial class Vaccine
{
    [Key]
    public int VaccineId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? VaccineName { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Manufacturer { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? VaccineType { get; set; }

    public int? DoseRequired { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? StorageTemp { get; set; }

    public DateOnly? ApprovalDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CountryOfOrigin { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VaccineCode { get; set; }

    [Column(TypeName = "text")]
    public string? Notes { get; set; }

    [InverseProperty("Vaccine")]
    public virtual ICollection<VaccinePackageDetail> VaccinePackageDetails { get; set; } = new List<VaccinePackageDetail>();
}
