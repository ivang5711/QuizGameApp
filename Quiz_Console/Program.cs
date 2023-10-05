using ConsoleUIHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;

namespace Quiz
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IUserInterface, ConsoleUI>();
                services.AddTransient<IUsers, Users>();
                services.AddScoped<IQuestions, Questions>();
                services.AddTransient<IQuestionWithAnswer, QuestionWithAnswer>();
                services.AddTransient<IUser, User>();
            })
            .Build();
            var userInterface = _host.Services.GetRequiredService<IUserInterface>();
            Console.Title = "Quiz";
            string modeMessage;
            if (args.Length > 0 && args[0] == "-p")
            {
                modeMessage = "Persistent mode";
                userInterface.LoadData();
            }
            else if (args.Length > 0 && args[0] == "--help")
            {
                userInterface.PrintHelp();
                return;
            }
            else
            {
                modeMessage = "To enable persistent mode and save/load your progress run this program with -p command line argument";
            }

            Console.ResetColor();
            Console.Clear();
            PrintTools.WelcomeScreen(modeMessage);
            MenuSwitch(modeMessage, userInterface);
            userInterface.PrintArgs(args);
            userInterface.Goodbuy();
            if (args.Length > 0 && args[0] == "-p")
            {
                userInterface.SaveData();
            }

            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints out menu screen and collects user input
        /// </summary>
        /// <param name="modeMessage">Takes a string parameter to print out current mode</param>
        private static void MenuSwitch(string modeMessage, IUserInterface? userInterface)
        {
            bool exitFlag = false;
            while (!exitFlag)
            {
                int menuNumber = userInterface!.Menu();
                switch (menuNumber)
                {
                    case 1:
                        {
                            userInterface.AddUsers();
                            break;
                        }

                    case 2:
                        {
                            userInterface.AddQuestions();
                            break;
                        }

                    case 3:
                        {
                            userInterface.PickUsers();
                            break;
                        }

                    case 4:
                        {
                            userInterface.StartQuiz();
                            break;
                        }

                    case 5:
                        {
                            userInterface.Credits();
                            break;
                        }

                    case 6:
                        {
                            PrintTools.WelcomeScreen(modeMessage);
                            break;
                        }

                    case 7:
                        {
                            exitFlag = true;
                            break;
                        }
                }
            }
        }
    }
}