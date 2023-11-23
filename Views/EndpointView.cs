using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Helpers;
using ProjetoLandisGyr.Models;
using ProjetoLandisGyr.Services;
using System.Net;

namespace ProjetoLandisGyr.Views
{
    internal class EndpointView
    {
        private readonly IEndpointService _endpointService;

        public EndpointView(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public void InsertEndpoint()
        {
            try
            {
                var endpoint = new Endpoint();

                Console.Clear();
                Console.WriteLine("  ### Insert a New Endpoint ###\n\n");

                Console.Write("Endpoint Serial Number: ");
                endpoint.SerialNumber = Console.ReadLine();

                Console.WriteLine("Meter Model Id: ");
                DisplayHelper.ShowEnumOptions<ModelId>();
                endpoint.MeterModelId = (ModelId)Convert.ToInt32(Console.ReadLine());

                Console.Write("Meter Number: ");
                endpoint.MeterNumber = Convert.ToInt32(Console.ReadLine());

                Console.Write("Meter Firmware Version: ");
                endpoint.MeterFirmwareVersion = Console.ReadLine();

                Console.WriteLine("Switch State: ");
                DisplayHelper.ShowEnumOptions<SwitchState>();
                endpoint.SwitchState = (SwitchState)Convert.ToInt32(Console.ReadLine());

                _endpointService.Insert(endpoint);
            }
            catch(Exception ex)
            {
                ExceptionHelper.ShowExceptionMessage(ex);
            }
        }

        public void EditEndpoint()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("  ### Edit an Exist Endpoint ###\n\n");

                Console.Write("Input the Endpoint Serial Number: ");
                var serialNumber = Console.ReadLine();

                if (_endpointService.EndpointExists(serialNumber))
                {
                    Console.Write("Input the Switch State: ");
                    var switchState = (Enums.SwitchState)Convert.ToInt32(Console.ReadLine());

                    _endpointService.Edit(serialNumber, switchState);
                }
                else
                    throw new Exception("[ERROR]: No Endpoint Was Found!");
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowExceptionMessage(ex);
            }
        }

        public void DeleteEndpoint()
        {
            var validation = new ValidationHelper();
            try
            {
                Console.Clear();
                Console.WriteLine("  ### Delete an Exist Endpoint ###\n\n");

                Console.Write("Input the Endpoint Serial Number: ");
                var serialNumber = Console.ReadLine();

                if (_endpointService.EndpointExists(serialNumber))
                {
                    bool isValid = false;

                    while (isValid == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to delete? [Yes / No] ");

                        var strInput = Console.ReadLine()?.ToLower();

                        if (validation.IsYesOrNo(strInput))
                        {
                            isValid = true;
                            if (strInput == "yes")
                                _endpointService.Delete(serialNumber);
                        }
                        else
                        {
                            Console.WriteLine("[ERROR]: Please choose a valid option!");
                            Thread.Sleep(1500);
                        }
                    }
                }
                else
                    throw new Exception("[ERROR]: No Endpoint Was Found!");
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowExceptionMessage(ex);
            }
        }

        public void ListEndpoint()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("  ### List All Endpoints ###\n\n");

                var endpoints = _endpointService.GetAll();

                DisplayHelper.ShowTableHeader<Endpoint>();
                DisplayHelper.ShowTableBody<Endpoint>(endpoints);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowExceptionMessage(ex);
            }
        }

        public void FindEndpoint()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("  ### Find an Endpoint By Serial Number ###\n\n");

                Console.Write("Input the Endpoint Serial Number: ");
                var serialNumber = Console.ReadLine();

                Console.Clear();
                var endpoint = _endpointService.GetBySerial(serialNumber);

                DisplayHelper.ShowTableHeader<Endpoint>();
                DisplayHelper.ShowTableBody(endpoint);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowExceptionMessage(ex);
            }
        }
    }
}
