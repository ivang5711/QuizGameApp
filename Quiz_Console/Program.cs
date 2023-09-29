using ConsoleUIHelpers;

namespace Quiz
{
    internal static class Program
    {
        public static ModelsLibrary.IUserInterface Ui { get; set; } = new ConsoleUI();
        public static void Main(string[] args)
        {
            Console.Title = "Quiz";
            string modeMessage;
            if (args.Length > 0 && args[0] == "-p")
            {
                modeMessage = "Persistent mode";
                Ui.LoadData();
            }
            else if (args.Length > 0 && args[0] == "--help")
            {
                Ui.PrintHelp();
                return;
            }
            else
            {
                modeMessage = "To enable persistent mode and save/load your progress run this program with -p command line argument";
            }

            Console.ResetColor();
            Console.Clear();
            PrintTools.WelcomeScreen(modeMessage);
            MenuSwitch(modeMessage);
            Ui.PrintArgs(args);
            Ui.Goodbuy();
            if (args.Length > 0 && args[0] == "-p")
            {
                Ui.SaveData();
            }

            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints out menu screen and collects user input
        /// </summary>
        /// <param name="modeMessage">Takes a string parameter to print out current mode</param>
        private static void MenuSwitch(string modeMessage)
        {
            bool exitFlag = false;
            while (!exitFlag)
            {
                int menuNumber = Ui.Menu();
                switch (menuNumber)
                {
                    case 1:
                        {
                            Ui.AddUsers();
                            break;
                        }

                    case 2:
                        {
                            Ui.AddQuestions();
                            break;
                        }

                    case 3:
                        {
                            Ui.PickUsers();
                            break;
                        }

                    case 4:
                        {
                            Ui.StartQuiz();
                            break;
                        }

                    case 5:
                        {
                            Ui.Credits();
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