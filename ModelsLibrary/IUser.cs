namespace ModelsLibrary
{
    public interface IUser
    {
        int GetIndex();
        string GetName();
        int GetScore();
        int GetWinsTotal();
        void IncrementScore();
        void IncrementWinsTotal();
        void SetIndex(int index);
        void CreateUser();
        void CreateUser(string name, int winsTotal = 0, int index = -1);
    }
}