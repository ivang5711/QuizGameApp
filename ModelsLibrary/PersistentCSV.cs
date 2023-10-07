namespace ModelsLibrary
{
    public class PersistentCsv : IPersistentDataOperations
    {
        public void LoadData(IQuestions questions, IUsers users)
        {
            questions.ReadFromCSV("questions.csv");
            users.ReadFromCSV("user-score.csv");
        }

        public void SaveData(IQuestions questions, IUsers users)
        {
            questions.SaveToCSV("questions.csv");
            users.SaveToCSV("user-score.csv");
        }
    }
}