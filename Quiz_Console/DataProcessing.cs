using System.Collections;

namespace Quiz_Console
{
    public class DataProcessing
    {
        static readonly ArrayList users = new();
        static readonly ArrayList quizQuestions = new();
        readonly UserInterface dpui = new UserInterface();

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
                        users.Add(ans);
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
            return users;
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
                Console.CursorTop = heightCenter - (4 + quizQuestions.Count / 2);
                if (quizQuestions.Count != 0)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Quiz questions");
                    Console.CursorLeft = leftMargin;
                    dpui.DrawLine();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    dpui.DrawLine();
                }

                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Enter questions: ");
                Console.CursorLeft = leftMargin;
                dpui.DrawLine();
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
                        quizQuestions.Add(temp.Trim());
                    }

                    Console.Clear();
                    dpui.Fullscreen();
                    Console.CursorTop = heightCenter - (8 + quizQuestions.Count / 2);
                    Console.CursorLeft = leftMargin;
                    dpui.DrawLine();
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Your input recieved: ");
                    Console.CursorLeft = leftMargin;
                    dpui.DrawLine();
                    Console.WriteLine();
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    dpui.DrawLine();
                    Console.CursorLeft = leftMargin;
                    string text = "Enter any key to exit... ";
                    dpui.PrintGrey(text);
                    Console.ReadKey(true);
                    break;
                }
            }

            Console.ResetColor();
            Console.Clear();
            return quizQuestions;
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
            if (users.Count != 0 && quizQuestions.Count != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Players:");
                Console.CursorLeft = leftMargin;
                dpui.DrawLine();
                PrintUsers();
                Console.CursorLeft = leftMargin;
                dpui.DrawLine();
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Questions:");
                Console.CursorLeft = leftMargin;
                dpui.DrawLine();
                PrintQuestions();
                dpui.DrawLine();
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
            Console.CursorTop = heightCenter - (4 + users.Count / 2);
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter users: ");
            Console.CursorLeft = leftMargin;
            dpui.DrawLine();
            Console.CursorTop = heightCenter - (1 + users.Count / 2);
            Console.CursorLeft = leftMargin;
            if (users.Count != 0)
            {
                Console.CursorLeft = leftMargin;
                PrintUsers();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                dpui.DrawLine();
            }

            Console.CursorLeft = leftMargin;
        }

        public void PrintUsers()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            if (users.Count != 0)
            {
                int counter = 0;
                foreach (var user in users)
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

        public void PrintQuestions()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            Console.CursorLeft = leftMargin;
            int count = 0;
            foreach (var s in quizQuestions)
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
    }
}
