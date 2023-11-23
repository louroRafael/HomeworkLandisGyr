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
                string previousInfo = "  ### Insert a New Endpoint ###\n\n";
                bool next = false;

                while (!next)
                {
                    Console.Clear();
                    Console.WriteLine(previousInfo);

                    Console.Write("Endpoint Serial Number: ");
                    var serialNumber = Console.ReadLine();

                    if(!string.IsNullOrWhiteSpace(serialNumber))
                    {
                        endpoint.SerialNumber = serialNumber;
                        previousInfo += $"Endpoint Serial Number: {endpoint.SerialNumber}";
                        next = true;
                    }
                }

                next = false;
                while (!next)
                {
                    Console.Clear();
                    Console.WriteLine(previousInfo);

                    Console.WriteLine("Meter Model Id: ");
                    DisplayHelper.ShowEnumOptions<ModelId>();
                    var modelId = Console.ReadLine();

                    if (ValidationHelper.EnumValidation<ModelId>(modelId))
                    {
                        endpoint.MeterModelId = (ModelId)Convert.ToInt32(modelId); ;
                        previousInfo += $"\nMeter Model Id: {endpoint.MeterModelId}";
                        next = true;
                    }
                }

                next = false;
                while (!next)
                {
                    Console.Clear();
                    Console.WriteLine(previousInfo);

                    Console.Write("Meter Number: ");
                    var meterNumber = Console.ReadLine();

                    if(ValidationHelper.IsNumber(meterNumber))
                    {
                        endpoint.MeterNumber = Convert.ToInt32(meterNumber);
                        previousInfo += $"\nMeter Number: {endpoint.MeterNumber}";
                        next = true;
                    }
                }

                next = false;
                while (!next)
                {
                    Console.Clear();
                    Console.WriteLine(previousInfo);

                    Console.Write("Meter Firmware Version: ");
                    var firmwareVersion = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(firmwareVersion))
                    {
                        endpoint.MeterFirmwareVersion = firmwareVersion;
                        previousInfo += $"\nMeter Firmware Version: {endpoint.MeterFirmwareVersion}";
                        next = true;
                    }
                }

                next = false;
                while (!next)
                {
                    Console.Clear();
                    Console.WriteLine(previousInfo);

                    Console.WriteLine("Switch State: ");
                    DisplayHelper.ShowEnumOptions<SwitchState>();
                    var switchState = Console.ReadLine();

                    if (ValidationHelper.EnumValidation<SwitchState>(switchState))
                    {
                        endpoint.SwitchState = (SwitchState)Convert.ToInt32(switchState);
                        previousInfo += $"\nSwitch State: {endpoint.SwitchState}";
                        next = true;
                    }
                }

                Console.WriteLine("Saving...");

                _endpointService.Insert(endpoint);

                Console.Clear();
                Console.WriteLine(previousInfo);
                Console.WriteLine("\n[Success]: Endpoint Saved Successfully!");
                Console.ReadKey(true);
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
                string previousInfo = "  ### Edit an Exist Endpoint ###\n\n";

                Console.Clear();
                Console.WriteLine(previousInfo);

                Console.Write("Input the Endpoint Serial Number: ");
                var serialNumber = Console.ReadLine();

                if (_endpointService.EndpointExists(serialNumber))
                {
                    previousInfo += $"Input the Endpoint Serial Number: {serialNumber}";
                    bool isValid = false;
                    string switchState = "";

                    while(!isValid)
                    {
                        Console.Clear();
                        Console.WriteLine(previousInfo);
                        Console.Write("Input the Switch State: ");

                        switchState = Console.ReadLine();
                        if (ValidationHelper.EnumValidation<SwitchState>(switchState))
                        {
                            previousInfo += $"\nInput the Switch State: {(SwitchState)Convert.ToInt32(switchState)}";
                            isValid = true;
                        }
                    }

                    Console.WriteLine("Saving...");

                    _endpointService.Edit(serialNumber, (SwitchState)Convert.ToInt32(switchState));

                    Console.Clear();
                    Console.WriteLine(previousInfo);
                    Console.WriteLine("\n[Success]: Endpoint Edited Successfully!");
                    Console.ReadKey(true);
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

                        if (ValidationHelper.IsYesOrNo(strInput))
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
                Console.WriteLine("  ### Find an Endpoint By Serial Number ###\n\n");
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
