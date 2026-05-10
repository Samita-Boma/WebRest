using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Information for a student registered for a particular section (class).
/// </summary>
[Table("ENROLLMENT")]
public partial class Enrollment
{
    [Key]
    [Column("ENROLLMENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EnrollmentGuid { get; set; } = null!;

    [Column("STUDENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentGuid { get; set; } = null!;

    [Column("SECTION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionGuid { get; set; } = null!;

    /// <summary>
    /// The date this student registered for this section.
    /// </summary>
    [Column("ENROLL_DATE", TypeName = "DATE")]
    public DateTime EnrollDate { get; set; }

    /// <summary>
    /// The final grade given to this student for all work in this section (class).
    /// </summary>
    [Column("FINAL_GRADE")]
    [Precision(3)]
    public byte? FinalGrade { get; set; }

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

    [ForeignKey("SectionGuid")]
    [InverseProperty("Enrollment")]
    public virtual Section Section { get; set; } = null!;

    [ForeignKey("StudentGuid")]
    [InverseProperty("Enrollment")]
    public virtual Student Student { get; set; } = null!;
}
