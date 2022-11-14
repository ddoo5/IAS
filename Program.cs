using IAS.DB.Context;
using IAS.Services;
using IAS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Test(args);

static void Test(string[] args)
{
    var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddDbContext<DbDocsContext>();

                    services.AddScoped<IDocumentRepository, DocumentRepository>();
                })
                .Build();

    Indexing fullTextIndexV1 = new Indexing(host.Services.GetService<DbDocsContext>());
    fullTextIndexV1.BuildIndex();
    //host.Services.GetRequiredService<IDocumentRepository>().LoadDocuments();  //load data

}