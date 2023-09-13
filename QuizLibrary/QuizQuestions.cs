using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizLibrary
{
    public class QuizQuestions
    {
        private readonly List<QuestionWithAnswer> questionsList;

        public QuizQuestions()
        {
            questionsList = new List<QuestionWithAnswer>();
        }

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
        public int GetQuestionsCount()
        {
            return questionsList.Count;
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

            foreach (QuestionWithAnswer item in questionsList)
            {
                if (question.ToUpper() == item.GetQuestion().ToUpper() && answer.ToUpper() == item.GetAnswer().ToUpper())
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
        public List<QuestionWithAnswer> GetQuestionWithAnswers()
        {
            return questionsList;
        }

        /// <summary>
        /// Saves questions with answers to CSV file.
        /// </summary>
        public void SaveQuestionsToCSV()
        {
            string file = $@"..\\questions.csv";
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
            catch (Exception)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
            }

            Console.WriteLine("The data has been successfully saved to the CSV file");
        }

        /// <summary>
        /// Reads questions and answers from CSV file and loades them into memory
        /// </summary>
        public void ReadQuestionsFromCSV()
        {
            string file = $@"..\\questions.csv";
            if (File.Exists(Path.Combine(file)))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        listA.Add(values[0]);
                        listB.Add(values[1]);
                    }
                }

                if (listA.Count > 1)
                {
                    for (int i = 1; i < listA.Count; i++)
                    {
                        questionsList.Add(new QuestionWithAnswer(listA[i], listB[i]));
                    }
                }
            }

        }
    }
}