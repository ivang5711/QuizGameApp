namespace ModelsLibrary
{
    public class QuestionWithAnswer
    {
        private readonly string question;
        private readonly string answer;

        public QuestionWithAnswer(string question, string answer)
        {
            this.question = question.Trim().ToUpperInvariant();
            this.answer = answer.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Gets question.
        /// </summary>
        /// <returns>Returns a string with a question.</returns>
        public string GetQuestion()
        {
            return question;
        }

        /// <summary>
        /// Gets answer.
        /// </summary>
        /// <returns>Returns a string with an answer to the corresponding question.</returns>
        public string GetAnswer()
        {
            return answer;
        }
    }
}