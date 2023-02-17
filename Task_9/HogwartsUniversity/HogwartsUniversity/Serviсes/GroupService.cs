using HogwartsUniversity.Data;
using HogwartsUniversity.Models;
using HogwartsUniversity.Serviсes.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HogwartsUniversity.Serviсes
{
    public class GroupService : IGroupService
    {
        private readonly UniversityContext _context;

        public GroupService(UniversityContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Group entity)
        {
            await _context.Groups.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Group entity)
        {
            _context.Groups.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            var groupsList = await _context.Groups
                .AsNoTracking()
                .ToListAsync();
            return groupsList;
        }

        public async Task<Group> GetByIdAsync(int? id)
        {
            var group = await _context.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);
            return group;
        }

        public async Task<Group> GetStudentsOfGroupAsync(int? id)
        {
            var studentsOfGroup = await _context.Groups
                .Include(g => g.Students)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);
            return studentsOfGroup;
        }

        public async Task UpdateAsync(Group entity)
        {
            _context.Groups.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
