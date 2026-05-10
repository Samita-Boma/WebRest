using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("ASP_NET_ROLES")]
[Index("NormalizedName", Name = "ROLENAMEINDEX", IsUnique = true)]
public partial class AspNetRoles
{
    [Key]
    [Column("ID")]
    public string Id { get; set; } = null!;

    [Column("NAME")]
    [StringLength(256)]
    public string? Name { get; set; }

    [Column("NORMALIZED_NAME")]
    [StringLength(256)]
    public string? NormalizedName { get; set; }

    [Column("CONCURRENCY_STAMP")]
    public string? ConcurrencyStamp { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaims>();

    [ForeignKey("RoleId")]
    [InverseProperty("Role")]
    public virtual ICollection<AspNetUsers> User { get; set; } = new List<AspNetUsers>();
}
