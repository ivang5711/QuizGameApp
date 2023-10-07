using System.Collections.Generic;

namespace ModelsLibrary
{
    public interface IQuestions
    {
        void AddQuestionAndAnswer(string question, string answer);

        bool AnswerCheck(string question, string answer);

        List<string> GetAnswers();

        List<string> GetQuestions();

        int GetQuestionsCount();

        List<IQuestionWithAnswer> GetQuestionWithAnswers();

        void ReadFromCSV(string fileName);

        void SaveToCSV(string fileName);

        void ReadFromDb();

        void WriteToDb();
    }
}