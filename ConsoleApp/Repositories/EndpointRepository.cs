using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Models;

namespace ProjetoLandisGyr.Repositories
{
    public class EndpointRepository : BaseRepository, IEndpointRepository
    {
        public EndpointRepository()
        {
        }

        public Endpoint? GetBySerial(string serial) => endpoints.FirstOrDefault(x => x.SerialNumber.ToLower().Equals(serial.ToLower()));
    }
}
