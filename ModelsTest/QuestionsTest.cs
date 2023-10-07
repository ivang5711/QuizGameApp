using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;

namespace QuizTest
{
    [TestClass]
    public class QuestionsTest
    {
        private readonly IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddTransient<IUsers, Users>();
            services.AddScoped<IQuestions, Questions>();
            services.AddTransient<IQuestionWithAnswer, QuestionWithAnswer>();
            services.AddTransient<IUser, User>();
        })
        .Build();

        [TestMethod]
        public void GetQuestionsEmptyTest()
        {
            Questions quizQuestions = new(_host);
            List<string> expected = new();
            List<string> actual = quizQuestions.GetQuestions();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetQuestionsTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");

            List<string> expected = new()
            {
                "How many bits in a Byte?".Trim().ToUpperInvariant(),
                "The capital of France?".Trim().ToUpperInvariant(),
                "The capital of Canada?".Trim().ToUpperInvariant()
            };

            List<string> actual = quizQuestions.GetQuestions();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetAnswersEmptyTest()
        {
            Questions quizQuestions = new(_host);
            List<string> expected = new();
            List<string> actual = quizQuestions.GetAnswers();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetAnswersTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");

            List<string> expected = new()
            {
                "8",
                "PARIS",
                "OTTAWA"
            };

            List<string> actual = quizQuestions.GetAnswers();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void AddQuestionAndAnswerTest()
        {
            Questions quizQuestions = new(_host);
            try
            {
                quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");
            int expected = 3;
            int actual = quizQuestions.GetQuestionsCount();
            Assert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetQuestionsCountEmptyTest()
        {
            Questions quizQuestions = new(_host);
            try
            {
                quizQuestions.GetQuestionsCount();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int expected = 0;
            int actual = quizQuestions.GetQuestionsCount();
            Assert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetQuestionsCountTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");
            try
            {
                quizQuestions.GetQuestionsCount();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int expected = 3;
            int actual = quizQuestions.GetQuestionsCount();
            Assert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void AnswerCheckCorrectTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");
            bool expected = true;
            bool actual = quizQuestions.AnswerCheck("How many bits in a Byte?", "8");
            Assert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void AnswerCheckIncorrectQuestionAnswerPairTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");
            bool expected = false;
            bool actual = quizQuestions.AnswerCheck("The name of the 3'rd planet from sun?", "Earth");
            Assert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void AnswerCheckIncorrectAnswerTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");
            bool expected = false;
            bool actual = quizQuestions.AnswerCheck("The capital of France?", "Earth");
            Assert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void AnswerCheckIncorrectQuestionTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");
            bool expected = false;
            bool actual = quizQuestions.AnswerCheck("The capital of Canada?", "Paris");
            Assert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetQuestionWithAnswersTest()
        {
            Questions quizQuestions = new(_host);
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");
            int expected = 3;
            int actual = quizQuestions.GetQuestionWithAnswers().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SaveQuestionsToCSVTest()
        {
            Questions initial = new(_host);
            initial.AddQuestionAndAnswer("How?", "somehow");
            initial.AddQuestionAndAnswer("When?", "then");
            List<IQuestionWithAnswer> expectedList = initial.GetQuestionWithAnswers();
            try
            {
                initial.SaveToCSV("questionsTest.csv");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Questions temp = new(_host);
            temp.ReadFromCSV("questionsTest.csv");
            List<IQuestionWithAnswer> actualList = temp.GetQuestionWithAnswers();
            if (expectedList.Count != actualList.Count)
            {
                Assert.Fail();
            }

            for (int i = 0; i < expectedList.Count; i++)
            {
                if (expectedList[i].GetQuestion() != actualList[i].GetQuestion() || expectedList[i].GetAnswer() != actualList[i].GetAnswer())
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ReadQuestionsFromCSV()
        {
            Questions initial = new(_host);
            initial.AddQuestionAndAnswer("What?", "nothing");
            initial.AddQuestionAndAnswer("Who?", "someone");
            List<IQuestionWithAnswer> expectedList = initial.GetQuestionWithAnswers();
            initial.SaveToCSV("questionsTest.csv");
            Questions temp = new(_host);
            try
            {
                temp.ReadFromCSV("questionsTest.csv");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            List<IQuestionWithAnswer> actualList = temp.GetQuestionWithAnswers();
            if (expectedList.Count != actualList.Count)
            {
                Assert.Fail();
            }

            for (int i = 0; i < expectedList.Count; i++)
            {
                if (expectedList[i].GetQuestion() != actualList[i].GetQuestion() || expectedList[i].GetAnswer() != actualList[i].GetAnswer())
                {
                    Assert.Fail();
                }
            }
        }
    }
}