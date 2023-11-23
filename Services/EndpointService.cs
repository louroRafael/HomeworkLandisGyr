using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Models;
using ProjetoLandisGyr.Repositories;
using System.Net;
using System.Reflection;

namespace ProjetoLandisGyr.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IEndpointRepository _endpointRepository;

        public EndpointService(IEndpointRepository endpointRepository)
        {
            _endpointRepository = endpointRepository;
        }

        public void Insert(Endpoint model)
        {
            var endpoint = _endpointRepository.GetBySerial(model.SerialNumber);

            if (endpoint == null)
                _endpointRepository.Insert(model);
            else
                throw new Exception("[ERROR]: This endpoint already exists!");
        }

        public void Edit(string serial, SwitchState state)
        {
            var endpoint = _endpointRepository.GetBySerial(serial);

            if(endpoint != null)
                _endpointRepository.Update(serial, state);
            else
                throw new Exception("[ERROR]: No Endpoint Was Found!");
        }

        public void Delete(string serial) {
            var endpoint = _endpointRepository.GetBySerial(serial);

            if (endpoint != null)
                _endpointRepository.Delete(endpoint);
            else
                throw new Exception("[ERROR]: No Endpoint Was Found!");
        }

        public List<Endpoint> GetAll() 
        {
            var list = _endpointRepository.GetAll();

            if (list == null || list.Count == 0)
                throw new Exception("[ERROR]: No Endpoint Was Found!");

            return list;
        }

        public Endpoint GetBySerial(string serial)
        {
            var endpoint = _endpointRepository.GetBySerial(serial);

            if (endpoint == null)
                throw new Exception("[ERROR]: No Endpoint Was Found!");

            return endpoint;
        }

        public bool EndpointExists(string serial) => _endpointRepository.GetBySerial(serial) != null;
    }
}
