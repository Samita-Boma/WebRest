using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Profile information for a student.
/// </summary>
[Table("STUDENT")]
[Index("ZipcodeGuid", Name = "STU_ZIP_FK_I")]
public partial class Student
{
    [Key]
    [Column("STUDENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentGuid { get; set; } = null!;

    /// <summary>
    /// The student&apos;s title (Ms., Mr., Dr., etc.).
    /// </summary>
    [Column("SALUTATION")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Salutation { get; set; }

    /// <summary>
    /// This student&apos;s first name.
    /// </summary>
    [Column("FIRST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    /// <summary>
    /// This student&apos;s last name.
    /// </summary>
    [Column("LAST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// The student&apos;s street address.
    /// </summary>
    [Column("STREET_ADDRESS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? StreetAddress { get; set; }

    /// <summary>
    /// The postal zip code for this student.
    /// </summary>
    [Column("ZIPCODE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string ZipcodeGuid { get; set; } = null!;

    /// <summary>
    /// The phone number for this student including area code.
    /// </summary>
    [Column("PHONE")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Phone { get; set; }

    /// <summary>
    /// The date this student registered in the program.
    /// </summary>
    [Column("REGISTRATION_DATE", TypeName = "DATE")]
    public DateTime RegistrationDate { get; set; }

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

    [InverseProperty("Student")]
    public virtual ICollection<Enrollment> Enrollment { get; set; } = new List<Enrollment>();

    [InverseProperty("Student")]
    public virtual ICollection<Grade> Grade { get; set; } = new List<Grade>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentAddress> StudentAddress { get; set; } = new List<StudentAddress>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentEmployer> StudentEmployer { get; set; } = new List<StudentEmployer>();

    [ForeignKey("ZipcodeGuid")]
    [InverseProperty("Student")]
    public virtual Zipcode Zipcode { get; set; } = null!;
}
