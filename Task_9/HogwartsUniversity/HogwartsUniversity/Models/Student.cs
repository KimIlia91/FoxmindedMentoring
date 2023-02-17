using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HogwartsUniversity.Models;

[Table("STUDENTS")]
public partial class Student
{
    [Key]
    [Column("STUDENT_ID")]
    public int Id { get; set; }

    [Column("GROUP_ID")]
    public int GroupId { get; set; }

    [Column("FIRST_NAME"), DisplayName("First name")]
    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [Column("LAST_NAME"), DisplayName("Last name")]
    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("Students")]
    public virtual Group? Group { get; set; }
}
