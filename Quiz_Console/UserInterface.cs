using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Console
{
    internal class UserInterface
    {
        public static void WelcomeScreen()
        {
            Console.Title = "Quiz - Welcome!";
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            Console.Clear();
            Console.WriteLine("Press <ALT + Enter> to toggle Full Screen mode");
            Console.CursorTop = windowHeight / 2 - 2;
            Console.CursorLeft = windowWidth / 2 - 15;
            Console.WriteLine("Hello and welcome to the \"Quiz\"");
            Console.CursorTop = windowHeight / 2 - 1;
            Console.CursorLeft = windowWidth / 2 - 15;
            DrawLine();
            Console.CursorTop = windowHeight / 2 + 1;
            Console.CursorLeft = windowWidth / 2 - 14;
            Console.Write("Print any key to continue...");
            Console.ReadKey();

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
            

            Console.CursorTop = windowHeight / 2 - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine($"The \"Quiz2\" menu:");
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
            Console.Write("enter a menu number: ");
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
            Console.Clear();
            return menuNumber;
        }

        public static void Credits()
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            Console.Title = "Quiz - Credits";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            Console.CursorTop = windowHeight / 2 - 2;
            Console.CursorLeft = windowWidth / 2 - 11;
            Console.WriteLine("Author is a genius :)");
            Console.CursorTop = windowHeight / 2;
            Console.CursorLeft = windowWidth / 2 - 13;
            Console.Write("press any key to agree...");
            Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void Goodbuy()
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Quiz - see you soon!";
            Console.WriteLine("Press <ALT + Enter> to toggle Full Screen mode");
            Console.CursorTop = windowHeight / 2 - 2;
            Console.CursorLeft = windowWidth / 2 - 7;
            Console.WriteLine("See you soon!");
            Console.CursorTop = windowHeight / 2 - 1;
            Console.CursorLeft = windowWidth / 2 - 15;
            DrawLine();
            Console.CursorTop = windowHeight / 2 + 1;
            Console.CursorLeft = windowWidth / 2 - 13;
            Console.Write("press any key to close...");

            
        }

        public static void DrawLine()
        {

            string tmp = new('-', 31);
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
    }
}
