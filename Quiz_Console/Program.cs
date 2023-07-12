using System.Collections;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Quiz_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Quiz";
            UserInterface.WelcomeScreen();
            Console.Beep();
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
                            
                            int user = 0;
                            for (int i = 0; i < quizQuestions.Count; i++)
                            {
                                Console.Clear();
                                UserInterface.DrawLine();
                                Console.WriteLine($"User {user + 1}: {users[user]}");
                                UserInterface.DrawLine();
                                Console.WriteLine();
                                Console.WriteLine($"Question {i + 1}: {quizQuestions[i]}");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write(">> press a key to go to the next question >>");
                                Console.ReadKey();
                                if (user % 2 == 0)
                                {
                                    user = 1;
                                }
                                else
                                {
                                    user = 0;
                                }
                            }
                            Console.Clear();
                            UserInterface.DrawLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("That's all questions! Thank you for the Quiz");
                            Console.WriteLine();
                            Console.Write("press any key to continue...");
                            Console.ReadKey();
                            break;
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
                Console.ReadKey();
            }

            UserInterface.Goodbuy();

            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}