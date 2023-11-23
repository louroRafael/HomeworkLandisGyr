using Microsoft.Extensions.DependencyInjection;
using ProjetoLandisGyr.Repositories;
using ProjetoLandisGyr.Services;
using ProjetoLandisGyr.Views;

Console.Title = "ENERGY COMPANY - ENDPOINTS MANAGER";

var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<IEndpointService, EndpointService>();
serviceCollection.AddScoped<IEndpointRepository, EndpointRepository>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var endpointView = new EndpointView(serviceProvider.GetRequiredService<IEndpointService>());

// Loop
bool closeApp = false;
string option;

while(!closeApp) {
    MainMenuView.Menu();
    option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":
            endpointView.InsertEndpoint();
            break;
        case "2":
            endpointView.EditEndpoint();
            break;
        case "3":
            endpointView.DeleteEndpoint();
            break;
        case "4":
            endpointView.ListEndpoint();
            break;
        case "5":
            endpointView.FindEndpoint();
            break;
        case "6":
            closeApp = MainMenuView.ExitConfirmation();
            break;
        default:
            Console.WriteLine("[ERROR]: Please choose a valid option!");
            Thread.Sleep(2000);
            break;
    }
}

