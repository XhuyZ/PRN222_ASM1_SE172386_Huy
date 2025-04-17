using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Entities;

[Table("Vaccine")]
public partial class Vaccine
{
    [Key]
    public int VaccineID { get; set; }

    [StringLength(100)]
    public string VaccineName { get; set; } = null!;

    [StringLength(100)]
    public string Manufacturer { get; set; } = null!;

    [StringLength(100)]
    public string Country { get; set; } = null!;

    public int DoseRequired { get; set; }

    public int? MinAge { get; set; }

    public int? MaxAge { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [InverseProperty("Vaccine")]
    public virtual ICollection<VaccinePackageDetail> VaccinePackageDetails { get; set; } = new List<VaccinePackageDetail>();
}
