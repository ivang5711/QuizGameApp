using System.Collections;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Quiz_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Quiz";
            UserInterface.WelcomeScreen();
            //Console.Beep();


            //Console.Beep(100, 80);
            //Thread.Sleep(100);
            ////Console.Beep(200, 80);
            //Thread.Sleep(100);
            //Console.Beep(400, 80);
            bool exitFlag = false;
            ArrayList users = new ArrayList();
            ArrayList quizQuestions = new ArrayList();
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

                            int windowWidth = Console.WindowWidth;
                            int windowHeight = Console.WindowHeight;
                            int leftMargin = windowWidth / 2 - 15;
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
                                    Console.WriteLine($"User {user + 1}: {users[user]}");
                                    Console.CursorLeft = leftMargin;
                                    UserInterface.DrawLine(users[user].ToString().Length + 9);
                                    Console.CursorLeft = leftMargin;
                                    Console.WriteLine();
                                    Console.CursorLeft = leftMargin;
                                    Console.WriteLine($"Question {i + 1}: {quizQuestions[i]}");
                                    Console.CursorLeft = leftMargin;
                                    Console.WriteLine();
                                    Console.CursorLeft = leftMargin;
                                    Console.WriteLine();
                                    Console.CursorLeft = windowWidth / 2 - 21;
                                    Console.Write("press a key to go to the next question >>");
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
                UserInterface.AnyKey();
            }

            UserInterface.Goodbuy();

            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}