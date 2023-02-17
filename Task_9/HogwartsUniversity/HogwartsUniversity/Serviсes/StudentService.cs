using HogwartsUniversity.Data;
using HogwartsUniversity.Models;
using HogwartsUniversity.Serviсes.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HogwartsUniversity.Serviсes
{
    public class StudentService : IStudentService
    {
        private readonly UniversityContext _context;

        public StudentService(UniversityContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student entity)
        {
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var studentsList = await _context.Students
                .AsNoTracking()
                .ToListAsync();
            return studentsList;
        }

        public async Task<Student> GetByIdAsync(int? id)
        {
            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            return student;
        }

        public async Task<Student> GetStudentDetailsAsync(int? id)
        {
            var studentDetails = await _context.Students
                .Include(s => s.Group)
                    .ThenInclude(g => g.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            return studentDetails;
        }

        public async Task UpdateAsync(Student entity)
        {
            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<SelectList> GetGroupSelectListAsync()
        {
            var groups = await _context.Groups
                .OrderBy(g => g.Name)
                .AsNoTracking()
                .ToListAsync();
            return new SelectList(groups, "Id", "Name");
        }
    }
}
