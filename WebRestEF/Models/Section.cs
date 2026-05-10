using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Information for an individual section (class) of a particular course.
/// </summary>
[Table("SECTION")]
public partial class Section
{
    [Key]
    [Column("SECTION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionGuid { get; set; } = null!;

    [Column("COURSE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string CourseGuid { get; set; } = null!;

    /// <summary>
    /// The individual section number within this course.
    /// </summary>
    [Column("SECTION_NO")]
    [Precision(3)]
    public byte SectionNo { get; set; }

    /// <summary>
    /// The date and time on which this section meets.
    /// </summary>
    [Column("START_DATE_TIME", TypeName = "DATE")]
    public DateTime? StartDateTime { get; set; }

    /// <summary>
    /// The ID number of the instructor who teaches this section.
    /// </summary>
    [Column("INSTRUCTOR_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string InstructorGuid { get; set; } = null!;

    /// <summary>
    /// The maximum number of students allowed in this section.
    /// </summary>
    [Column("CAPACITY")]
    [Precision(3)]
    public byte? Capacity { get; set; }

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

    [ForeignKey("CourseGuid")]
    [InverseProperty("Section")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Section")]
    public virtual ICollection<Enrollment> Enrollment { get; set; } = new List<Enrollment>();

    [InverseProperty("Section")]
    public virtual ICollection<Grade> Grade { get; set; } = new List<Grade>();

    [InverseProperty("Section")]
    public virtual ICollection<GradeTypeWeight> GradeTypeWeight { get; set; } = new List<GradeTypeWeight>();

    [InverseProperty("Section")]
    public virtual ICollection<SectionLocation> SectionLocation { get; set; } = new List<SectionLocation>();
}
