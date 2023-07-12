using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Quiz_Console
{
    internal class UserInterface
    {
        public static void WelcomeScreen()
        {

            Console.Clear();
            
            Console.Title = "Quiz - Welcome!";
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            Fullscreen();
            Console.CursorTop = windowHeight / 2 - 2;
            Console.CursorLeft = windowWidth / 2 - 15;
            Console.WriteLine("Hello and welcome to the \"Quiz\"");
            Console.CursorTop = windowHeight / 2 - 1;
            Console.CursorLeft = windowWidth / 2 - 15;
            DrawLine();
            Console.CursorTop = windowHeight / 2 + 1;
            Console.CursorLeft = windowWidth / 2 - 14;
            Console.Beep(200, 100);
            Console.Beep(400, 100);
            Console.Beep(800, 150);
            Console.Beep(200, 100);
            AnyKey();
            Console.ResetColor();
            Console.Clear();

        }

        public static int Menu()
        {
            Console.Clear();
            Console.Title = "Quiz - Main menu";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int leftMargin = windowWidth / 2 - 15;
            int menuNumber;


            //Console.CursorSize = 100;

            Fullscreen();
            Console.CursorTop = windowHeight / 2 - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine($"The \"Quiz\" menu:");
            Console.CursorLeft = leftMargin;
            DrawLine();
            Console.CursorLeft = leftMargin;
            MenuItem(1);
            Console.WriteLine(" Enter users");
            Console.CursorLeft = leftMargin;
            MenuItem(2);
            Console.WriteLine(" Enter questions");
            Console.CursorLeft = leftMargin;
            MenuItem(3);
            Console.WriteLine(" Start quiz");
            Console.CursorLeft = leftMargin;
            MenuItem(4);
            Console.WriteLine(" Credits");
            Console.CursorLeft = leftMargin;
            MenuItem(5);
            Console.WriteLine(" To welcome screen");
            Console.CursorLeft = leftMargin;
            MenuItem(6);
            Console.WriteLine(" Exit");
            Console.CursorLeft = leftMargin;
            DrawLine();
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Enter menu number: ");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                menuNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                return 0;
            }
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.ResetColor();
            Console.Clear();
            return menuNumber;
        }

        public static void Credits()
        {
            Console.Clear();
            Console.Title = "Quiz - Credits";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int heightCenter = windowHeight / 2;
            int leftMargin = windowWidth / 2 - 15;

            Fullscreen();
            Console.CursorTop = heightCenter - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Author is a genius :)");
            Console.CursorLeft = leftMargin;
            DrawLine();
            Console.CursorTop = heightCenter - 6;
            Console.CursorLeft = leftMargin;
            AnyKey();
            
            Console.ResetColor();
            Console.Clear();
        }

        public static void Goodbuy()
        {

            Console.Clear();
            Console.Title = "Quiz - see you soon!";
            ConsoleKeyInfo c;

            do
            {
                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;
                Console.Clear();
                Fullscreen();
                Console.CursorTop = windowHeight / 2 - 2;
                Console.CursorLeft = windowWidth / 2 - 14;
                Console.WriteLine("This was Quiz. See you soon!");
                Console.CursorTop = windowHeight / 2 - 1;
                Console.CursorLeft = windowWidth / 2 - 15;
                DrawLine();
                Console.CursorTop = windowHeight / 2 + 1;
                Console.CursorLeft = windowWidth / 2 - 13;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("press Esc key to close...");
                Console.ForegroundColor = ConsoleColor.White;
                c = Console.ReadKey(true);
            } while (c.Key != ConsoleKey.Escape);

            Console.Beep(800, 150);
            Console.Beep(400, 100);
            Console.Beep(800, 150);
            Console.Beep(400, 100);

            Console.ResetColor();
            Console.Clear();
        }

        public static void DrawLine()
        {
            string tmp = new('-', 31);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(tmp);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DrawLine(int? length)
        {
            int size;
            if (length == null)
            {
                return;
            }
            else
            {
                size = Convert.ToInt32(length);
            }

            string tmp = new('-', size);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(tmp);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MenuItem(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(number);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Fullscreen()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press <ALT + Enter> to toggle Full Screen mode");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void AnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
