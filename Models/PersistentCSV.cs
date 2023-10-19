namespace ModelsLibrary
{
    public class PersistentCsv : IPersistentDataOperations
    {
        public void LoadData(IGameQuestions questions, IGameUsers users)
        {
            questions.ReadFromCSV("questions.csv");
            users.ReadFromCSV("user-score.csv");
        }

        public void SaveData(IGameQuestions questions, IGameUsers users)
        {
            questions.SaveToCSV("questions.csv");
            users.SaveToCSV("user-score.csv");
        }
    }
}