using ModelsLibrary;

namespace QuizTest
{
    [TestClass]
    public class QuestionsWithAnswersTest
    {
        [TestMethod]
        public void GetQuestionTest()
        {
            string question = "Who is the President of the US?";
            string answer = "J. Biden";
            string expected = "Who is the President of the US?";

            QuestionWithAnswer questionWithAnswer = new();
            questionWithAnswer.SetQuestionAndAnswer(question, answer);

            string actual = questionWithAnswer.GetQuestion();

            Assert.AreEqual(expected, actual, true, "Question is incorrect");
        }

        [TestMethod]
        public void GetAnswer()
        {
            // Arrange
            string nameOne = "Who is the President of the US?";
            string NameTwo = "J. Biden";
            string expected = "J. Biden";
            QuestionWithAnswer questionWithAnswer = new();
            questionWithAnswer.SetQuestionAndAnswer(nameOne, NameTwo);

            // Act
            string actual = questionWithAnswer.GetAnswer();

            // Assert
            Assert.AreEqual(expected, actual, true, "Answer is incorrect");
        }
    }
}