using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Information for a course.
/// </summary>
[Table("COURSE")]
[Index("CourseNo", Name = "COURSE_UK1", IsUnique = true)]
public partial class Course
{
    [Key]
    [Column("COURSE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string CourseGuid { get; set; } = null!;

    [Column("PREREQUISITE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string? PrerequisiteGuid { get; set; }

    /// <summary>
    /// The unique ID for a course.
    /// </summary>
    [Column("COURSE_NO")]
    [Precision(8)]
    public int CourseNo { get; set; }

    /// <summary>
    /// The full name for this course.
    /// </summary>
    [Column("DESCRIPTION")]
    [StringLength(50)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    /// <summary>
    /// The dollar amount charged for enrollment in this course.
    /// </summary>
    [Column("COST", TypeName = "NUMBER(9,2)")]
    public decimal? Cost { get; set; }

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

    [InverseProperty("Prerequisite")]
    public virtual ICollection<Course> InversePrerequisite { get; set; } = new List<Course>();

    [ForeignKey("PrerequisiteGuid")]
    [InverseProperty("InversePrerequisite")]
    public virtual Course? Prerequisite { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Section> Section { get; set; } = new List<Section>();
}
