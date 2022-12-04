using System;
using Microsoft.IdentityModel.Tokens;

namespace IAS.UI
{
    /// <summary>
    /// UI for console and a bit logic
    /// </summary>
	public class UI
	{
        /// <summary>
        /// configuring
        /// </summary>
		public static void ConfigureConsole()
		{
            Console.Title = "IAS";
            Console.CursorVisible = false;
        }


        /// <summary>
        /// Main greeting
        /// </summary>
		public static void Greeting()
		{
			Console.CursorVisible = false;

			string greeting_message = "Welcome to IAS!";
            string greeting_message2 = "Here you can index, analyse word or search it in your dictionary. What to do? Just choose variants";

			for (int i = 0; i < greeting_message.Length; i++)
			{
				Console.Write(greeting_message[i]);
				Thread.Sleep(130);
			}

			Console.WriteLine();

            for (int i = 0; i < greeting_message2.Length; i++)
            {
                Console.Write(greeting_message2[i]);
                Thread.Sleep(140);
            }

            Console.WriteLine();

            Console.CursorVisible = true;
        }


        /// <summary>
        /// Variants of methods for select 
        /// </summary>
        public static void ChooseVariants()
        {
            Console.CursorVisible = false;

            Console.WriteLine("Choose variants:\n" +
                "1. Load data to databse from dictionary\n" +
                "2. Index dictionary\n" +
                "3. Test search methods\n" +
                "4. Search word(not indexed)\n" +
                "5. Search word(with index)\n");
        }


        /// <summary>
        /// UI for wrong choice
        /// </summary>
        public static void WrongChoose()
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("I think, i don't have this variant, try to use proposed options");

            Console.ResetColor();
        }


        /// <summary>
        /// UI for loading dictionary to database
        /// </summary>
        /// <param name="id">number of word</param>
        public static void MessageAboutLoadData(int id)
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Loaded word with id: {id}");

            Console.ResetColor();
        }


        /// <summary>
        /// UI for indexing database
        /// </summary>
        /// <param name="id">number of word</param>
        public static void MessageAboutIndexing(int id)
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Indexed word with id: {id}");

            Console.ResetColor();
        }


        /// <summary>
        /// UI for display launch
        /// </summary>
        public static void Launched()
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Started");

            Console.ResetColor();
        }


        /// <summary>
        /// UI for exceptions
        /// </summary>
        /// <param name="ex">exception</param>
        public static void ExceptionWriter(Exception ex)
        {
            Console.CursorVisible = false;

            Console.Write($"\n\n You have exception, let's check it: \n");

            Console.Write("Error message: ");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"{ex.Message}\n");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Help link: ");

            Console.ResetColor();

            Console.Write($"{ex.HelpLink} \n\n");
        }


        /// <summary>
        /// UI and logic for searching word
        /// </summary>
        /// <returns>word which should find</returns>
        public static string AskWord()
        {
            Console.CursorVisible = true;

            Console.Write("Enter word: ");

            string word = Console.ReadLine();

            Console.CursorVisible = false;

            if (String.IsNullOrWhiteSpace(word))
                return null;

            return word;
        }


        /// <summary>
        /// UI for main launch and just spend time while dictionary loading
        /// </summary>
        public static void Launcher()
        {
            Console.CursorVisible = false;

            string launch = "Launching";
            string points = "...";

            for (int i = 0; i < launch.Length; i++)
            {
                Console.Write(launch[i]);
                Thread.Sleep(150);
            }

            for (int i = 0; i < points.Length; i++)
            {
                Console.Write(points[i]);
                Thread.Sleep(800);
            }

            Console.Write("\n");
        }


        /// <summary>
        /// Examples for right enter
        /// </summary>
        public static void ExamplePath()
        {
            Console.CursorVisible = false;

            Console.WriteLine("Enter path to dictionary(remember, only .txt!)");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("/Users/Developer/Desktop/homework.txt");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("/Users/Developer/Desktop/homework.pdf");

            Console.ResetColor();

            Console.Write("Your enter: ");
        }


        /// <summary>
        /// UI for benchmark test
        /// </summary>
        /// <returns>true(y) or false(n)</returns>
        /// <exception cref="ArgumentException">becomes while enter wrong</exception>
        public static bool GreetingInTests()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Welcome to test page! Full test will take around 15-30 minutes, but before you must change path in class 'Tests' on line 25, because it's technical tests ^_^.");

            Thread.Sleep(1500);

            Console.ResetColor();

            Console.WriteLine("Are you agree? Y/n");

            string agreetion = Console.ReadLine();

            if (agreetion.ToLower() == "y")
                return true;

            if (agreetion.ToLower() == "n")
                return false;

            if (agreetion.ToLower() != "y" || agreetion.ToLower() != "n")
                throw new ArgumentException("you should choice only 'y' or 'n'");
            return false;

            Console.Clear();
        }
    }
}

