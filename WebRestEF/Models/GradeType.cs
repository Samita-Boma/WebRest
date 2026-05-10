using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

/// <summary>
/// Lookup table of a grade types (code) and its description.
/// </summary>
[Table("GRADE_TYPE")]
[Index("GradeTypeCode", Name = "GRADE_TYPE_UK1", IsUnique = true)]
public partial class GradeType
{
    [Key]
    [Column("GRADE_TYPE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeGuid { get; set; } = null!;

    /// <summary>
    /// The unique code which identifies a category of grade, i.e. MT, HW.
    /// </summary>
    [Column("GRADE_TYPE_CODE")]
    [StringLength(2)]
    [Unicode(false)]
    public string GradeTypeCode { get; set; } = null!;

    /// <summary>
    /// The description for this code, i.e. Midterm, Homework.
    /// </summary>
    [Column("DESCRIPTION")]
    [StringLength(50)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

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

    [InverseProperty("GradeType")]
    public virtual ICollection<Grade> Grade { get; set; } = new List<Grade>();

    [InverseProperty("GradeType")]
    public virtual ICollection<GradeTypeWeight> GradeTypeWeight { get; set; } = new List<GradeTypeWeight>();
}
