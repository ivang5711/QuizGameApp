namespace ModelsLibrary
{
    public interface IPersistentDataOperations
    {
        void LoadData(IGameQuestions questions, IGameUsers users);

        void SaveData(IGameQuestions questions, IGameUsers users);
    }
}