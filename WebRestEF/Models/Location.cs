using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("LOCATION")]
public partial class Location
{
    [Key]
    [Column("LOCATION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string LocationGuid { get; set; } = null!;

    [Column("LOCATION_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string LocationName { get; set; } = null!;

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

    [InverseProperty("Location")]
    public virtual ICollection<SectionLocation> SectionLocation { get; set; } = new List<SectionLocation>();
}
