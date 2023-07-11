using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Console
{
    internal class DataProcessing
    {
        static ArrayList users = new();
        static ArrayList quizQuestions = new ArrayList();

        public static ArrayList AddUsers()
        {
            Console.Title = "Quiz - Add users";
            bool exitCode = true;
            while (exitCode)
            {
                while (true)
                {
                    Console.Clear();
                    UserInterface.DrawLine();
                    Console.WriteLine("Enter users: ");
                    UserInterface.DrawLine();
                    Console.WriteLine();
                    if (users.Count != 0)
                    {
                        int counter = 0;
                        foreach (var user in users)
                        {
                            counter++;
                            Console.WriteLine($"User {counter}: {user}");
                        }

                        UserInterface.DrawLine();
                        Console.WriteLine();
                    }

                    Console.Write("New user's name: ");
                    string ans = Console.ReadLine()!.ToUpper();
                    if (!string.IsNullOrEmpty(ans))
                    {
                        users.Add(ans);
                        Console.WriteLine("User name: " + ans);

                        break;
                    }
                }

                UserInterface.DrawLine();
                while (true)
                {
                    Console.Clear();
                    UserInterface.DrawLine();
                    Console.WriteLine("Enter users: ");
                    UserInterface.DrawLine();
                    Console.WriteLine();
                    if (users.Count != 0)
                    {
                        int counter = 0;
                        foreach (var user in users)
                        {
                            counter++;
                            Console.WriteLine($"User {counter}: {user}");
                        }

                        UserInterface.DrawLine();
                        Console.WriteLine();
                    }

                    Console.Write("Do you want to add another user?[Y/n] ");
                    string ans = Console.ReadLine()!.ToUpper();
                    if (ans.Length == 0 || ans == "YES" || ans == "Y")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (ans == "NO" || ans == "N")
                    {
                        exitCode = false;
                        break;
                    }
                }
            }

            return users;
        }

        public static ArrayList AddQuestions()
        {
            Console.Title = "Quiz - Add questions";
            string questions = string.Empty;
            while (questions.Length == 0)
            {
                Console.Clear();
                UserInterface.DrawLine();
                Console.WriteLine("Enter questions: ");
                UserInterface.DrawLine();
                Console.WriteLine();
                questions = Console.ReadLine()!.ToUpper();
                if (!string.IsNullOrEmpty(questions))
                {
                    string[] questionsSplitted = questions.Split('?');
                    for (int i = 0; i < questionsSplitted.Length - 1; i++)
                    {
                        string temp = string.Concat(questionsSplitted[i], "?");
                        quizQuestions.Add(temp.Trim());
                    }
                    Console.Clear();
                    UserInterface.DrawLine();
                    Console.WriteLine("Your input recieved: ");
                    UserInterface.DrawLine();
                    Console.WriteLine();
                    int count = 0;
                    foreach (var s in quizQuestions)
                    {
                        count++;
                        Console.WriteLine($"Question {count}: {s}");
                    }
                    Console.WriteLine();
                    UserInterface.DrawLine();
                    Console.WriteLine();
                    Console.Write("Enter any key to exit... ");
                    Console.ReadKey();
                    break;
                }


            }

            return quizQuestions;
        }

        public static int WriteResults()
        {
            if (users.Count != 0 && quizQuestions.Count != 0)
            {
                Console.WriteLine();
                UserInterface.DrawLine();
                Console.WriteLine("Players:");
                UserInterface.DrawLine();

                foreach (string s in users)
                {
                    Console.WriteLine(s);
                }

                Console.WriteLine();
                UserInterface.DrawLine();
                Console.WriteLine("Questions:");
                UserInterface.DrawLine();

                foreach (string s in quizQuestions)
                {
                    Console.WriteLine(s);
                }
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
