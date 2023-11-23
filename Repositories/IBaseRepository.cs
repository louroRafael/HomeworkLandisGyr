using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Models;

namespace ProjetoLandisGyr.Repositories
{
    public interface IBaseRepository
    {
        void Delete(Endpoint endpoint);
        List<Endpoint> GetAll();
        void Insert(Endpoint endpoint);
        void Update(string serial, SwitchState state);
    }
}