using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ModelsLibrary
{
    public class Questions
    {
        private readonly List<QuestionWithAnswer> questionsList;

        public Questions() => questionsList = new List<QuestionWithAnswer>();

        /// <summary>
        /// Gets Questions List from the Questions property.
        /// </summary>
        /// <returns>Returns Questions List</returns>
        public List<string> GetQuestions()
        {
            List<string> questions = new List<string>();
            foreach (QuestionWithAnswer item in questionsList)
            {
                questions.Add(item.GetQuestion());
            }

            return questions;
        }

        /// <summary>
        /// Gets the list of answers.
        /// </summary>
        /// <returns>Returns a list of answers for all questions.</returns>
        public List<string> GetAnswers()
        {
            List<string> answers = new List<string>();
            foreach (QuestionWithAnswer item in questionsList)
            {
                answers.Add(item.GetAnswer());
            }

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

            questionsList.Add(new QuestionWithAnswer(question, answer));
        }

        /// <summary>
        /// Gets the Questions property count.
        /// </summary>
        /// <returns>returns an int with Questions prperty count.</returns>
        public int GetQuestionsCount() => questionsList.Count;

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

            foreach (QuestionWithAnswer item in questionsList)
            {
                if (question.Trim().ToUpperInvariant() == item.GetQuestion() && answer.Trim().ToUpperInvariant() == item.GetAnswer())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns all questions with answers
        /// </summary>
        /// <returns>Questions List with Answers</returns>
        public List<QuestionWithAnswer> GetQuestionWithAnswers() => questionsList;

        /// <summary>
        /// Saves questions with answers to CSV file.
        /// </summary>
        /// <param name="fileName">Provide a valid file name to store the data to. I.e. "data.csv"</param>
        public void SaveToCSV(string fileName)
        {
            string file = fileName;
            string separator = ",";
            StringBuilder output = new StringBuilder();
            string[] headings = { "question", "answer" };
            output.AppendLine(string.Join(separator, headings));
            foreach (QuestionWithAnswer item in questionsList)
            {
                string[] newLine = { item.GetQuestion(), item.GetAnswer() };
                output.AppendLine(string.Join(separator, newLine));
            }

            try
            {
                File.WriteAllText(file, output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Data could not be written to the CSV file. {ex}");
            }

            Console.WriteLine("The data has been successfully saved to the CSV file");
        }

        /// <summary>
        /// Reads questions and answers from CSV file and loades them into memory
        /// </summary>
        /// <param name="fileName">Provide a file name to read the data from. I.e. "data.csv"</param>
        public void ReadFromCSV(string fileName)
        {
            if (File.Exists(Path.Combine(fileName)))
            {
                List<string> keys = new List<string>();
                List<string> values = new List<string>();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split(',');
                        keys.Add(data[0]);
                        values.Add(data[1]);
                    }
                }

                if (keys.Count > 1)
                {
                    for (int i = 1; i < keys.Count; i++)
                    {
                        questionsList.Add(new QuestionWithAnswer(keys[i], values[i]));
                    }
                }
            }
        }
    }
}