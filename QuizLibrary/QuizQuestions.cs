using System;
using System.Collections.Generic;
namespace QuizLibrary
{
    public class QuizQuestions
    {
        readonly List<string> questions;
        readonly List<string> answers;
        readonly Dictionary<string, string> questionsAndAnswers;

        public QuizQuestions()
        {
            questions = new List<string>();
            answers = new List<string>();
            questionsAndAnswers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets Questions List from the Questions property.
        /// </summary>
        /// <returns>Returns Questions List</returns>
        public List<string> GetQuestions()
        {
            questions.Clear();
            foreach (KeyValuePair<string, string> pair in questionsAndAnswers)
            {
                questions.Add(pair.Key);
            }

            return questions;
        }

        /// <summary>
        /// Gets the list of answers.
        /// </summary>
        /// <returns>Returns a list of answers for all questions.</returns>
        public List<string> GetAnswers()
        {
            return answers;
        }

        /// <summary>
        /// Saves question and corresponding answer into memory.
        /// </summary>
        /// <param name="question">A string with a question.</param>
        /// <param name="answer">A string with an answer.</param>
        /// <exception cref="ArgumentException">Checks if the strings provided are null or empty.</exception>
        public void AddQuestionAndAnswer(string question, string answer)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException(question, nameof(question));
            }

            if (string.IsNullOrWhiteSpace(answer))
            {
                throw new ArgumentException(answer, nameof(answer));
            }

            questionsAndAnswers.Add(question, answer);
        }

        /// <summary>
        /// Gets the Questions property count.
        /// </summary>
        /// <returns>returns an int with Questions prperty count.</returns>
        public int GetQuestionsCount()
        {

            return questionsAndAnswers.Count;
        }

        /// <summary>
        /// Performs a user's answer correctness check.
        /// </summary>
        /// <param name="question">A string with a question being asked.</param>
        /// <param name="answer">A string with a user's answer.</param>
        /// <returns>Returns true if correct and false otherwise.</returns>
        /// <exception cref="ArgumentException">Checks if the input parameters are not null or empty.</exception>
        public bool AnswerCheck(string question, string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                throw new ArgumentException(answer, nameof(answer));
            }

            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException(question, nameof(question));
            }

            if (answer == questionsAndAnswers[$"{question}"])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
