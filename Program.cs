using IAS.DB.Context;
using IAS.Services;
using IAS.Services.Interfaces;
using IAS.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



UI.ConfigureConsole();
UI.Greeting();

while (true)
{
    try
    {
        Starer(args);
    }
    catch (Exception a)
    {
        Console.WriteLine(a); //todo add ui
    }
}


static void Starer(string[] args)
{
    var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddDbContext<DbDocsContext>();

                    services.AddScoped<IDocumentRepository, DocumentRepository>();
                })
                .Build();

    UI.ChooseVariants();
    int variants = Convert.ToInt32(Console.ReadLine());

    switch (variants)
    {
        case 1:
            Console.WriteLine("Started"); //todo add ui

            host.Services.GetRequiredService<IDocumentRepository>().LoadDocuments();
            break;
        case 2:
            Console.WriteLine("Started"); //todo add ui

            Indexing fullTextIndexV1 = new Indexing(host.Services.GetService<DbDocsContext>());
            fullTextIndexV1.BuildIndex();  //indexing
            break;
        case 3:

            break;
        case 4:

            break;
        case 5:

            break;
        default:
            UI.WrongChoose();
            break;
    }
}