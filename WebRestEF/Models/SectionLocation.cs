using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("SECTION_LOCATION")]
public partial class SectionLocation
{
    [Key]
    [Column("SECTION_LOCATION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionLocationGuid { get; set; } = null!;

    [Column("SECTION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionGuid { get; set; } = null!;

    [Column("LOCATION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string LocationGuid { get; set; } = null!;

    [Column("CREATED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("MODIFIED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("LocationGuid")]
    [InverseProperty("SectionLocation")]
    public virtual Location Location { get; set; } = null!;

    [ForeignKey("SectionGuid")]
    [InverseProperty("SectionLocation")]
    public virtual Section Section { get; set; } = null!;
}
