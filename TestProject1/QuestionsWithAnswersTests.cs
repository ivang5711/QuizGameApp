using ModelsLibrary;
using System.ComponentModel;

namespace ModelsLibraryTests
{
    public class QuestionsWithAnswersTests
    {
        [Theory]
        [InlineData("sample question", "SAMPLE QUESTION")]
        [InlineData("Sample Question", "SAMPLE QUESTION")]
        [InlineData("SamplE QuestioN", "SAMPLE QUESTION")]
        [InlineData("Sample2!Question,", "SAMPLE2!QUESTION,")]
        [InlineData("  SamplE QuestioN  ", "SAMPLE QUESTION")]
        public void GetQuestionTest(string input, string expected)
        {
            string actual = new QuestionWithAnswer(input, "some answer").GetQuestion();
            Assert.Equal(expected.ToUpperInvariant(), actual);
        }

        [Theory]
        [InlineData("sample answer", "SAMPLE ANSWER")]
        [InlineData("Sample Answer", "SAMPLE ANSWER")]
        [InlineData("SamplE AnsweR", "SAMPLE ANSWER")]
        [InlineData("Sample2!Answer,", "SAMPLE2!ANSWER,")]
        [InlineData("  SamplE AnsweR  ", "SAMPLE ANSWER")]
        public void GetAnswerTest(string input, string expected)
        {
            string actual = new QuestionWithAnswer("some question", input).GetAnswer();
            Assert.Equal(expected.ToUpperInvariant(), actual);
        }
    }
}
