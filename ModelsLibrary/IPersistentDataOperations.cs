namespace ModelsLibrary
{
    public interface IPersistentDataOperations
    {
        void LoadData(IQuestions questions, IUsers users);
        void SaveData(IQuestions questions, IUsers users);
    }
}
