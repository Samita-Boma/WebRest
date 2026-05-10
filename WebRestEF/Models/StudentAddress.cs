using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("STUDENT_ADDRESS")]
public partial class StudentAddress
{
    [Key]
    [Column("STUDENT_ADDRESS_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentAddressGuid { get; set; } = null!;

    [Column("STUDENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentGuid { get; set; } = null!;

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
    [InverseProperty("StudentAddress")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("StudentGuid")]
    [InverseProperty("StudentAddress")]
    public virtual Student Student { get; set; } = null!;
}
