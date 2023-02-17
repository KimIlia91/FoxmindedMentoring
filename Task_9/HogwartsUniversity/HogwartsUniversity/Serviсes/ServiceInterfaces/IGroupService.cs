using HogwartsUniversity.Models;

namespace HogwartsUniversity.Serviсes.ServiceInterfaces
{
    public interface IGroupService : IBaseService<Group>
    {
        Task<Group> GetStudentsOfGroupAsync(int? id);
    }
}
