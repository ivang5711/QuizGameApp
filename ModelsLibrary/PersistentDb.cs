using Microsoft.Data.Sqlite;
using System.IO;

namespace ModelsLibrary
{
    public class PersistentDb : IPersistentDataOperations
    {
        public PersistentDb()
        {
            if (!File.Exists("quizData.db"))
            {
                using (var connection = new SqliteConnection("Data Source=quizData.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                    CREATE TABLE questions (
                        question TEXT NOT NULL PRIMARY KEY UNIQUE,
                        answer TEXT NOT NULL
                    );

                    CREATE TABLE users (
                        userName TEXT NOT NULL PRIMARY KEY UNIQUE,
                        winsTotal INTEGER NOT NULL DEFAULT 0
                    );
                ";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void LoadData(IQuestions questions, IUsers users)
        {
            questions.ReadFromDb();
            users.ReadFromDb();
        }

        public void SaveData(IQuestions questions, IUsers users)
        {
            questions.WriteToDb();
            users.WriteToDb();
        }
    }
}