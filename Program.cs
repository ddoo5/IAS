using BenchmarkDotNet.Running;
using IAS;
using IAS.DB.Context;
using IAS.Services;
using IAS.Services.Interfaces;
using IAS.Tests;
using IAS.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



UI.ConfigureConsole();
UI.Greeting();

//starter method with UI
while (true)
{
    try
    {
        UI.ExamplePath();

        Console.CursorVisible = true;

        string path = Console.ReadLine();

        Console.CursorVisible = false;

        if (String.IsNullOrWhiteSpace(path))
            throw new FileNotFoundException("Your way to file is wrong\n " +
                $"Your enter: It's null ^_^ ");

        File.GetAttributes(path);

        Thread launchTask = new(new ThreadStart(UI.Launcher));

        launchTask.Start();

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
    }
    catch (Exception a)
    {
        UI.ExceptionWriter(a);
    }
}


/// <summary>
/// Main method
/// </summary>
static void Starter(string[] args, string path)
{
    //create connection with database
    var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddDbContext<DbDocsContext>();

                    services.AddScoped<IDocumentRepository, DocumentRepository>();
                })
                .Build();

    //load dictionary
    string[] documentsSet = DocumentExtractor.DocumentsSet(path).Take(10000).ToArray();

    IndexedSearcher _index = new();
    Searcher searcher = new();

    foreach (var item in documentsSet)
    {
        _index.AddStringToIndex(item);
    }


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
        case 3:  //tests
            UI.Launched();

            if (UI.GreetingInTests())
            { 
                BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new BenchmarkDotNet.Configs.DebugInProcessConfig());
                BenchmarkRunner.Run<Tests>();
            }

            Task.WaitAll();
            break;
        case 4:  //deafault searcher
            UI.Launched();

            searcher.Search(UI.AskWord(), documentsSet);
            break;
        case 5: //indexed searcher
            UI.Launched();

            string askedWord = UI.AskWord();

            var result = _index.Search(askedWord);

            Console.WriteLine($"Word: {askedWord}    Total indexed count: {result.Count()}\n");

            break;
        default:
            UI.WrongChoose();
            break;
    }
}