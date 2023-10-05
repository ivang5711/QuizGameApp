namespace ModelsLibrary
{
    public class QuestionWithAnswer : IQuestionWithAnswer
    {
        private string question;
        private string answer;

        /// <summary>
        /// Gets question.
        /// </summary>
        /// <returns>Returns a string with a question.</returns>
        public string GetQuestion() => question;

        /// <summary>
        /// Gets answer.
        /// </summary>
        /// <returns>Returns a string with an answer to the corresponding question.</returns>
        public string GetAnswer() => answer;

        /// <summary>
        /// Sets both Question and answer
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        public void SetQuestionAndAnswer(string question, string answer)
        {
            this.question = question.Trim().ToUpperInvariant();
            this.answer = answer.Trim().ToUpperInvariant();
        }
    }
}