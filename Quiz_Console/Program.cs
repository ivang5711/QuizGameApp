using System.Collections;
using System.Runtime.Intrinsics.Arm;

namespace Quiz_Console
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Quiz";
            UserInterface ui;
            ui = new UserInterface();
            ui.WelcomeScreen();
            bool exitFlag = false;
            DataProcessing dp = new DataProcessing();
            ArrayList users = new();
            ArrayList quizQuestions = new();
            while (!exitFlag)
            {
                int menuNumber = ui.Menu();
                switch (menuNumber)
                {
                    // Enter users
                    case 1:
                        {
                            var a = dp.AddUsers();
                            foreach (string s in a)
                            {
                                users.Add(s);
                            }

                            Console.Clear();
                            break;
                        }

                    // Enter questions
                    case 2:
                        {
                            var a = dp.AddQuestions();
                            foreach (string s in a)
                            {
                                quizQuestions.Add(s);
                            }

                            break;
                        }

                    // Start quiz
                    case 3:
                        {
                            Console.Clear();
                            Console.Title = "Quiz";
                            int windowWidth;
                            int windowHeight;
                            int leftMargin;
                            if (users.Count > 0)
                            {
                                int user = 0;
                                for (int i = 0; i < quizQuestions.Count; i++)
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
                                    ui.DrawLine(100);
                                    Console.CursorTop = windowHeight / 2 - 3;
                                    Console.CursorLeft = leftMargin;
                                    string text = $"User {user + 1}: ";
                                    ui.PrintGrey(text);
                                    Console.WriteLine($"{users[user]}");
                                    Console.CursorLeft = leftMargin;
                                    ui.DrawLine(users[user]!.ToString()!.Length + 9);
                                    Console.WriteLine();
                                    Console.CursorLeft = leftMargin;
                                    text = $"Question {i + 1}: ";
                                    ui.PrintGrey(text);
                                    Console.WriteLine($"{quizQuestions[i]}");
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

                                    if (user < users.Count - 1)
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
                                ui.DrawLine(44);
                                Console.WriteLine();
                                Console.CursorLeft = leftMargin;
                                ui.AnyKey();
                                Console.CursorLeft = leftMargin;
                                Console.ResetColor();
                                Console.Clear();
                                break;
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
                                ui.DrawLine(message.Length);
                                Console.WriteLine();
                                Console.CursorLeft = leftMargin;
                                ui.AnyKey();
                                Console.CursorLeft = leftMargin;
                                Console.ResetColor();
                                Console.Clear();
                                break;
                            }
                        }

                    // Credits
                    case 4:
                        {
                            ui.Credits();
                            break;
                        }

                    // To welcome screen
                    case 5:
                        {
                            ui.WelcomeScreen();
                            break;
                        }

                    // Exit
                    case 6:
                        {
                            exitFlag = true;
                            break;
                        }
                }
            }

            if (dp.WriteResults() == 0)
            {

                if (args is null)
                {
                    Console.WriteLine("no arguments provided");
                }
                else
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        Console.WriteLine($"{i}: {args[i]}");
                    }
                }

                ui.AnyKey();
            }

            ui.Goodbuy();
            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}