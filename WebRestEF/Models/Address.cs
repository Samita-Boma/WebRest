using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("ADDRESS")]
public partial class Address
{
    [Key]
    [Column("ADDRESS_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string AddressGuid { get; set; } = null!;

    [Column("ADDRESS1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Address1 { get; set; }

    [Column("ADDRESS2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Address2 { get; set; }

    [Column("ADDRESS3")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Address3 { get; set; }

    [Column("CITY")]
    [StringLength(30)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("ST")]
    [StringLength(2)]
    [Unicode(false)]
    public string? St { get; set; }

    [Column("ZIPCODE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string ZipcodeGuid { get; set; } = null!;

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

    [InverseProperty("Address")]
    public virtual ICollection<InstructorAddress> InstructorAddress { get; set; } = new List<InstructorAddress>();

    [InverseProperty("Address")]
    public virtual ICollection<StudentAddress> StudentAddress { get; set; } = new List<StudentAddress>();

    [ForeignKey("ZipcodeGuid")]
    [InverseProperty("Address")]
    public virtual Zipcode? Zipcode { get; set; }
}
