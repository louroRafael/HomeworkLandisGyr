using Moq;
using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Models;
using ProjetoLandisGyr.Repositories;
using ProjetoLandisGyr.Services;

namespace UnitTest
{
    public class EndpointTest
    {
        EndpointService _endpointService;
        Mock<IEndpointRepository> _endpointRepositoryMock;
        Endpoint endpointReturn;

        public EndpointTest()
        {
            endpointReturn = new Endpoint
            {
                SerialNumber = "1234",
                MeterModelId = ModelId.NSX1P2W,
                MeterNumber = 23,
                MeterFirmwareVersion = "v1.2",
                SwitchState = SwitchState.Connected
            };

            _endpointRepositoryMock = new Mock<IEndpointRepository>();
            _endpointRepositoryMock.Setup(x => x.GetBySerial(It.IsAny<string>()))
                                    .Returns(endpointReturn);

            _endpointService = new EndpointService(_endpointRepositoryMock.Object);
        }

        [Fact (DisplayName = "Test Get Endpoint By Serial Number")]
        public void TestGetBySerial()
        {
            var endpoint = _endpointService.GetBySerial("1234");

            Assert.Equal(endpointReturn, endpoint);
        }
    }
}
