using QuizLibrary;

namespace QuizTest
{
    [TestClass]
    public class QuizQuestionsTest
    {
        [TestMethod]
        public void GetQuestionsEmptyTest()
        {
            QuizQuestions quizQuestions = new();
            List<string> expected = new();
            List<string> actual = quizQuestions.GetQuestions();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetQuestionsTest()
        {
            QuizQuestions quizQuestions = new();
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");

            List<string> expected = new()
            {
                "How many bits in a Byte?",
                "The capital of France?",
                "The capital of Canada?"
            };

            List<string> actual = quizQuestions.GetQuestions();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetAnswersEmptyTest()
        {
            QuizQuestions quizQuestions = new();
            List<string> expected = new();
            List<string> actual = quizQuestions.GetAnswers();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void GetAnswersTest()
        {
            QuizQuestions quizQuestions = new();
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");

            List<string> expected = new()
            {
                "8",
                "Paris",
                "Ottawa"
            };

            List<string> actual = quizQuestions.GetAnswers();
            CollectionAssert.AreEqual(expected, actual, "The output is incorrect");
        }

        [TestMethod]
        public void AddQuestionAndAnswerTest()
        {
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
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
            QuizQuestions quizQuestions = new();
            quizQuestions.AddQuestionAndAnswer("How many bits in a Byte?", "8");
            quizQuestions.AddQuestionAndAnswer("The capital of France?", "Paris");
            quizQuestions.AddQuestionAndAnswer("The capital of Canada?", "Ottawa");

            string file = $@"..\\questions.csv";

            try
            {
                quizQuestions.SaveQuestionsToCSV();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            bool expected = true;
            bool actual = false;
            if (File.Exists(Path.Combine(file)))
            {
                actual = true;
            }


            List<string> listA = new();
            List<string> listB = new();
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

            int expectedCount = 4;
            int listACount = listA.Count;
            int listBCount = listB.Count;

            if (expectedCount != listACount || listBCount != expectedCount)
            {
                actual = false;
            }

            if (listA[0] != "question" || listB[0] != "answer")
            {
                actual = false;
            }

            if (listA[1] != "How many bits in a Byte?" || listA[2] != "The capital of France?" || listA[3] != "The capital of Canada?")
            {
                actual = false;
            }

            if (listB[1] != "8" || listB[2] != "Paris" || listB[3] != "Ottawa")
            {
                actual = false;
            }

            Assert.AreEqual(expected, actual);
        }

    }
}
