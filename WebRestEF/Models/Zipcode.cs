using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// City, state and zip code information.
/// </summary>
[Table("ZIPCODE")]
[Index("Zip", Name = "ZIPCODE_UK1", IsUnique = true)]
public partial class Zipcode
{
    /// <summary>
    /// The zip code number, unique for a city and state.
    /// </summary>
    [Column("ZIP")]
    [StringLength(5)]
    [Unicode(false)]
    public string Zip { get; set; } = null!;

    /// <summary>
    /// The city name for this zip code.
    /// </summary>
    [Column("CITY")]
    [StringLength(25)]
    [Unicode(false)]
    public string? City { get; set; }

    /// <summary>
    /// The postal abbreviation for the US state.
    /// </summary>
    [Column("STATE")]
    [StringLength(2)]
    [Unicode(false)]
    public string? State { get; set; }

    /// <summary>
    /// Audit column - indicates user who inserted data.
    /// </summary>
    [Column("CREATED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Audit column - indicates date of insert.
    /// </summary>
    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Audit column - indicates who made last update.
    /// </summary>
    [Column("MODIFIED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    /// <summary>
    /// Audit column - date of last update.
    /// </summary>
    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [Key]
    [Column("ZIPCODE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string ZipcodeGuid { get; set; } = null!;

    [InverseProperty("Zipcode")]
    public virtual ICollection<Address> Address { get; set; } = new List<Address>();

    [InverseProperty("Zipcode")]
    public virtual ICollection<Instructor> Instructor { get; set; } = new List<Instructor>();

    [InverseProperty("Zipcode")]
    public virtual ICollection<Student> Student { get; set; } = new List<Student>();
}
