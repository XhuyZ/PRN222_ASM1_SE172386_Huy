using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Entities;

[Table("VaccinePackageDetail")]
public partial class VaccinePackageDetail
{
    [Key]
    public int PackageDetailID { get; set; }

    public int PackageID { get; set; }

    public int VaccineID { get; set; }

    public int? ScheduleDay { get; set; }

    [StringLength(255)]
    public string? Instruction { get; set; }

    public int? DoseNumber { get; set; }

    [StringLength(255)]
    public string? Note { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [ForeignKey("PackageID")]
    [InverseProperty("VaccinePackageDetails")]
    public virtual VaccinePackage Package { get; set; } = null!;

    [ForeignKey("VaccineID")]
    [InverseProperty("VaccinePackageDetails")]
    public virtual Vaccine Vaccine { get; set; } = null!;
}
