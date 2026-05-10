using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("ASP_NET_USERS")]
[Index("NormalizedEmail", Name = "EMAILINDEX")]
[Index("NormalizedUserName", Name = "USERNAMEINDEX", IsUnique = true)]
public partial class AspNetUsers
{
    [Key]
    [Column("ID")]
    public string Id { get; set; } = null!;

    [Column("USER_NAME")]
    [StringLength(256)]
    public string? UserName { get; set; }

    [Column("NORMALIZED_USER_NAME")]
    [StringLength(256)]
    public string? NormalizedUserName { get; set; }

    [Column("EMAIL")]
    [StringLength(256)]
    public string? Email { get; set; }

    [Column("NORMALIZED_EMAIL")]
    [StringLength(256)]
    public string? NormalizedEmail { get; set; }

    [Column("EMAIL_CONFIRMED")]
    public bool EmailConfirmed { get; set; }

    [Column("PASSWORD_HASH")]
    public string? PasswordHash { get; set; }

    [Column("SECURITY_STAMP")]
    public string? SecurityStamp { get; set; }

    [Column("CONCURRENCY_STAMP")]
    public string? ConcurrencyStamp { get; set; }

    [Column("PHONE_NUMBER")]
    [StringLength(256)]
    public string? PhoneNumber { get; set; }

    [Column("PHONE_NUMBER_CONFIRMED")]
    public bool PhoneNumberConfirmed { get; set; }

    [Column("TWO_FACTOR_ENABLED")]
    public bool TwoFactorEnabled { get; set; }

    [Column("LOCKOUT_END")]
    [Precision(7)]
    public DateTimeOffset? LockoutEnd { get; set; }

    [Column("LOCKOUT_ENABLED")]
    public bool LockoutEnabled { get; set; }

    [Column("ACCESS_FAILED_COUNT")]
    [Precision(10)]
    public int AccessFailedCount { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; } = new List<AspNetUserClaims>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; } = new List<AspNetUserLogins>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserPasskeys> AspNetUserPasskeys { get; set; } = new List<AspNetUserPasskeys>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; } = new List<AspNetUserTokens>();

    [ForeignKey("UserId")]
    [InverseProperty("User")]
    public virtual ICollection<AspNetRoles> Role { get; set; } = new List<AspNetRoles>();
}
