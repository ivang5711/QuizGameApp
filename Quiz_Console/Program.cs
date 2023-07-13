using System.Collections;

namespace Quiz_Console
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Quiz";
            UserInterface.WelcomeScreen();
            bool exitFlag = false;
            ArrayList users = new();
            ArrayList quizQuestions = new();
            while (!exitFlag)
            {
                int menuNumber = UserInterface.Menu();
                switch (menuNumber)
                {
                    // Enter users
                    case 1:
                        {
                            var a = DataProcessing.AddUsers();
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
                            var a = DataProcessing.AddQuestions();
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
                                    UserInterface.Fullscreen();
                                    Console.CursorTop = windowHeight / 2 - 6;
                                    Console.CursorLeft = leftMargin;
                                    Console.WriteLine("Answer the Quiz question:");
                                    Console.CursorLeft = leftMargin;
                                    UserInterface.DrawLine(100);
                                    Console.CursorTop = windowHeight / 2 - 3;
                                    Console.CursorLeft = leftMargin;
                                    string text = $"User {user + 1}: ";
                                    UserInterface.PrintGrey(text);
                                    Console.WriteLine($"{users[user]}");
                                    Console.CursorLeft = leftMargin;
                                    UserInterface.DrawLine(users[user]!.ToString()!.Length + 9);
                                    Console.WriteLine();
                                    Console.CursorLeft = leftMargin;
                                    text = $"Question {i + 1}: ";
                                    UserInterface.PrintGrey(text);
                                    Console.WriteLine($"{quizQuestions[i]}");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.CursorLeft = windowWidth / 2 - 21;
                                    text = "press a key to go to the next question >>";
                                    UserInterface.PrintGrey(text);
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
                                UserInterface.Fullscreen();
                                Console.CursorTop = windowHeight / 2 - 3;
                                Console.CursorLeft = windowWidth / 2 - 22;
                                Console.WriteLine("That's all questions! Thank you for the Quiz");
                                Console.CursorLeft = leftMargin - 7;
                                UserInterface.DrawLine(44);
                                Console.WriteLine();
                                Console.CursorLeft = leftMargin;
                                UserInterface.AnyKey();
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
                                UserInterface.Fullscreen();
                                Console.CursorTop = windowHeight / 2 - 3;
                                string message = "Oops... You need to add at least 1 user first";
                                Console.CursorLeft = (windowWidth - message.Length) / 2;
                                Console.WriteLine(message);
                                Console.CursorLeft = (windowWidth - message.Length) / 2;
                                UserInterface.DrawLine(message.Length);
                                Console.WriteLine();
                                Console.CursorLeft = leftMargin;
                                UserInterface.AnyKey();
                                Console.CursorLeft = leftMargin;
                                Console.ResetColor();
                                Console.Clear();
                                break;
                            }
                        }

                    // Credits
                    case 4:
                        {
                            UserInterface.Credits();
                            break;
                        }

                    // To welcome screen
                    case 5:
                        {
                            UserInterface.WelcomeScreen();
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

            if (DataProcessing.WriteResults() == 0)
            {
<<<<<<< HEAD
                //if (args is null)
                //{
                //    Console.WriteLine("no arguments provided");
                //}
                //else
                //{
                //    for (int i = 0; i < args.Length; i++)
                //    {
                //        Console.WriteLine($"{i}: {args[i]}");
                //    }
                //}
=======
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
>>>>>>> c10e864f95402334065d1a103f90b1c2fa44468f

                UserInterface.AnyKey();
            }

            UserInterface.Goodbuy();
            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}