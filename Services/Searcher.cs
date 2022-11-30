using System;
namespace IAS.Services
{
	public class Searcher
	{

        public void Search(string word, IEnumerable<string> data)
        {
            int totalcount = 0;

            foreach (var item in data)
            {
                int pos = 0;

                while (true)
                {
                    pos = item.IndexOf(word, pos);
                    if (pos >= 0)
                    {
                        totalcount += 1;
                    }
                    else
                        break;
                    pos++;
                }
            }

            //todo add ui
            Console.WriteLine($"\nWord: {word}\n" +
                $"Total count: {totalcount}\n\n");
        }
    }
}

