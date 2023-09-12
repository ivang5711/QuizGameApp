using ConsoleUIHelpers;
using QuizLibrary;
using System.Text;

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

        private readonly QuizUsers users = new();
        private readonly QuizQuestions questions = new();
        private readonly PrintTools printTools = new();
        private QuizUsers roundUsers = new();

        /// <summary>
        /// Prints out the welcome screen with welcome message.
        /// </summary>
        public void WelcomeScreen()
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
            Console.CursorLeft = WindowWidthCenter - 15;
            Console.WriteLine("Hello and welcome to the \"Quiz\"");
            Console.CursorTop = WindowHeightCenter - 1;
            Console.CursorLeft = WindowWidthCenter - 15;
            printTools.DrawLine();
            Console.CursorTop = WindowHeightCenter + 1;
            Console.CursorLeft = WindowWidthCenter - 14;
            printTools.HelloBeep();
            printTools.AnyKey();
            Console.ResetColor();
            Console.Clear();
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
            printTools.DrawLine();
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
            printTools.DrawLine();
            Console.WriteLine();
            Console.CursorLeft = leftMargin;
            string text = "Enter menu number: ";
            printTools.PrintGrey(text);
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
            Console.WriteLine("This app designed to automate the quiz game.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can add as many users as you want and as many questions as you want.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("You can add questions as plain text.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("The program will automatically convert it into separate questions.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Make sure each question ends with a question mark.");
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Have a nice Quiz!");
            Console.CursorLeft = leftMargin;
            printTools.DrawLine(72);
            Console.CursorTop = WindowHeightCenter - 1;
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
                printTools.DrawLine();
                Console.CursorTop = WindowHeightCenter + 1;
                Console.CursorLeft = WindowWidthCenter - 13;
                string text = "press Esc key to close...";
                printTools.PrintGrey(text);
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
            printTools.DrawLine();
            Console.CursorTop = WindowHeightCenter - (1 + users.GetUsersCount() / 2);
            Console.CursorLeft = leftMargin;
            if (users.GetUsersCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                PrintUsers();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
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
            int leftMargin = WindowWidthCenter - 15;
            if (args.Length == 0 && WriteResults() == 1)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("no arguments provided");
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                printTools.AnyKey();
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine($"{i}: {args[i]}");
                }

                Console.CursorLeft = leftMargin;
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
                    Console.Write($"User {counter}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{user}");
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
            int leftMargin = windowWidth / 2 - 15;
            if (users.GetUsersCount() != 0)
            {
                int counter = 0;
                foreach (var item in users.GetAllUsers())
                {
                    counter++;
                    Console.CursorLeft = leftMargin;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"User {counter}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{item.GetUserName()}");
                    Console.CursorLeft = (windowWidth / 2) + 2;
                    Console.WriteLine($"{item.GetWinsTotal()}");
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
            int leftMargin = windowWidth / 2 - 15;
            Console.CursorLeft = leftMargin;
            int count = 0;
            foreach (var s in questions.GetQuestions())
            {
                count++;
                Console.CursorLeft = leftMargin;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"Question {count}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{s}");
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
            int leftMargin = WindowWidthCenter - 15;
            ConsoleKeyInfo c;
            while (questionsString.Length == 0)
            {
                Console.Clear();
                printTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - (4 + questions.GetQuestions().Count / 2);
                if (questions.GetQuestionsCount() != 0)
                {
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Quiz questions");
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                }

                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Enter a question: ");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
                Console.WriteLine();
                Console.CursorLeft = leftMargin;
                c = Console.ReadKey();
                if (c.Key == ConsoleKey.Escape)
                {
                    break;
                }

                questionsString = Console.ReadLine()!.ToUpper();
                StringBuilder stringBuilder1 = new();
                stringBuilder1.Append(c.Key.ToString().ToUpper());
                stringBuilder1.Append(questionsString);
                questionsString = stringBuilder1.ToString();
                if (!string.IsNullOrEmpty(questionsString))
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    leftMargin = WindowWidthCenter - 15;
                    while (answerString.Length == 0)
                    {
                        Console.Clear();
                        printTools.Fullscreen();
                        Console.CursorTop = WindowHeightCenter - 4;
                        Console.WriteLine();
                        Console.CursorLeft = leftMargin;
                        Console.WriteLine("Enter an answer: ");
                        Console.CursorLeft = leftMargin;
                        printTools.DrawLine();
                        Console.WriteLine();
                        Console.CursorLeft = leftMargin;
                        c = Console.ReadKey();
                        if (c.Key == ConsoleKey.Escape)
                        {
                            break;
                        }

                        answerString = Console.ReadLine()!.ToUpper();
                        StringBuilder stringBuilder = new();
                        stringBuilder.Append(c.Key.ToString().ToUpper());
                        stringBuilder.Append(answerString);
                        answerString = stringBuilder.ToString();
                    }

                    questions.AddQuestionAndAnswer(questionsString.Trim(), answerString.Trim());
                    Console.Clear();
                    printTools.Fullscreen();
                    Console.CursorTop = WindowHeightCenter - (8 + questions.GetQuestionsCount() / 2);
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine("Your input recieved: ");
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.WriteLine();
                    PrintQuestions();
                    Console.WriteLine();
                    Console.CursorLeft = leftMargin;
                    printTools.DrawLine();
                    Console.CursorLeft = leftMargin;
                    string text = "Enter any key to exit... ";
                    printTools.PrintGrey(text);
                    Console.ReadKey(true);
                    break;
                }
            }

            Console.ResetColor();
            Console.Clear();
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
                ConsoleKeyInfo c;
                while (true)
                {
                    GetUsers();
                    string text = "New user's name: ";
                    printTools.PrintGrey(text);
                    c = Console.ReadKey();
                    if (c.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    string ans = Console.ReadLine()!.ToUpper();
                    ans = c.Key.ToString() + ans;
                    if (!string.IsNullOrEmpty(ans))
                    {
                        users.AddUser(ans);
                        break;
                    }
                }

                while (true)
                {
                    GetUsers();
                    string text = "Do you want to add new user?[Y/n] ";
                    printTools.PrintGrey(text);
                    c = Console.ReadKey(true);
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
        /// Prints out the quiz screen with username and corresponding question.
        /// </summary>
        public void StartQuiz()
        {
            Console.Clear();
            Console.Title = "Quiz";
            int leftMargin;
            if (users.GetUsersCount() > 0 && questions.GetQuestionsCount() > 0 && roundUsers.GetUsersCount() > 0)
            {
                int user = 0;
                for (int i = 0; i < questions.GetQuestionsCount(); i++)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    leftMargin = WindowWidthCenter - 50;
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
                    Console.CursorLeft = WindowWidthCenter - 15;
                    text = "Enter your answer: ";
                    printTools.PrintGrey(text);
                    string? input = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(input))
                    {
                        input = Console.ReadLine();
                    }

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
                        roundUsers.AddScores(user);
                    }
                    Console.WriteLine();
                    Console.CursorLeft = WindowWidthCenter - 14;
                    printTools.PrintGrey("Press any key to continue...");
                    Console.ReadKey();
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
                roundUsers = new QuizUsers();
            }
            else
            {
                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;
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
            int leftMargin = windowWidth / 2 - 15;
            printTools.Fullscreen();
            Console.CursorTop = heightCenter - 8;
            Console.CursorLeft = leftMargin;
            if (users.GetUsersCount() != 0 && questions.GetQuestionsCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("High scores:");
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
                PrintUsersWithScores();
                Console.CursorLeft = leftMargin;
                printTools.DrawLine();
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
            bool exitCode = true;

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
                return;
            }

            while (exitCode)
            {
                ConsoleKeyInfo c;
                while (true)
                {
                    GetUsers();
                    string text = "Pick a user for the game: ";
                    printTools.PrintGrey(text);
                    c = Console.ReadKey();

                    if (c.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    string ans = c.KeyChar.ToString();
                    if (!string.IsNullOrEmpty(ans) && int.TryParse(ans, out int _))
                    {
                        int index = Convert.ToInt32(ans) - 1;
                        roundUsers.AddUser(users.GetUserNames()[index], index);
                        Console.CursorLeft = WindowWidthCenter - 30;
                        Console.Write($"You have entered {users.GetUserNames()[index]}. Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }

                while (true)
                {
                    GetUsers();
                    string text = "Do you want to add new user?[Y/n] ";
                    printTools.PrintGrey(text);
                    c = Console.ReadKey(true);
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
        /// Saves Questions and Answers as well as Users and High Scores to corresponding CSV files
        /// </summary>
        public void SaveData()
        {
            questions.SaveQuestionsToCSV(questions);
            users.SaveToCSV(users);
        }
    }
}