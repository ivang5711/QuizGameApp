using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;
using System;
using System.Linq;

namespace ConsoleUIHelpersLibrary
{
    public class ConsoleUserInterface : IUserInterface
    {
        public IHost Host { get; set; }
        private int WindowWidth { get; set; }
        private int WindowHeight { get; set; }

        private int WindowWidthCenter
        { get { return WindowWidth / 2; } }

        private int WindowHeightCenter
        { get { return WindowHeight / 2; } }

        private readonly IGameUsers users;
        private readonly IGameQuestions questions;
        private IGameUsers roundUsers;
        private readonly IPersistentDataOperations persistentDataOperations;

        public ConsoleUserInterface(IHost host)
        {
            Host = host;
            users = Host.Services.GetRequiredService<IGameUsers>();
            questions = Host.Services.GetRequiredService<IGameQuestions>();
            roundUsers = Host.Services.GetRequiredService<IGameUsers>();
            persistentDataOperations = Host.Services.GetRequiredService<IPersistentDataOperations>();
        }

        /// <summary>
        /// Prints out Welcome Screen
        /// </summary>
        /// <param name="message">Text message to print on the screen</param>
        public void WelcomeScreen(string message) => Screens.WelcomeScreen(message);

        /// <summary>
        /// Prints out Help page
        /// </summary>
        public void PrintHelp() => Screens.PrintHelp();

        /// <summary>
        /// Prints out the menu screen with options to choose from and waits for the user input.
        /// </summary>
        /// <returns>Returns user's menu item choice as an integer value.</returns>
        public int Menu() => Screens.Menu();

        /// <summary>
        /// Prints out credits page with some information about the app and authors.
        /// </summary>
        public void Credits() => Screens.Credits();

        /// <summary>
        /// Prints out the Goodbuy screen.
        /// </summary>
        public void Goodbuy() => Screens.Goodbuy();

        /// <summary>
        /// Asks for an answer
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public void AskForAnswer() => PrintTools.AskForAnswer();

        /// <summary>
        /// Prints a message to ask user to enter at least 1 item
        /// </summary>
        /// <param name="message">The message to print</param>
        /// <param name="leftMargin">cursor left position</param>
        public void PrintEnterAtLeastOneItem(string message, int leftMargin) => PrintTools.PrintEnterAtLeastOneItem(message, leftMargin);

        /// <summary>
        /// Prints "You need to enter at least something message"
        /// </summary>
        /// <returns>returns "true" if ESC key pressed</returns>
        public bool PrintEnterAtLeastSomething(int leftMargin) => PrintTools.PrintEnterAtLeastSomething(leftMargin);

        /// <summary>
        /// Prints out the GetUsers screen and collects user input.
        /// </summary>
        public void GetUsers()
        {
            Console.Clear();
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            int leftMargin = WindowWidthCenter - 15;
            PrintTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - (4 + users.GetCount() / 2);
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Enter users: ");
            Console.CursorLeft = leftMargin;
            PrintTools.DrawLine(35);
            Console.CursorTop = WindowHeightCenter - (1 + users.GetCount() / 2);
            Console.CursorLeft = leftMargin;
            if (users.GetCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                PrintUsers();
                Console.CursorTop++;
                Console.CursorLeft = leftMargin;
                PrintTools.DrawLine(35);
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
                PrintTools.DrawLine(41);
                Console.CursorTop++;
                Console.CursorLeft = WindowWidthCenter - 15;
                PrintTools.AnyKey();
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
                PrintTools.AnyKey();
            }
        }

        /// <summary>
        /// Prints out the list of Users with their sequence numbers.
        /// </summary>
        public void PrintUsers()
        {
            int windowWidth = Console.WindowWidth;
            int leftMargin = windowWidth / 2 - 15;
            if (users.GetCount() != 0)
            {
                int counter = 0;
                foreach (var user in users.GetNames())
                {
                    counter++;
                    Console.CursorLeft = leftMargin;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"User {counter}: ".PadRight(11, '.'));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{user}".PadLeft(24, '.'));
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
            if (users.GetCount() != 0)
            {
                int counter = 0;
                foreach (var item in users.GetAllUsers())
                {
                    counter++;
                    Console.CursorLeft = leftMargin;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"User {counter}".PadRight(9));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{item.GetName()}".PadRight(21, '.'));
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
            if (questions.GetQuestionsCount() > 0)
            {
                length = questions.GetQuestions().Max().Length;
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
            PrintTools.SetConsoleWindowTitle("Quiz - Add questions");
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
                questionsString = Console.ReadLine().ToUpper();
                if (!string.IsNullOrWhiteSpace(questionsString))
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    while (string.IsNullOrWhiteSpace(answerString))
                    {
                        AskForAnswer();
                        answerString = Console.ReadLine().ToUpper();
                        if (string.IsNullOrWhiteSpace(answerString) && PrintEnterAtLeastSomething(leftMargin))
                        {
                            break;
                        }
                    }

                    if (questionsString.Length > 0 && answerString != null && answerString.Length > 0)
                    {
                        questions.AddQuestionAndAnswer(questionsString.Trim(), answerString.Trim());
                        PrintInputRecieved(questions.GetQuestions().Max().Length, leftMargin);
                        break;
                    }
                }
                else if (PrintEnterAtLeastSomething(leftMargin))
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
            if (questions.GetQuestionsCount() > 0)
            {
                length = questions.GetQuestions().Max().Length;
            }

            return length;
        }

        /// <summary>
        /// Prints out message "Your input Recieved"
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public void PrintInputRecieved(int length, int leftMargin)
        {
            length += 14;
            if (length < 20)
            {
                length = 20;
            }

            Console.Clear();
            PrintTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - (8 + questions.GetQuestionsCount() / 2);
            Console.CursorLeft = WindowWidthCenter - 10;
            Console.WriteLine("Your input recieved: ");
            Console.CursorLeft = WindowWidthCenter - length / 2;
            PrintTools.DrawLine(length);
            Console.CursorTop++;
            Console.CursorLeft = WindowWidthCenter - length / 2;
            PrintQuestions();
            Console.CursorTop++;
            Console.CursorLeft = WindowWidthCenter - length / 2;
            PrintTools.DrawLine(length);
            Console.CursorLeft = WindowWidthCenter - 12;
            PrintTools.PrintGrey("Enter any key to exit... ");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Asks for  a question
        /// </summary>
        /// <param name="length">length of the longest question</param>
        /// <param name="leftMargin">Cursor Left position</param>
        public void AskForQuestion(int length, int leftMargin)
        {
            length += 14;
            if (length < 20)
            {
                length = 20;
            }

            leftMargin = (Console.WindowWidth / 2) - 7;
            Console.Clear();
            PrintTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - (4 + questions.GetQuestions().Count / 2);
            if (questions.GetQuestionsCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("Quiz questions");
                Console.CursorLeft = (Console.WindowWidth - length) / 2;
                PrintTools.DrawLine(length);
                Console.CursorTop++;
                Console.CursorLeft = leftMargin;
                PrintQuestions();
                Console.CursorTop++;
                Console.CursorLeft = (Console.WindowWidth - length) / 2;
                PrintTools.DrawLine(length);
            }

            Console.CursorTop++;
            Console.CursorLeft = (Console.WindowWidth - 16) / 2;
            Console.WriteLine("Enter a question: ");
            Console.CursorLeft = (Console.WindowWidth - 16) / 2;
            PrintTools.DrawLine(17);
            Console.CursorTop++;
        }

        /// <summary>
        /// Prints out the Add User screen and collects user's input.
        /// </summary>
        public void AddUsers()
        {
            Console.Clear();
            PrintTools.SetConsoleWindowTitle("Quiz - Add users");
            bool exitCode = true;
            while (exitCode)
            {
                EnterUserName();
                while (true)
                {
                    GetUsers();
                    PrintTools.PrintGrey("Do you want to add new user?[Y/n] ");
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
            while (true)
            {
                GetUsers();
                PrintTools.PrintGrey("New user's name: ");
                string input = Console.ReadLine().ToUpper();
                int positionTop = Console.CursorTop;
                if (!string.IsNullOrWhiteSpace(input))
                {
                    users.Add(input);
                    Console.CursorTop = positionTop - 1;
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    int leftMargin = WindowWidthCenter - 15;
                    Console.CursorLeft = leftMargin;
                    Console.WriteLine($"You added \"{input.Trim().ToUpperInvariant()}\"");
                    Console.CursorLeft = leftMargin;
                    PrintTools.AnyKey();
                    break;
                }
                else
                {
                    int leftMargin = WindowWidthCenter - 15;
                    Console.CursorLeft = leftMargin;
                    PrintTools.DrawLine(30);
                    if (PrintEnterAtLeastSomething(leftMargin))
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Prints out the quiz screen with username and corresponding question.
        /// </summary>
        public void StartQuiz()
        {
            Console.Clear();
            PrintTools.SetConsoleWindowTitle("Quiz");
            int leftMargin = WindowWidthCenter - 50;
            if (users.GetCount() > 0 && questions.GetQuestionsCount() > 0 && roundUsers.GetCount() > 0)
            {
                int user = 0;
                for (int i = 0; i < questions.GetQuestionsCount(); i++)
                {
                    AskQuestion(user, i);
                    ProcessAnswer(user, i);
                    Console.CursorVisible = true;
                    Console.CursorLeft = leftMargin;
                    if (user < roundUsers.GetCount() - 1)
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
                PrintTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 3;
                Console.CursorLeft = WindowWidthCenter - 22;
                if (roundUsers.GetWinner() >= 0)
                {
                    string winner = roundUsers.GetNames()[roundUsers.GetWinner()];
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
                PrintTools.DrawLine(44);
                Console.CursorTop++;
                Console.CursorLeft = leftMargin;
                PrintTools.AnyKey();
                Console.CursorLeft = leftMargin;
                Console.ResetColor();
                Console.Clear();
                roundUsers = Host.Services.GetRequiredService<IGameUsers>();
            }
            else
            {
                leftMargin = WindowWidthCenter - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                PrintTools.Fullscreen();
                Console.CursorTop = WindowHeightCenter - 3;
                string message = string.Empty;
                if (questions.GetQuestionsCount() == 0)
                {
                    message = "Oops... You need to add at least 1 question first";
                }
                else if (roundUsers.GetCount() == 0)
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
            PrintTools.Fullscreen();
            Console.CursorTop = WindowHeightCenter - 6;
            Console.CursorLeft = leftMargin;
            Console.WriteLine("Answer the Quiz question:");
            Console.CursorLeft = leftMargin;
            PrintTools.DrawLine(100);
            Console.CursorTop = WindowHeightCenter - 3;
            Console.CursorLeft = leftMargin;
            string text = $"User {user + 1}: ";
            PrintTools.PrintGrey(text);
            Console.WriteLine($"{roundUsers.GetNames()[user]}");
            Console.CursorLeft = leftMargin;
            string temp = roundUsers.GetScore(user).ToString();
            Console.WriteLine("Current user score is: " + temp);
            Console.CursorLeft = leftMargin;
            PrintTools.DrawLine(roundUsers.GetNames()[user].ToString().Length + 9);
            Console.CursorTop++;
            Console.CursorLeft = leftMargin;
            text = $"Question {i + 1}: ";
            PrintTools.PrintGrey(text);
            Console.WriteLine($"{questions.GetQuestions()[i]}");
            Console.CursorTop += 2;
        }

        /// <summary>
        /// Gets the answer and checks if it is correct and increment score
        /// </summary>
        /// <param name="user">user index</param>
        /// <param name="i">question index</param>
        public void ProcessAnswer(int user, int i)
        {
            Console.CursorLeft = WindowWidthCenter - 15;
            PrintTools.PrintGrey("Enter your answer: ");
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            string input;
            do
            {
                Console.CursorLeft = left;
                Console.CursorTop = top;
                input = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(input));
            Console.CursorTop = WindowHeightCenter + 3;
            string tmp = new string(' ', WindowWidth);
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

            Console.CursorTop++;
            Console.CursorLeft = WindowWidthCenter - 14;
            PrintTools.PrintGrey("Press any key to continue...");
            Console.ReadKey();
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
            PrintTools.Fullscreen();
            Console.CursorTop = heightCenter - 8;
            Console.CursorLeft = leftMargin;
            if (users.GetCount() != 0 && questions.GetQuestionsCount() != 0)
            {
                Console.CursorLeft = leftMargin;
                Console.WriteLine("High scores:");
                Console.CursorLeft = leftMargin;
                PrintTools.DrawLine(41);
                PrintUsersWithScores();
                Console.CursorLeft = leftMargin;
                PrintTools.DrawLine(41);
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
            PrintTools.SetConsoleWindowTitle("Quiz - Pick users");
            if (users.GetCount() == 0)
            {
                WindowWidth = Console.WindowWidth;
                WindowHeight = Console.WindowHeight;
                int leftMargin = WindowWidthCenter - 15;
                Console.CursorLeft = leftMargin;
                Console.Clear();
                PrintTools.Fullscreen();
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
                PrintTools.PrintGrey("Pick a user for the game: ");
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
                PrintTools.PrintGrey(message);
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
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int _) && users.GetCount() >= int.Parse(input) && int.Parse(input) > 0)
            {
                if (!roundUsers.GetNames().Contains(users.GetNames()[Convert.ToInt32(input) - 1]))
                {
                    int index = Convert.ToInt32(input) - 1;
                    int usernameLength = users.GetNames()[index].Length;
                    roundUsers.Add(users.GetNames()[index], index);
                    int positionTop = Console.CursorTop;
                    Console.CursorTop = positionTop - 1;
                    Console.WriteLine(new string(' ', WindowWidth));
                    Console.CursorLeft = WindowWidthCenter - (18 + usernameLength + 28) / 2;
                    Console.Write($"You have entered {users.GetNames()[index]}. ");
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

            PrintTools.AnyKey();
        }

        /// <summary>
        /// Prints the quantity of users picked.
        /// </summary>
        public void PrintUsersPicked()
        {
            GetUsers();
            Console.CursorLeft = WindowWidthCenter - 15;
            Console.WriteLine($"Users Picked: {roundUsers.GetAllUsers().Count}");
            foreach (string item in roundUsers.GetNames())
            {
                Console.CursorLeft = WindowWidthCenter - 15;
                Console.WriteLine(item);
            }

            Console.CursorLeft = WindowWidthCenter - 15;
            PrintTools.DrawLine(35);
            Console.CursorLeft = WindowWidthCenter - 15;
        }

        /// <summary>
        /// Saves Questions and Answers as well as Users and High Scores
        /// </summary>
        public void SaveData() => persistentDataOperations.SaveData(questions, users);

        /// <summary>
        /// Loads Questions and Answers as well as Users and High Scores
        /// </summary>
        public void LoadData() => persistentDataOperations.LoadData(questions, users);
    }
}