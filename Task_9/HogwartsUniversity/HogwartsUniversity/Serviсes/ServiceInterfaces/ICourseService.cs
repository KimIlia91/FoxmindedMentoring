using HogwartsUniversity.Models;

namespace HogwartsUniversity.Serviсes.ServiceInterfaces
{
    public interface ICourseService : IBaseService<Course>
    {
        Task<Course> GetGroupsOfCourseAsync(int? Id);
    }
}
