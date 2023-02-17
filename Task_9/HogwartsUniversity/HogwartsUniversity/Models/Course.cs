using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HogwartsUniversity.Models;

[Table("COURSES")]
public partial class Course
{
    [Key]
    [Column("COURSE_ID")]
    public int Id { get; set; }

    [Column("NAME"), Display(Name ="Course name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Column("DESCRIPTION")]
    public string Description { get; set; } = null!;

    [InverseProperty("Course")]
    public virtual ICollection<Group> Groups { get; } = new List<Group>();
}
