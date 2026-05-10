using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// The individual grades a student received for a particular section(class).
/// </summary>
[Table("GRADE")]
public partial class Grade
{
    [Key]
    [Column("GRADE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeGuid { get; set; } = null!;

    [Column("STUDENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentGuid { get; set; } = null!;

    [Column("SECTION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionGuid { get; set; } = null!;

    [Column("GRADE_TYPE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeGuid { get; set; } = null!;

    /// <summary>
    /// The sequence number of one grade type for one section. For example, there could be multiple assignments numbered 1, 2, 3, etc.
    /// </summary>
    [Column("GRADE_CODE_OCCURRENCE", TypeName = "NUMBER(38)")]
    public decimal GradeCodeOccurrence { get; set; }

    /// <summary>
    /// Numeric grade value, (e.g. 70, 75.)
    /// </summary>
    [Column("NUMERIC_GRADE")]
    [Precision(3)]
    public byte NumericGrade { get; set; }

    /// <summary>
    /// Instructor&apos;s comments on this grade.
    /// </summary>
    [Column("COMMENTS")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Comments { get; set; }

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

    [ForeignKey("GradeTypeGuid")]
    [InverseProperty("Grade")]
    public virtual GradeType GradeType { get; set; } = null!;

    [ForeignKey("SectionGuid")]
    [InverseProperty("Grade")]
    public virtual Section Section { get; set; } = null!;

    [ForeignKey("StudentGuid")]
    [InverseProperty("Grade")]
    public virtual Student Student { get; set; } = null!;
}
