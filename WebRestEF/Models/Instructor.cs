using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Profile information for an instructor.
/// </summary>
[Table("INSTRUCTOR")]
public partial class Instructor
{
    [Key]
    [Column("INSTRUCTOR_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string InstructorGuid { get; set; } = null!;

    /// <summary>
    /// This instructor&apos;s title (Mr., Ms., Dr., Rev., etc.)
    /// </summary>
    [Column("SALUTATION")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Salutation { get; set; }

    /// <summary>
    /// This instructor&apos;s first name.
    /// </summary>
    [Column("FIRST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    /// <summary>
    /// This instructor&apos;s last name
    /// </summary>
    [Column("LAST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string? LastName { get; set; }

    /// <summary>
    /// This Instructor&apos;s street address.
    /// </summary>
    [Column("STREET_ADDRESS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? StreetAddress { get; set; }

    [Column("ZIPCODE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string ZipcodeGuid { get; set; } = null!;

    /// <summary>
    /// The phone number for this instructor including area code.
    /// </summary>
    [Column("PHONE")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Phone { get; set; }

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

    [InverseProperty("Instructor")]
    public virtual ICollection<InstructorAddress> InstructorAddress { get; set; } = new List<InstructorAddress>();

    [ForeignKey("ZipcodeGuid")]
    [InverseProperty("Instructor")]
    public virtual Zipcode Zipcode { get; set; } = null!;
}
