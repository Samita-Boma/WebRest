using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("EMPLOYER")]
public partial class Employer
{
    [Key]
    [Column("EMPLOYER_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmployerGuid { get; set; } = null!;

    [Column("EMPLOYER_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string EmployerName { get; set; } = null!;

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

    [InverseProperty("Employer")]
    public virtual ICollection<StudentEmployer> StudentEmployer { get; set; } = new List<StudentEmployer>();
}
