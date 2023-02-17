using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HogwartsUniversity.Models;

namespace HogwartsUniversity.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext (DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public DbSet<HogwartsUniversity.Models.Course> Courses { get; set; } = default!;

        public DbSet<HogwartsUniversity.Models.Student> Students { get; set; } = default!;

        public DbSet<HogwartsUniversity.Models.Group> Groups { get; set; } = default!;
    }
}
