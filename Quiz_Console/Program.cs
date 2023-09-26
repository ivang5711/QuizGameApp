using ConsoleUIHelpers;

namespace Quiz_Console
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Quiz";
            PrintTools printTools = new();
            UserInterface ui = new();

            string modeMessage;
            if (args.Length > 0 && args[0] == "-p")
            {
                modeMessage = "Persistent mode";
                ui.LoadData();
            }
            else if (args.Length > 0 && args[0] == "--help")
            {
                Console.ForegroundColor = ConsoleColor.White;
                string welcomeText = "Welcome to the Quiz help page!";
                Console.WriteLine(welcomeText);
                printTools.DrawLine(welcomeText.Length);
                string helpMessage;
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    helpMessage = "The path to an application .exe file to execute.";
                }
                else
                {
                    helpMessage = "The path to an application .dll file to execute.";
                }

                printTools.PrintGrey("Usage: [path-to-application] [arguments]\n\n");
                printTools.PrintGrey("Execute application.\n\n");
                printTools.PrintGrey("path-to-application:\n\t");
                printTools.PrintGrey(helpMessage + "\n");

                Console.WriteLine();
                Console.WriteLine();
                string arguments = "Arguments:";
                Console.WriteLine(arguments);
                printTools.DrawLine(arguments.Length);
                Console.WriteLine();
                Console.Write("--help".PadRight(12));
                printTools.PrintGrey("shows \"help page\"\n");
                Console.Write("-p".PadRight(12));
                printTools.PrintGrey("allows to run the app in persistent mode, so the user data can be loaded and saved\n");
                Console.WriteLine();
                Console.WriteLine();
                printTools.DrawLine(28);
                printTools.AnyKey();
                Console.ResetColor();
                return;
            }
            else
            {
                modeMessage = "To enable persistent mode and save/load your progress run this program with -p command line argument";
            }

            Console.ResetColor();
            Console.Clear();
            ui.WelcomeScreen(modeMessage);

            bool exitFlag = false;
            while (!exitFlag)
            {
                int menuNumber = ui.Menu();
                switch (menuNumber)
                {
                    case 1:
                        {
                            ui.AddUsers();
                            break;
                        }

                    case 2:
                        {
                            ui.AddQuestions();
                            break;
                        }

                    case 3:
                        {
                            ui.PickUsers();
                            break;
                        }

                    case 4:
                        {
                            ui.StartQuiz();
                            break;
                        }

                    case 5:
                        {
                            ui.Credits();
                            break;
                        }

                    case 6:
                        {
                            ui.WelcomeScreen(modeMessage);
                            break;
                        }

                    case 7:
                        {
                            exitFlag = true;
                            break;
                        }
                }
            }

            ui.PrintArgs(args);
            ui.Goodbuy();
            if (args.Length > 0 && args[0] == "-p")
            {
                ui.SaveData();
            }

            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}