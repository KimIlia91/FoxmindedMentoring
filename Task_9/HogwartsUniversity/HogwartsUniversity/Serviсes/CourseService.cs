using HogwartsUniversity.Data;
using HogwartsUniversity.Models;
using HogwartsUniversity.Serviсes.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HogwartsUniversity.Serviсes
{
    public class CourseService : ICourseService
    {
        private readonly UniversityContext _context;

        public CourseService(UniversityContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Course course)
        {
            _context.Courses.Add(course);   
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courseList = await _context.Courses
                .AsNoTracking()
                .ToListAsync();
            return courseList;
        }

        public async Task<Course> GetByIdAsync(int? id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            return course;
        }

        public async Task<Course> GetGroupsOfCourseAsync(int? id)
        {
            var groupsOfCourse = await _context.Courses
                .Include(c => c.Groups)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            return groupsOfCourse;
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
