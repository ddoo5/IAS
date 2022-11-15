using System;
namespace IAS.UI
{
	public class UI
	{
		public static void ConfigureConsole()
		{
            Console.Title = "IAS";
        }


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


        public static void ChooseVariants()
        {
            Console.CursorVisible = false;

            Console.WriteLine("Choose variants:\n" +
                "1. Load data to databse from dictionary\n" +
                "2. Index dictionary\n" +
                "3. Analyse word\n" +
                "4. Search word(not indexed)\n" +
                "5. Search word(with index)\n");

            Console.CursorVisible = true;
        }


        public static void WrongChoose()
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("I think, i don't have this variant, try to use proposed options");

            Console.ResetColor();

            Console.CursorVisible = true;
        }


        public static void MessageAboutLoadData(int id)
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Loaded word with id: {id}");

            Console.ResetColor();

            Console.CursorVisible = true;
        }


        public static void MessageAboutIndexing(int id)
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Indexed word with id: {id}");

            Console.ResetColor();

            Console.CursorVisible = true;
        }
    }
}

