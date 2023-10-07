using ConsoleUIHelpersLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;

namespace Quiz
{
    internal static class Program
    {
        private static IUserInterface? userInterface;
        private static string modeMessage = string.Empty;
        private static string[] arguments = new string[] { "" };
        public static void Main(string[] args)
        {
            arguments = args;
            IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IUserInterface, ConsoleUserInterface>();
                services.AddTransient<IUsers, Users>();
                services.AddScoped<IQuestions, Questions>();
                services.AddTransient<IQuestionWithAnswer, QuestionWithAnswer>();
                services.AddTransient<IUser, User>();
                services.AddSingleton<IMenu, Menu>();
                services.AddSingleton<IPersistentDataOperations, PersistentCsv>();
            })
            .Build();
            userInterface = _host.Services.GetRequiredService<IUserInterface>();

            if (!CheckCommandLineArgs())
            {
                Screens.WelcomeScreen(modeMessage);
                IMenu menu = _host.Services.GetRequiredService<IMenu>();
                menu.MenuSwitch(modeMessage);
                FinishQuiz();
            }

            Environment.Exit(0);
        }

        /// <summary>
        /// Checks if there are command line arguments
        /// </summary>
        /// <param name="args"></param>
        private static bool CheckCommandLineArgs()
        {
            if (arguments.Length > 0 && arguments[0] == "-p")
            {
                modeMessage = "Persistent mode";
                userInterface!.LoadData();
            }
            else if (arguments.Length > 0 && arguments[0] == "--help")
            {
                userInterface!.PrintHelp();
                return true;
            }
            else
            {
                modeMessage = "To enable persistent mode and save/load your progress run this program with -p command line argument";
            }

            return false;
        }

        /// <summary>
        /// Finishes the quiz with goodbuy message and cleanup routines
        /// </summary>
        private static void FinishQuiz()
        {
            userInterface!.PrintArgs(arguments);
            userInterface.Goodbuy();
            if (arguments.Length > 0 && arguments[0] == "-p")
            {
                userInterface.SaveData();
            }

            Console.ResetColor();
            Console.Clear();
        }
    }
}