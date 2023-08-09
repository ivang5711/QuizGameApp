﻿using ConsoleUIHelpers;
using QuizLibrary;

namespace Quiz_Console
{
    public class UserInterface
    {
        int WindowWidth { get; set; }
        int WindowHeight { get; set; }

        int WindowWidthCenter { get { return WindowWidth / 2; } }

        int WindowHeightCenter { get { return WindowHeight / 2; } }

        readonly QuizUsers users = new QuizUsers();
        readonly QuizQuestions questions = new QuizQuestions();
        readonly PrintTools printTools = new PrintTools();

        /// <summary>
        /// Prints out the welcome screen with welcome message.
        /// </summary>
        public void WelcomeScreen()
        {
            Console.Clear();
            Console.Title = "Quiz - Welcome!";

            if (OperatingSystem.IsWindows())
            {
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.BufferHeight = Console.LargestWindowHeight;
            }

            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;

            printTools.Fullscreen();

            Console.CursorTop = WindowHeightCenter - 2;
            Console.CursorLeft = WindowWidthCenter - 15;
            Console.WriteLine("Hello and welcome to the \"Quiz\"");
            Console.CursorTop = WindowHeightCenter - 1;
            Console.CursorLeft = WindowWidthCenter - 15;
            printTools.DrawLine();
            Console.CursorTop = WindowHeightCenter + 1;
            Console.CursorLeft = WindowWidthCenter - 14;
            printTools.HelloBeep();
            printTools.AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the menu screen with options to choose from and waits for the user input. 
        /// </summary>
        /// <returns>Returns user's menu item choice as an integer value.</returns>
        public int Menu()
        {
            Console.Clear();
            Console.Title = "Quiz - Main menu";

            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;

            int leftMargin = WindowWidthCenter - 15;
            int menuNumber;

            printTools.Fullscreen();

            Console.CursorTop = WindowHeightCenter - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine($"The \"Quiz\" menu:");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine();
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(1);
            Console.WriteLine(" Enter users");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(2);
            Console.WriteLine(" Enter questions");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(3);
            Console.WriteLine(" Start quiz");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(4);
            Console.WriteLine(" About");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(5);
            Console.WriteLine(" To welcome screen");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(6);
            Console.WriteLine(" Exit");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine();
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            string text = "Enter menu number: ";
            printTools.PrintGrey(text);
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

        /// <summary>
        /// Prints out credits page with some information about the app and authors.
        /// </summary>
        public void Credits()
        {
            Console.Clear();
            Console.Title = "Quiz - About";

            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;

            int leftMargin = WindowWidthCenter - 36;

            printTools.Fullscreen();

            Console.CursorTop = WindowHeightCenter - 8;
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
            printTools.DrawLine(72);
            Console.CursorTop = WindowHeightCenter - 1;
            leftMargin = WindowWidthCenter - 15;
            Console.CursorLeft = leftMargin;
            printTools.AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the Goodbuy screen.
        /// </summary>
        public void Goodbuy()
        {
            Console.Clear();
            Console.Title = "Quiz - see you soon!";
            ConsoleKeyInfo c;
            do
            {
                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;

                Console.Clear();
                printTools.Fullscreen();

                Console.CursorTop = WindowHeightCenter - 2;
                Console.CursorLeft = WindowWidthCenter - 14;
                Console.WriteLine("This was Quiz. See you soon!");
                Console.CursorTop = WindowHeightCenter - 1;
                Console.CursorLeft = WindowWidthCenter - 15;
                printTools.DrawLine();
                Console.CursorTop = WindowHeightCenter + 1;
                Console.CursorLeft = WindowWidthCenter - 13;
                string text = "press Esc key to close...";
                printTools.PrintGrey(text);
                c = Console.ReadKey(true);
            } while (c.Key != ConsoleKey.Escape);

            printTools.BuyBeep();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the GetUsers screen and collects user input.
        /// </summary>
        public void GetUsers()
        {
            Console.Clear();

            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;

            int leftMargin = WindowWidthCenter - 15;
            printTools.Fullscreen();

            Console.CursorTop = WindowHeightCenter - (4 + users.GetUsersCount() / 2);
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter users: ");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine();
            Console.CursorTop = WindowHeightCenter - (1 + users.GetUsersCount() / 2);
            Console.CursorLeft = leftMargin;
            if (users.GetUsersCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                PrintUsers();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
            }

            Console.CursorLeft = leftMargin;
        }

        /// <summary>
        /// Prints out the args parameters provided by the user via cli at startup (if any). Otherwise prints out "no "arguments provided" message
        /// </summary>
        /// <param name="args"></param>
        public void PrintArgs(string[] args)
        {
            WindowWidth = Console.WindowWidth;

            int leftMargin = WindowWidthCenter - 15;
            if (args.Length == 0 && WriteResults() == 1)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("no arguments provided");
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.AnyKey();
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine($"{i}: {args[i]}");
                }

                Console.CursorLeft = leftMargin;
                printTools.AnyKey();
            }
        }

        /// <summary>
        /// Prints out the list of Users with their sequence numbers.
        /// </summary>
        public void PrintUsers()
        {
            int windowWidth = Console.WindowWidth;

            int leftMargin = windowWidth / 2 - 15;
            if (users.GetUsersCount() != 0)
            {
                int counter = 0;
                foreach (var user in users.GetUsers())
                {
                    counter++;
                    Console.CursorLeft = leftMargin;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"User {counter}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{user}");
                }

                Console.CursorLeft = leftMargin;
            }
        }

        /// <summary>
        /// Prints out the list of Questions with their sequence numbers.
        /// </summary>
        public void PrintQuestions()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            Console.CursorLeft = leftMargin;
            int count = 0;
            foreach (var s in questions.GetQuestions())
            {
                count++;
                Console.CursorLeft = leftMargin;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"Question {count}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{s}");
            }

            Console.CursorLeft = leftMargin;
        }

        /// <summary>
        /// Prints out the Add questions screen and collects user's input.
        /// </summary>
        public void AddQuestions()
        {
            Console.Clear();
            Console.Title = "Quiz - Add questions";
            string questionsString = string.Empty;

            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;

            int leftMargin = WindowWidthCenter - 15;
            ConsoleKeyInfo c;
            while (questionsString.Length == 0)
            {
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - (4 + questions.GetQuestions().Count / 2);
                if (questions.GetQuestionsCount() != 0)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Quiz questions");
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                }

                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Enter questions: ");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                c = Console.ReadKey();
                if (c.Key == ConsoleKey.Escape)
                {
                    break;
                }

                questionsString = Console.ReadLine()!.ToUpper();
                questionsString = c.Key.ToString().ToUpper() + questionsString;
                if (!string.IsNullOrEmpty(questionsString))
                {
                    string[] questionsSplitted = questionsString.Split('?');
                    for (int i = 0; i < questionsSplitted.Length - 1; i++)
                    {
                        string temp = string.Concat(questionsSplitted[i], "?");
                        questions.AddQuestion(temp.Trim());
                    }

                    Console.Clear();
                    printTools.Fullscreen();
                    Console.CursorTop = WindowHeightCenter - (8 + questions.GetQuestionsCount() / 2);
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Your input recieved: ");
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.WriteLine();
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.CursorLeft = leftMargin;
                    string text = "Enter any key to exit... ";
                    printTools.PrintGrey(text);
                    Console.ReadKey(true);
                    break;
                }
            }

            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the Add User screen and collects user's input.
        /// </summary>
        public void AddUsers()
        {
            Console.Clear();
            Console.Title = "Quiz - Add users";
            bool exitCode = true;
            while (exitCode)
            {
                ConsoleKeyInfo c;
                while (true)
                {
                    GetUsers();
                    string text = "New user's name: ";
                    printTools.PrintGrey(text);
                    c = Console.ReadKey();
                    if (c.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    string ans = Console.ReadLine()!.ToUpper();
                    ans = c.Key.ToString() + ans;
                    if (!string.IsNullOrEmpty(ans))
                    {
                        users.AddUser(ans);
                        break;
                    }
                }

                while (true)
                {
                    GetUsers();
                    string text = "Do you want to add new user?[Y/n] ";
                    printTools.PrintGrey(text);
                    c = Console.ReadKey(true);
                    if (c.Key == ConsoleKey.Y || c.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (c.Key == ConsoleKey.Escape || c.Key == ConsoleKey.N)
                    {
                        exitCode = false;
                        break;
                    }
                }
            }

            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the quiz screen with username and corresponding question.
        /// </summary>
        public void StartQuiz()
        {
            Console.Clear();
            Console.Title = "Quiz";
            int leftMargin;
            if (users.GetUsersCount() > 0)
            {
                int user = 0;
                for (int i = 0; i < questions.GetQuestionsCount(); i++)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    leftMargin = WindowWidthCenter - 50;
                    Console.Clear();
                    printTools.Fullscreen();
                    Console.CursorTop = WindowHeightCenter - 6;
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Answer the Quiz question:");
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine(100);
                    Console.CursorTop = WindowHeightCenter - 3;
                    Console.CursorLeft = leftMargin;
                    string text = $"User {user + 1}: ";
                    printTools.PrintGrey(text);
                    Console.WriteLine($"{users.GetUsers()[user]}");
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine(users.GetUsers()[user]!.ToString()!.Length + 9);
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    text = $"Question {i + 1}: ";
                    printTools.PrintGrey(text);
                    Console.WriteLine($"{questions.GetQuestions()[i]}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.CursorLeft = WindowWidthCenter - 21;
                    text = "press a key to go to the next question >>";
                    printTools.PrintGrey(text);
                    Console.CursorLeft = leftMargin;
                    Console.CursorVisible = false;
                    Console.ReadKey();
                    Console.CursorVisible = true;
                    Console.CursorLeft = leftMargin;

                    if (user < users.GetUsersCount() - 1)
                    {
                        user++;
                    }
                    else
                    {
                        user = 0;
                    }
                }

                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;
                leftMargin = WindowWidthCenter - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 3;
                Console.CursorLeft = WindowWidthCenter - 22;
                Console.WriteLine("That's all questions! Thank you for the Quiz");
                Console.CursorLeft = leftMargin - 7;
                printTools.DrawLine(44);
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.AnyKey();
                Console.CursorLeft = leftMargin;
                Console.ResetColor();
                Console.Clear();
            }
            else
            {
                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;
                leftMargin = WindowWidthCenter - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 3;
                string message = "Oops... You need to add at least 1 user first";
                Console.CursorLeft = (WindowWidth - message.Length) / 2;
                Console.WriteLine(message);
                Console.CursorLeft = (WindowWidth - message.Length) / 2;
                printTools.DrawLine(message.Length);
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.AnyKey();
                Console.CursorLeft = leftMargin;
                Console.ResetColor();
                Console.Clear();
            }
        }

        public int WriteResults()
        {
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int heightCenter = windowHeight / 2;
            int leftMargin = windowWidth / 2 - 15;
            printTools.Fullscreen();
            Console.CursorTop = heightCenter - 8;
            Console.CursorLeft = leftMargin;
            if (users.GetUsersCount() != 0 && questions.GetQuestionsCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Players:");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
                PrintUsers();
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Questions:");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
                PrintQuestions();
                printTools.DrawLine();
                Console.CursorLeft = leftMargin;
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
