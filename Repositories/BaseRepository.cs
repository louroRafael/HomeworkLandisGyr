using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Models;

namespace ProjetoLandisGyr.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private static List<Endpoint> endpoints = new List<Endpoint>();

        public void Insert(Endpoint endpoint)
        {
            endpoints.Add(endpoint);
        }

        public void Update(string serial, SwitchState state)
        {
            var endpoint = endpoints.First(x => x.SerialNumber.ToLower().Equals(serial.ToLower()));
            endpoint.SwitchState = state;
        }

        public void Delete(Endpoint endpoint)
        {
            endpoints.Remove(endpoint);
        }

        public List<Endpoint> GetAll()
        {
            return endpoints;
        }

        public IQueryable<Endpoint> Query() => endpoints.AsQueryable();
    }
}
