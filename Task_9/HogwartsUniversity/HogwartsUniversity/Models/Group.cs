using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HogwartsUniversity.Models;

[Table("GROUPS")]
public partial class Group
{
    [Key]
    [Column("GROUP_ID")]
    public int Id { get; set; }

    [Column("COURSE_ID")]
    [DisplayFormat(ApplyFormatInEditMode = false)]
    public int CourseId { get; set; }

    [Column("NAME"), Display(Name ="Group name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("Groups")]
    public virtual Course? Course { get; set; }

    [InverseProperty("Group")]
    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
