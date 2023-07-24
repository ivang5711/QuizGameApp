namespace Quiz_Console
{
    static class Program
    {
        public static void Main(string[] args)
        {
            UserInterface ui = new();
            DataProcessing dp = new();
            Console.Title = "Quiz";
            ui.WelcomeScreen();
            bool exitFlag = false;
            while (!exitFlag)
            {
                int menuNumber = ui.Menu();
                switch (menuNumber)
                {
                    // Enter users
                    case 1:
                        {
                            dp.AddUsers();
                            break;
                        }

                    // Enter questions
                    case 2:
                        {
                            dp.AddQuestions();
                            break;
                        }

                    // Start quiz
                    case 3:
                        {
                            DataProcessing.StartQuiz();
                            break;
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

            dp.PrintArgs(args);
            ui.Goodbuy();
            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}