using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("STUDENT_EMPLOYER")]
public partial class StudentEmployer
{
    [Key]
    [Column("STUDENT_EMPLOYER_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentEmployerGuid { get; set; } = null!;

    [Column("STUDENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentGuid { get; set; } = null!;

    [Column("EMPLOYER_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmployerGuid { get; set; } = null!;

    [Column("CREATED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("MODIFIED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("EmployerGuid")]
    [InverseProperty("StudentEmployer")]
    public virtual Employer Employer { get; set; } = null!;

    [ForeignKey("StudentGuid")]
    [InverseProperty("StudentEmployer")]
    public virtual Student Student { get; set; } = null!;
}
