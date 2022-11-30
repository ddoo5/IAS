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

//todo add ui
Console.WriteLine("Enter path to dictionary(remember, only .txt!)");
string path = Console.ReadLine(); //todo add protection

while (true)
{
    try
    {
        Starter(args, path);
    }
    catch (Exception a)
    {
        UI.ExceptionWriter(a);
    }
}


static void Starter(string[] args, string path)
{
    Searcher searcher = new();

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
        case 1:  //load document
            UI.Launched();

            host.Services.GetRequiredService<IDocumentRepository>().LoadDocuments(path);
            break;
        case 2:   //indexing
            UI.Launched();

            Indexing fullTextIndexV1 = new Indexing(host.Services.GetService<DbDocsContext>());
            fullTextIndexV1.BuildIndex();
            break;
        case 3:
            UI.Launched();


            break;
        case 4:
            UI.Launched();

            var documentsSet = DocumentExtractor.DocumentsSet(path).Take(10000).ToArray();

            Console.WriteLine("Enter word: ");
            string word4 = Console.ReadLine();

            searcher.Search(word4, documentsSet);
            break;
        case 5:
            UI.Launched();

            //todo add ui
            Console.WriteLine("Enter word: ");
            string word5 = Console.ReadLine();

            //todo add waiter

            IndexedSearchMethod(path, word5);

            break;
        default:
            UI.WrongChoose();
            break;
    }
}


static void IndexedSearchMethod(string path, string word)
{
    string[] documentsSet = DocumentExtractor.DocumentsSet(path).Take(10000).ToArray();
    IndexedSearcher _index = new();

    foreach (var item in documentsSet)
    {
        _index.AddStringToIndex(item);
    }

    var result = _index.Search(word);

    //todo add ui: 'word: suck \n count: 1020'
    Console.WriteLine(result.Count());
}