using ModelsLibrary;

namespace ConsoleUIHelpersLibrary
{
    public class Menu : IMenu
    {
        private readonly IUserInterface userInterface;

        public Menu(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        /// <summary>
        /// Prints out menu screen and collects user input
        /// </summary>
        public void MenuSwitch(string message)
        {
            bool exitFlag = false;
            while (!exitFlag)
            {
                int menuNumber = userInterface.Menu();
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
                            Screens.WelcomeScreen(message);
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
