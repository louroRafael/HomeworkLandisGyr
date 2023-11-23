using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Models;

namespace ProjetoLandisGyr.Services
{
    public interface IEndpointService
    {
        void Insert(Endpoint endpoint);
        void Edit(string serial, SwitchState state);
        void Delete(string serial);
        List<Endpoint> GetAll();
        Endpoint GetBySerial(string serial);
        bool EndpointExists(string serial);
    }
}