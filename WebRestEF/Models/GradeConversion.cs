using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Converts a number grade to a letter grade.
/// </summary>
[Table("GRADE_CONVERSION")]
[Index("LetterGrade", Name = "GRADE_CONVERSION_UK1", IsUnique = true)]
public partial class GradeConversion
{
    [Key]
    [Column("GRADE_CONVERSION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeConversionGuid { get; set; } = null!;

    /// <summary>
    /// The unique grade as a letter (A, A-, B, B+, etc.).
    /// </summary>
    [Column("LETTER_GRADE")]
    [StringLength(2)]
    [Unicode(false)]
    public string LetterGrade { get; set; } = null!;

    /// <summary>
    /// The number grade on a scale from 0 (F) to 4 (A).
    /// </summary>
    [Column("GRADE_POINT", TypeName = "NUMBER(3,2)")]
    public decimal GradePoint { get; set; }

    /// <summary>
    /// The highest grade number which makes this letter grade.
    /// </summary>
    [Column("MAX_GRADE")]
    [Precision(3)]
    public byte MaxGrade { get; set; }

    /// <summary>
    /// The lowest grade number which makes this letter grade.
    /// </summary>
    [Column("MIN_GRADE")]
    [Precision(3)]
    public byte MinGrade { get; set; }

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
}
