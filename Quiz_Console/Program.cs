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
                            ui.WelcomeScreen();
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
            ui.SaveData();
            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}