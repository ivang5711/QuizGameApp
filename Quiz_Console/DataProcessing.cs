using System.Collections;

namespace Quiz_Console
{
    public class DataProcessing
    {
        public static ArrayList Users { get; set; }
        public static ArrayList QuizQuestions { get; set; }

        readonly UserInterface dpui = new();

        static DataProcessing()
        {
            Users = new ArrayList();
            QuizQuestions = new ArrayList();
        }

        public ArrayList AddUsers()
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
                    dpui.PrintGrey(text);
                    c = Console.ReadKey();
                    if (c.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    string ans = Console.ReadLine()!.ToUpper();
                    ans = c.Key.ToString() + ans;
                    if (!string.IsNullOrEmpty(ans))
                    {
                        Users.Add(ans);
                        break;
                    }
                }

                while (true)
                {
                    GetUsers();
                    string text = "Do you want to add new user?[Y/n] ";
                    dpui.PrintGrey(text);
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
            return Users;
        }

        public ArrayList AddQuestions()
        {
            Console.Clear();
            Console.Title = "Quiz - Add questions";
            string questions = string.Empty;
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int heightCenter = windowHeight / 2;
            int leftMargin = windowWidth / 2 - 15;
            ConsoleKeyInfo c;
            while (questions.Length == 0)
            {
                Console.Clear();
                dpui.Fullscreen();
                Console.CursorTop = heightCenter - (4 + DataProcessing.QuizQuestions.Count / 2);
                if (QuizQuestions.Count != 0)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Quiz questions");
                    Console.CursorLeft = leftMargin;
                    UserInterface.DrawLine();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    UserInterface.DrawLine();
                }

                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Enter questions: ");
                Console.CursorLeft = leftMargin;
                UserInterface.DrawLine();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                c = Console.ReadKey();
                if (c.Key == ConsoleKey.Escape)
                {
                    break;
                }

                questions = Console.ReadLine()!.ToUpper();
                questions = c.Key.ToString().ToUpper() + questions;
                if (!string.IsNullOrEmpty(questions))
                {
                    string[] questionsSplitted = questions.Split('?');
                    for (int i = 0; i < questionsSplitted.Length - 1; i++)
                    {
                        string temp = string.Concat(questionsSplitted[i], "?");
                        QuizQuestions.Add(temp.Trim());
                    }

                    Console.Clear();
                    dpui.Fullscreen();
                    Console.CursorTop = heightCenter - (8 + QuizQuestions.Count / 2);
                    Console.CursorLeft = leftMargin;
                    UserInterface.DrawLine();
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Your input recieved: ");
                    Console.CursorLeft = leftMargin;
                    UserInterface.DrawLine();
                    Console.WriteLine();
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    UserInterface.DrawLine();
                    Console.CursorLeft = leftMargin;
                    string text = "Enter any key to exit... ";
                    dpui.PrintGrey(text);
                    Console.ReadKey(true);
                    break;
                }
            }

            Console.ResetColor();
            Console.Clear();
            return QuizQuestions;
        }

        public int WriteResults()
        {
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int heightCenter = windowHeight / 2;
            int leftMargin = windowWidth / 2 - 15;
            dpui.Fullscreen();
            Console.CursorTop = heightCenter - 8;
            Console.CursorLeft = leftMargin;
            if (Users.Count != 0 && QuizQuestions.Count != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Players:");
                Console.CursorLeft = leftMargin;
                UserInterface.DrawLine();
                PrintUsers();
                Console.CursorLeft = leftMargin;
                UserInterface.DrawLine();
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Questions:");
                Console.CursorLeft = leftMargin;
                UserInterface.DrawLine();
                PrintQuestions();
                UserInterface.DrawLine();
                Console.CursorLeft = leftMargin;
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public void GetUsers()
        {
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int heightCenter = windowHeight / 2;
            int leftMargin = windowWidth / 2 - 15;
            dpui.Fullscreen();
            Console.CursorTop = heightCenter - (4 + DataProcessing.Users.Count / 2);
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter users: ");
            Console.CursorLeft = leftMargin;
            UserInterface.DrawLine();
            Console.CursorTop = heightCenter - (1 + Users.Count / 2);
            Console.CursorLeft = leftMargin;
            if (Users.Count != 0)
            {
                Console.CursorLeft = leftMargin;
                PrintUsers();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                UserInterface.DrawLine();
            }

            Console.CursorLeft = leftMargin;
        }

        public static void PrintUsers()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            if (Users.Count != 0)
            {
                int counter = 0;
                foreach (var user in Users)
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

        public static void PrintQuestions()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            Console.CursorLeft = leftMargin;
            int count = 0;
            foreach (var s in QuizQuestions)
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

        public static void StartQuiz()
        {
            Console.Clear();
            Console.Title = "Quiz";
            int windowWidth;
            int windowHeight;
            int leftMargin;
            UserInterface ui = new();
            if (Users.Count > 0)
            {
                int user = 0;
                for (int i = 0; i < QuizQuestions.Count; i++)
                {
                    windowWidth = Console.WindowWidth;
                    windowHeight = Console.WindowHeight;
                    leftMargin = windowWidth / 2 - 50;
                    Console.Clear();
                    ui.Fullscreen();
                    Console.CursorTop = windowHeight / 2 - 6;
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Answer the Quiz question:");
                    Console.CursorLeft = leftMargin;
                    UserInterface.DrawLine(100);
                    Console.CursorTop = windowHeight / 2 - 3;
                    Console.CursorLeft = leftMargin;
                    string text = $"User {user + 1}: ";
                    ui.PrintGrey(text);
                    Console.WriteLine($"{Users[user]}");
                    Console.CursorLeft = leftMargin;
                    UserInterface.DrawLine(Users[user]!.ToString()!.Length + 9);
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    text = $"Question {i + 1}: ";
                    ui.PrintGrey(text);
                    Console.WriteLine($"{QuizQuestions[i]}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.CursorLeft = windowWidth / 2 - 21;
                    text = "press a key to go to the next question >>";
                    ui.PrintGrey(text);
                    Console.CursorLeft = leftMargin;
                    Console.CursorVisible = false;
                    Console.ReadKey();
                    Console.CursorVisible = true;
                    Console.CursorLeft = leftMargin;

                    if (user < Users.Count - 1)
                    {
                        user++;
                    }
                    else
                    {
                        user = 0;
                    }
                }

                windowWidth = Console.WindowWidth;
                windowHeight = Console.WindowHeight;
                leftMargin = windowWidth / 2 - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                ui.Fullscreen();
                Console.CursorTop = windowHeight / 2 - 3;
                Console.CursorLeft = windowWidth / 2 - 22;
                Console.WriteLine("That's all questions! Thank you for the Quiz");
                Console.CursorLeft = leftMargin - 7;
                UserInterface.DrawLine(44);
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                ui.AnyKey();
                Console.CursorLeft = leftMargin;
                Console.ResetColor();
                Console.Clear();
            }
            else
            {
                windowWidth = Console.WindowWidth;
                windowHeight = Console.WindowHeight;
                leftMargin = windowWidth / 2 - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                ui.Fullscreen();
                Console.CursorTop = windowHeight / 2 - 3;
                string message = "Oops... You need to add at least 1 user first";
                Console.CursorLeft = (windowWidth - message.Length) / 2;
                Console.WriteLine(message);
                Console.CursorLeft = (windowWidth - message.Length) / 2;
                UserInterface.DrawLine(message.Length);
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                ui.AnyKey();
                Console.CursorLeft = leftMargin;
                Console.ResetColor();
                Console.Clear();
            }
        }

        public void PrintArgs(string[] args)
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            UserInterface ui = new();
            if (args.Length == 0 && WriteResults() == 1)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("no arguments provided");
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                ui.AnyKey();
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine($"{i}: {args[i]}");
                }

                Console.CursorLeft = leftMargin;
                ui.AnyKey();
            }
        }
    }
}
