using System;
using System.Collections.Generic;
namespace QuizLibrary
{
    public class QuizQuestions
    {
        private readonly List<string> questions;

        public QuizQuestions()
        {
            questions = new List<string>();
        }


        /// <summary>
        /// Gets Questions List from the Questions property.
        /// </summary>
        /// <returns>Returns Questions List</returns>
        public List<string> GetQuestions()
        {
            return questions;
        }

        /// <summary>
        /// Adds a question to the Questions property.
        /// </summary>
        /// <param name="question">gets string "question" as input. Checks if the string is not null, empty or whitespace.</param>

        public void AddQuestion(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException(question, nameof(question));
            }

            questions.Add(question);
        }

        /// <summary>
        /// Gets the Questions property count.
        /// </summary>
        /// <returns>returns an int with Questions prperty count.</returns>
        public int GetQuestionsCount()
        {
            return questions.Count;
        }
    }
}
