namespace ModelsLibrary
{
    public interface IUserInterface
    {
        void AddQuestions();

        void AddUsers();

        void AskForAnswer();

        void AskForQuestion(int length, int leftMargin);

        void AskQuestion(int user, int i);

        bool AskToPickNewUser();

        void CheckPickedUser(string input);

        void Credits();

        void EnterUserName();

        int GetMaxQuestionLength();

        void GetUsers();

        void Goodbuy();

        int Menu();

        void PickUsers();

        void PrintArgs(string[] args);

        void PrintEnterAtLeastOneItem(string message, int leftMargin);

        void PrintHelp();

        void PrintInputRecieved(int length, int leftMargin);

        void PrintQuestions();

        void PrintUsers();

        void PrintUsersPicked();

        void PrintUsersWithScores();

        void ProcessAnswer(int user, int i);

        void StartQuiz();

        void WelcomeScreen(string message);

        int WriteResults();

        bool PrintEnterAtLeastSomething(int leftMargin);

        void LoadData();

        void SaveData();
    }
}