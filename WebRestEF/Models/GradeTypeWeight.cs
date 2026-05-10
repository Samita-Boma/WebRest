using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Information on how the final grade for a particular section is computed.  For example, the midterm constitutes 50%, the quiz 10% and the final examination 40% of the final grade.
/// </summary>
[Table("GRADE_TYPE_WEIGHT")]
public partial class GradeTypeWeight
{
    [Key]
    [Column("GRADE_TYPE_WEIGHT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeWeightGuid { get; set; } = null!;

    [Column("SECTION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionGuid { get; set; } = null!;

    [Column("GRADE_TYPE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeGuid { get; set; } = null!;

    /// <summary>
    /// How many of these grade types can be used in this section.  That is, there may be 3 quizzes.
    /// </summary>
    [Column("NUMBER_PER_SECTION")]
    [Precision(3)]
    public byte NumberPerSection { get; set; }

    /// <summary>
    /// The percentage this category of grade contributes to the final grade.
    /// </summary>
    [Column("PERCENT_OF_FINAL_GRADE")]
    [Precision(3)]
    public byte PercentOfFinalGrade { get; set; }

    /// <summary>
    /// Is the lowest grade in this type removed when determining the final grade? (Y/N)
    /// </summary>
    [Column("DROP_LOWEST")]
    [StringLength(1)]
    [Unicode(false)]
    public string DropLowest { get; set; } = null!;

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
    [InverseProperty("GradeTypeWeight")]
    public virtual GradeType GradeType { get; set; } = null!;

    [ForeignKey("SectionGuid")]
    [InverseProperty("GradeTypeWeight")]
    public virtual Section Section { get; set; } = null!;
}
