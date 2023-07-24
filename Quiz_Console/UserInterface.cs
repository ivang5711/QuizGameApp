namespace Quiz_Console
{
    public class UserInterface
    {
        public void WelcomeScreen()
        {
            Console.Clear();
            Console.Title = "Quiz - Welcome!";
            if (OperatingSystem.IsWindows())
            {
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.BufferHeight = Console.LargestWindowHeight;
            }

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
            HelloBeep();
            AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        public int Menu()
        {
            Console.Clear();
            Console.Title = "Quiz - Main menu";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int leftMargin = windowWidth / 2 - 15;
            int menuNumber;
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
            Console.WriteLine(" About");
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
            string text = "Enter menu number: ";
            PrintGrey(text);
            try
            {
                menuNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                return 0;
            }

            Console.ResetColor();
            Console.Clear();
            return menuNumber;
        }

        public void Credits()
        {
            Console.Clear();
            Console.Title = "Quiz - About";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int heightCenter = windowHeight / 2;
            int leftMargin = windowWidth / 2 - 36;
            Fullscreen();
            Console.CursorTop = heightCenter - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine("This app designed to automate the quiz game.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can add as many users as you want and as many questions as you want.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can add questions as plain text.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("The program will automatically convert it into separate questions.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Make sure each question ends with a question mark.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Have a nice Quiz!");
            Console.CursorLeft = leftMargin;
            DrawLine(72);
            Console.CursorTop = heightCenter - 1;
            leftMargin = windowWidth / 2 - 15;
            Console.CursorLeft = leftMargin;
            AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        public void Goodbuy()
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
                string text = "press Esc key to close...";
                PrintGrey(text);
                c = Console.ReadKey(true);
            } while (c.Key != ConsoleKey.Escape);

            BuyBeep();
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

        public void MenuItem(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            PrintGrey(number.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Fullscreen()
        {
            string text = "Press <ALT + Enter> to toggle Full Screen mode";
            PrintGrey(text);
        }

        public void AnyKey()
        {
            string text = "Press any key to continue...";
            PrintGrey(text);
            Console.ReadKey();
        }

        public void PrintGrey(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void HelloBeep()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(200, 100);
                Console.Beep(400, 100);
                Console.Beep(800, 150);
                Console.Beep(200, 100);
            }
        }

        public void BuyBeep()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(800, 150);
                Console.Beep(400, 100);
                Console.Beep(800, 150);
                Console.Beep(400, 100);
            }
        }
    }
}
