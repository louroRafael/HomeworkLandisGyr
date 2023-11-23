using ProjetoLandisGyr.Models;

namespace ProjetoLandisGyr.Repositories
{
    public interface IEndpointRepository : IBaseRepository
    {
        Endpoint? GetBySerial(string serial);
    }
}