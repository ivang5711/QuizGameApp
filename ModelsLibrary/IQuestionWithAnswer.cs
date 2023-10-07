namespace ModelsLibrary
{
    public interface IQuestionWithAnswer
    {
        string GetAnswer();

        string GetQuestion();

        void SetQuestionAndAnswer(string question, string answer);
    }
}