namespace Quiz_Console
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Quiz";
            Console.ResetColor();
            Console.Clear();
            UserInterface ui = new();
            ui.WelcomeScreen();
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
                            ui.StartQuiz();
                            break;
                        }

                    case 4:
                        {
                            ui.Credits();
                            break;
                        }

                    case 5:
                        {
                            ui.WelcomeScreen();
                            break;
                        }

                    case 6:
                        {
                            exitFlag = true;
                            break;
                        }
                }
            }

            ui.PrintArgs(args);
            ui.Goodbuy();
            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}