using ConsoleUIHelpers;
using QuizLibrary;

namespace Quiz_Console
{
    public class UserInterface
    {
        private int WindowWidth { get; set; }
        private int WindowHeight { get; set; }
        private int WindowWidthCenter
        { get { return WindowWidth / 2; } }
        private int WindowHeightCenter
        { get { return WindowHeight / 2; } }
        private readonly Users users = new();
        private readonly Questions questions = new();
        private readonly PrintTools printTools = new();
        private Users roundUsers = new();

        /// <summary>
        /// Prints out the welcome screen with welcome message.
        /// </summary>
        public void WelcomeScreen(string message)
        {
            Console.Clear();
            Console.Title = "Quiz - Welcome!";
            if (OperatingSystem.IsWindows())
            {
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.BufferHeight = Console.LargestWindowHeight;
            }

            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - 2;
            string welcome = "Hello and welcome to the \"Quiz\"";
            int leftMargin = WindowWidthCenter - welcome.Length / 2;
            Console.CursorLeft = leftMargin;
            Console.WriteLine(welcome);
            Console.CursorTop = WindowHeightCenter - 1;
            if (message.Length > welcome.Length)
            {
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(message.Length);
            }
            else
            {
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(30);
            }

            Console.CursorLeft = leftMargin;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.CursorTop = WindowHeightCenter + 2;
            Console.CursorLeft = leftMargin + 1;
            printTools.HelloBeep();
            printTools.AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out Help page
        /// </summary>
        public void PrintHelp()
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
        }

        /// <summary>
        /// Prints out the menu screen with options to choose from and waits for the user input.
        /// </summary>
        /// <returns>Returns user's menu item choice as an integer value.</returns>
        public int Menu()
        {
            Console.Clear();
            Console.Title = "Quiz - Main menu";
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            int leftMargin = WindowWidthCenter - 15;
            int menuNumber;
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine($"The \"Quiz\" menu:");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(31);
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(1);
            Console.WriteLine(" Enter users");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(2);
            Console.WriteLine(" Enter questions");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(3);
            Console.WriteLine(" Pick user");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(4);
            Console.WriteLine(" Start quiz");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(5);
            Console.WriteLine(" About");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(6);
            Console.WriteLine(" To welcome screen");
            Console.CursorLeft = leftMargin;
            printTools.MenuItem(7);
            Console.WriteLine(" Exit");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(31);
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            printTools.PrintGrey("Enter menu number: ");
            try
            {
                menuNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                return 0;
            }

            Console.ResetColor();
            Console.Clear();
            return menuNumber;
        }

        /// <summary>
        /// Prints out credits page with some information about the app and authors.
        /// </summary>
        public void Credits()
        {
            Console.Clear();
            Console.Title = "Quiz - About";
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            int leftMargin = WindowWidthCenter - 36;
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - 8;
            Console.CursorLeft = leftMargin;
            Console.WriteLine("This app designed to automate the quiz game.\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can add as many users and questions as you want.\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("The app defines a winner by comparing the overall score of each player.\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("To load and save your game results as well as users and questions ");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("you can use persistent mode by providing \"-p\" command line argument on start.\n\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can also get help with \"--help\" command line argument.\n\n");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Have a nice Quiz!");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(77);
            Console.CursorTop = WindowHeightCenter + 6;
            leftMargin = WindowWidthCenter - 15;
            Console.CursorLeft = leftMargin;
            printTools.AnyKey();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the Goodbuy screen.
        /// </summary>
        public void Goodbuy()
        {
            Console.Clear();
            Console.Title = "Quiz - see you soon!";
            ConsoleKeyInfo c;
            do
            {
                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 2;
                Console.CursorLeft = WindowWidthCenter - 14;
                Console.WriteLine("This was Quiz. See you soon!");
                Console.CursorTop = WindowHeightCenter - 1;
                Console.CursorLeft = WindowWidthCenter - 15;
                printTools.DrawLine(31);
                Console.CursorTop = WindowHeightCenter + 1;
                Console.CursorLeft = WindowWidthCenter - 13;
                printTools.PrintGrey("press Esc key to close...");
                c = Console.ReadKey(true);
            } while (c.Key != ConsoleKey.Escape);
            printTools.BuyBeep();
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the GetUsers screen and collects user input.
        /// </summary>
        public void GetUsers()
        {
            Console.Clear();
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            int leftMargin = WindowWidthCenter - 15;
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - (4 + users.GetUsersCount() / 2);
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter users: ");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(31);
            Console.CursorTop = WindowHeightCenter - (1 + users.GetUsersCount() / 2);
            Console.CursorLeft = leftMargin;
            if (users.GetUsersCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                PrintUsers();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(31);
            }

            Console.CursorLeft = leftMargin;
        }

        /// <summary>
        /// Prints out the args parameters provided by the user via cli at startup (if any). Otherwise prints out "no "arguments provided" message
        /// </summary>
        /// <param name="args"></param>
        public void PrintArgs(string[] args)
        {
            WindowWidth = Console.WindowWidth;
            int leftMargin = WindowWidthCenter - 21;
            if (WriteResults() == 1 && args.Length == 0)
            {
                Console.CursorLeft = WindowWidthCenter - 11;
                Console.WriteLine("No games being played");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(41);
                Console.WriteLine();
                Console.CursorLeft = WindowWidthCenter - 15;
                printTools.AnyKey();
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Command line arguments provided on start:");
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine($"{i}: {args[i]}");
                }

                Console.CursorLeft = WindowWidthCenter - 15;
                printTools.AnyKey();
            }
        }

        /// <summary>
        /// Prints out the list of Users with their sequence numbers.
        /// </summary>
        public void PrintUsers()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            if (users.GetUsersCount() != 0)
            {
                int counter = 0;
                foreach (var user in users.GetUserNames())
                {
                    counter++;
                    Console.CursorLeft = leftMargin;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"User {counter}: ".PadRight(11, '.'));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{user}".PadLeft(19, '.'));
                }

                Console.CursorLeft = leftMargin;
            }
        }

        /// <summary>
        /// Prints out the list of Users with their High Scores.
        /// </summary>
        public void PrintUsersWithScores()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 21;
            if (users.GetUsersCount() != 0)
            {
                int counter = 0;
                foreach (var item in users.GetAllUsers())
                {
                    counter++;
                    Console.CursorLeft = leftMargin;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"User {counter}".PadRight(9));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{item.GetUserName()}".PadRight(21, '.'));
                    Console.CursorLeft = (windowWidth / 2) + 2;
                    Console.WriteLine($"{item.GetWinsTotal()}".PadLeft(18, '.'));
                }

                Console.CursorLeft = leftMargin;
            }
        }

        /// <summary>
        /// Prints out the list of Questions with their sequence numbers.
        /// </summary>
        public void PrintQuestions()
        {
            int windowWidth = Console.WindowWidth;
            int length = 0;
            if (questions.GetQuestions().Count > 0)
            {
                length = questions.GetQuestions().Max()!.Length;
            }

            int leftMargin = windowWidth / 2 - (length + 14) / 2;
            Console.CursorLeft = leftMargin;
            int count = 0;

            foreach (var s in questions.GetQuestions())
            {
                count++;
                Console.CursorLeft = leftMargin;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"Question {count}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{s}".PadLeft(length + 2, '.'));
            }

            Console.CursorLeft = leftMargin;
        }

        /// <summary>
        /// Prints out the Add questions screen and collects user's input.
        /// </summary>
        public void AddQuestions()
        {
            Console.Clear();
            Console.Title = "Quiz - Add questions";
            string questionsString = string.Empty;
            string answerString = string.Empty;
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            int length = GetMaxQuestionLength();
            int leftMargin = WindowWidthCenter - (length + 14) / 2;
            while (string.IsNullOrWhiteSpace(questionsString))
            {
                AskForQuestion(length, leftMargin);
                Console.CursorLeft = leftMargin;
                questionsString = Console.ReadLine()!.ToUpper();
                if (!string.IsNullOrWhiteSpace(questionsString))
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    while (string.IsNullOrWhiteSpace(answerString))
                    {
                        AskForAnswer(length, leftMargin);
                        answerString = Console.ReadLine()!.ToUpper();
                        if (string.IsNullOrWhiteSpace(answerString) && EnterAtLeastSomething(leftMargin))
                        {
                            break;
                        }
                    }

                    if (questionsString.Length > 0 && answerString.Length > 0)
                    {
                        questions.AddQuestionAndAnswer(questionsString.Trim(), answerString.Trim());
                        YourInputRecieved(length, leftMargin);
                        break;
                    }
                }
                else if (EnterAtLeastSomething(leftMargin))
                {
                    break;
                }
            }

            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Gers teh length of the longest question string
        /// </summary>
        /// <returns>int with the length of the string</returns>
        public int GetMaxQuestionLength()
        {
            int length = 0;
            if (questions.GetQuestions().Count > 0)
            {
                length = questions.GetQuestions()!.Max()!.Length;
            }

            return length;
        }

        /// <summary>
        /// Prints out message "Your input Recieved"
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public void YourInputRecieved(int length, int leftMargin)
        {
            length += 14;
            Console.Clear();
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - (8 + questions.GetQuestionsCount() / 2);
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(length);
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Your input recieved: ");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(length);
            Console.WriteLine();
            PrintQuestions();
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(length);
            Console.CursorLeft = leftMargin;
            printTools.PrintGrey("Enter any key to exit... ");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Asks for an answer
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public void AskForAnswer(int length, int leftMargin)
        {
            Console.Clear();
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - 4;
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter an answer: ");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(length + 14);
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
        }

        /// <summary>
        /// Asks for  a question
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public void AskForQuestion(int length, int leftMargin)
        {
            length += 14;
            Console.Clear();
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - (4 + questions.GetQuestions().Count / 2);
            if (questions.GetQuestionsCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Quiz questions");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(length);
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                PrintQuestions();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(length);
            }

            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter a question: ");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(length);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints out the Add User screen and collects user's input.
        /// </summary>
        public void AddUsers()
        {
            Console.Clear();
            Console.Title = "Quiz - Add users";
            bool exitCode = true;
            while (exitCode)
            {
                EnterUserName();
                while (true)
                {
                    GetUsers();
                    printTools.PrintGrey("Do you want to add new user?[Y/n] ");
                    ConsoleKeyInfo c = Console.ReadKey(true);
                    if (c.Key == ConsoleKey.Y || c.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (c.Key == ConsoleKey.Escape || c.Key == ConsoleKey.N)
                    {
                        exitCode = false;
                        break;
                    }
                }
            }

            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Asks for a user name
        /// </summary>
        public void EnterUserName()
        {
            int leftMargin = WindowWidthCenter - 15;
            while (true)
            {
                GetUsers();
                printTools.PrintGrey("New user's name: ");
                string input = Console.ReadLine()!.ToUpper();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    users.AddUser(input);
                    break;
                }
                else
                {
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine(30);
                    if (EnterAtLeastSomething(leftMargin))
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Prints "You need to enter at least something message"
        /// </summary>
        /// <returns>returns "true" if ESC key pressed</returns>
        public static bool EnterAtLeastSomething(int leftMargin)
        {
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You need to enter at least something");
            Console.CursorLeft = leftMargin;
            Console.Write("Press Esc to exit or Enter to try again...");
            ConsoleKeyInfo c = Console.ReadKey();
            if (c.Key == ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Prints out the quiz screen with username and corresponding question.
        /// </summary>
        public void StartQuiz()
        {
            Console.Clear();
            Console.Title = "Quiz";
            int leftMargin = WindowWidthCenter - 50;
            if (users.GetUsersCount() > 0 && questions.GetQuestionsCount() > 0 && roundUsers.GetUsersCount() > 0)
            {
                int user = 0;
                for (int i = 0; i < questions.GetQuestionsCount(); i++)
                {
                    AskQuestion(user, i);
                    ProcessAnswer(user, i);
                    Console.CursorVisible = true;
                    Console.CursorLeft = leftMargin;
                    if (user < roundUsers.GetUsersCount() - 1)
                    {
                        user++;
                    }
                    else
                    {
                        user = 0;
                    }
                }

                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;
                leftMargin = WindowWidthCenter - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 3;
                Console.CursorLeft = WindowWidthCenter - 22;
                if (roundUsers.GetWinner() >= 0)
                {
                    string winner = roundUsers.GetUserNames()[roundUsers.GetWinner()];
                    int userIndex = roundUsers.GetAllUsers()[roundUsers.GetWinner()].GetIndex();
                    users.AddWin(userIndex);
                    Console.WriteLine($"THE WINNER IS {winner}. Congrats!");
                }
                else
                {
                    Console.WriteLine("There is no winner this time. Try again");
                }

                Console.CursorLeft = WindowWidthCenter - 22;
                Console.WriteLine("That's all questions! Thank you for the Quiz");
                Console.CursorLeft = leftMargin - 7;
                printTools.DrawLine(44);
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.AnyKey();
                Console.CursorLeft = leftMargin;
                Console.ResetColor();
                Console.Clear();
                roundUsers = new Users();
            }
            else
            {
                leftMargin = WindowWidthCenter - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 3;
                string message = string.Empty;
                if (questions.GetQuestionsCount() == 0)
                {
                    message = "Oops... You need to add at least 1 question first";
                }
                else if (roundUsers.GetUsersCount() == 0)
                {
                    message = "Oops... You need to pick at least 1 user first";
                }

                PrintEnterAtLeastOneItem(message, leftMargin);
            }
        }

        /// <summary>
        /// Asks a question
        /// </summary>
        /// <param name="user">user index</param>
        /// <param name="i">question index</param>
        public void AskQuestion(int user, int i)
        {
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            int leftMargin = WindowWidthCenter - 50;
            Console.Clear();
            printTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - 6;
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Answer the Quiz question:");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(100);
            Console.CursorTop = WindowHeightCenter - 3;
            Console.CursorLeft = leftMargin;
            string text = $"User {user + 1}: ";
            printTools.PrintGrey(text);
            Console.WriteLine($"{roundUsers.GetUserNames()[user]}");
            Console.CursorLeft = leftMargin;
            string temp = roundUsers.GetScore(user).ToString();
            Console.WriteLine("Current user score is: " + temp);
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(roundUsers.GetUserNames()[user]!.ToString()!.Length + 9);
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            text = $"Question {i + 1}: ";
            printTools.PrintGrey(text);
            Console.WriteLine($"{questions.GetQuestions()[i]}");
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Gets the answer and checks if it is correct and increment score
        /// </summary>
        /// <param name="user">user index</param>
        /// <param name="i">question index</param>
        public void ProcessAnswer(int user, int i)
        {
            Console.CursorLeft = WindowWidthCenter - 15;
            printTools.PrintGrey("Enter your answer: ");
            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;
            string? input;
            do
            {
                Console.CursorLeft = left;
                Console.CursorTop = top;
                input = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(input));
            Console.CursorTop = WindowHeightCenter + 3;
            string tmp = new(' ', WindowWidth);
            Console.WriteLine(tmp);
            Console.CursorTop = WindowHeightCenter + 3;
            Console.CursorLeft = WindowWidthCenter - 9 - (input.Length / 2);
            Console.WriteLine($"Your answer is: \"{input}\"");
            bool k = questions.AnswerCheck(questions.GetQuestions()[i], input);
            Console.CursorTop = WindowHeightCenter + 4;
            Console.WriteLine(tmp);
            Console.CursorLeft = WindowWidthCenter - 3;
            Console.WriteLine(k);
            if (k)
            {
                roundUsers.AddScore(user);
            }

            Console.WriteLine();
            Console.CursorLeft = WindowWidthCenter - 14;
            printTools.PrintGrey("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints a message to ask user to enter at least 1 item
        /// </summary>
        /// <param name="message">The message to print</param>
        /// <param name="leftMargin">cursor left position</param>
        public void PrintEnterAtLeastOneItem(string message, int leftMargin)
        {
            Console.CursorLeft = (WindowWidth - message.Length) / 2;
            Console.WriteLine(message);
            Console.CursorLeft = (WindowWidth - message.Length) / 2;
            printTools.DrawLine(message.Length);
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            printTools.AnyKey();
            Console.CursorLeft = leftMargin;
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Prints out a chart with users ans highscores.
        /// </summary>
        /// <returns>returns 0 if results present and any other value otherwise.</returns>
        public int WriteResults()
        {
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int heightCenter = windowHeight / 2;
            int leftMargin = windowWidth / 2 - 21;
            printTools.Fullscreen();
            Console.CursorTop = heightCenter - 8;
            Console.CursorLeft = leftMargin;
            if (users.GetUsersCount() != 0 && questions.GetQuestionsCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("High scores:");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(41);
                PrintUsersWithScores();
                Console.CursorLeft = leftMargin;
                printTools.DrawLine(41);
                Console.CursorLeft = leftMargin;
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// Allows user to pick users for a new game round.
        /// </summary>
        public void PickUsers()
        {
            Console.Clear();
            Console.Title = "Quiz - Pick users";
            if (users.GetUsersCount() == 0)
            {
                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;
                int leftMargin = WindowWidthCenter - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 3;
                string message = "You need to add at least 1 user first... ";
                PrintEnterAtLeastOneItem(message, leftMargin);
                return;
            }

            bool exitCode = true;
            while (exitCode)
            {
                string input = string.Empty;
                PrintUsersPicked();
                printTools.PrintGrey("Pick a user for the game: ");
                input += Console.ReadLine();
                Console.CursorLeft = WindowWidthCenter - 30;
                CheckPickedUser(input);
                exitCode = AskToPickNewUser();
            }

            Console.Clear();
        }

        /// <summary>
        /// Asks to pick a user for a game
        /// </summary>
        /// <returns>returns false if "Escape" key pressed</returns>
        public bool AskToPickNewUser()
        {
            while (true)
            {
                ConsoleKeyInfo c;
                PrintUsersPicked();
                string message = "Do you want to pick a new user?[Y/n] ";
                printTools.PrintGrey(message);
                c = Console.ReadKey(true);
                if (c.Key == ConsoleKey.Y || c.Key == ConsoleKey.Enter)
                {
                    return true;
                }
                else if (c.Key == ConsoleKey.Escape || c.Key == ConsoleKey.N)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks if the user picked is correct input
        /// </summary>
        /// <param name="input"></param>
        public void CheckPickedUser(string input)
        {
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int _) && users.GetUsersCount() >= int.Parse(input) && int.Parse(input) > 0)
            {
                if (!roundUsers.GetUserNames().Contains(users.GetUserNames()[Convert.ToInt32(input) - 1]))
                {
                    int index = Convert.ToInt32(input) - 1;
                    roundUsers.AddUser(users.GetUserNames()[index], index);
                    Console.Write($"You have entered {users.GetUserNames()[index]}. ");
                }
                else
                {
                    Console.Write($"This user is already picked. Try again. ");
                }
            }
            else
            {
                Console.Write($"Incorrect input. Try again. ");
            }

            printTools.AnyKey();
        }

        /// <summary>
        /// Prints the quantity of users picked.
        /// </summary>
        public void PrintUsersPicked()
        {
            GetUsers();
            Console.CursorLeft = WindowWidthCenter - 15;
            Console.WriteLine($"Users Picked: {roundUsers.GetAllUsers().Count}");
            Console.CursorLeft = WindowWidthCenter - 15;
            printTools.DrawLine(30);
            foreach (string item in roundUsers.GetUserNames())
            {
                Console.CursorLeft = WindowWidthCenter - 15;
                Console.WriteLine(item);
            }

            Console.CursorLeft = WindowWidthCenter - 15;
            printTools.DrawLine(30);
            Console.CursorLeft = WindowWidthCenter - 15;
        }

        /// <summary>
        /// Saves Questions and Answers as well as Users and High Scores to corresponding CSV files
        /// </summary>
        public void SaveData()
        {
            questions.SaveQuestionsToCSV("questions.csv");
            users.SaveToCSV("user-score.csv");
        }

        /// <summary>
        /// Loads Questions and Answers as well as Users and High Scores from corresponding CSV files
        /// </summary>
        public void LoadData()
        {
            questions.ReadQuestionsFromCSV("questions.csv");
            users.ReadFromCSV("user-score.csv");
        }
    }
}