using HogwartsUniversity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HogwartsUniversity.Serviсes.ServiceInterfaces
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<Student> GetStudentDetailsAsync(int? id);

        Task<SelectList> GetGroupSelectListAsync();
    }
}
