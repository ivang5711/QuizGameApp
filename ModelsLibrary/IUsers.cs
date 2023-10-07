using System.Collections.Generic;

namespace ModelsLibrary
{
    public interface IUsers
    {
        void Add(string user, int index = -1);
        void AddScore(int index);
        void AddWin(int index);
        List<IUser> GetAllUsers();
        int GetCount();
        List<string> GetNames();
        IUser GetObject(int index);
        int GetScore(int index);
        List<int> GetScores();
        int GetWinner();
        void ReadFromCSV(string fileName);
        void SaveToCSV(string fileName);
        void ReadFromDb();
        void WriteToDb();
    }
}