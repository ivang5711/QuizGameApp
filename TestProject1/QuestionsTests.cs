using ModelsLibrary;
using System.Diagnostics;
using Xunit.Sdk;

namespace ModelsLibraryTests
{
    public class QuestionsTests 
    {
        [Theory]
        [InlineData("sample question", "SAMPLE QUESTION")]
        public void GetQuestionsTest(string question, string expected)
        {
            Questions questions = new();
            questions.AddQuestionAndAnswer(question, "sample answer");
            string actual = questions.GetQuestions()[0];
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("sample answer", "SAMPLE ANSWER")]
        public void GetAnswersTest(string answer, string expected)
        {
            Questions answers = new();
            answers.AddQuestionAndAnswer("sample question", answer);
            string actual = answers.GetAnswers()[0];
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(1, 1)]
        [InlineData(10000, 10000)]
        public void GetQuestionsCountTest(int quantity, int expected)
        {
            Questions questions = new();
            for (int i = 0; i < quantity; i++)
            {
                questions.AddQuestionAndAnswer($"sample question {i}", $"sample answer {i}");
            }

            int actual = questions.GetQuestionsCount();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("highest mountain?", "everest", true)]
        [InlineData("highest mountain?", "volcano", false)]
        [InlineData("Some question?", "Biden", false)]
        public void AnswerCheckTest(string question, string answer, bool expected)
        {
            Questions questions = new();
            questions.AddQuestionAndAnswer("highest mountain?", "everest");
            questions.AddQuestionAndAnswer("capital of Canada?", "Ottawa");
            questions.AddQuestionAndAnswer("President of the US in 2022?", "Biden");
            bool actual = questions.AnswerCheck(question, answer);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQuestionWithAnswersTest()
        {
            Questions questions = new();
            questions.AddQuestionAndAnswer("highest mountain?", "everest");
            questions.AddQuestionAndAnswer("capital of Canada?", "Ottawa");
            questions.AddQuestionAndAnswer("President of the US in 2022?", "Biden");
            int expected = 3;
            int actual =  questions.GetQuestionWithAnswers().Count;
            Assert.Equal(expected, actual);
        }
    }
}