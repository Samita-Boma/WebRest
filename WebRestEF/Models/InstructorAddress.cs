using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("INSTRUCTOR_ADDRESS")]
public partial class InstructorAddress
{
    [Key]
    [Column("INSTRUCTOR_ADDRESS_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string InstructorAddressGuid { get; set; } = null!;

    [Column("INSTRUCTOR_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string InstructorGuid { get; set; } = null!;

    [Column("ADDRESS_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string AddressGuid { get; set; } = null!;

    [Column("CREATED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("MODIFIED_BY")]
    [StringLength(40)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("AddressGuid")]
    [InverseProperty("InstructorAddress")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("InstructorGuid")]
    [InverseProperty("InstructorAddress")]
    public virtual Instructor Instructor { get; set; } = null!;
}
