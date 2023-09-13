using QuizLibrary;

namespace QuizTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetUserNameTest()
        {
            User user = new("Adam");
            string expected = "Adam";
            string actual = user.GetUserName();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserScoreTest()
        {
            User user = new("Adam");
            int expected = 0;
            int actual = -1;
            try
            {
                actual = user.GetUserScore();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ÌncrementScoreTest()
        {
            User user = new("Adam");
            try
            {
                user.IncrementScore();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int expected = 1;
            int actual = user.GetUserScore();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IncrementWinsTotalTest()
        {
            User user = new("Adam");
            try
            {
                user.IncrementWinsTotal();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int expected = 1;
            int actual = user.GetWinsTotal();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWinsTotalTest()
        {
            User user = new("Adam");
            user.IncrementWinsTotal();
            user.IncrementWinsTotal();
            int expected = 2;
            int actual = 0;
            try
            {
                actual = user.GetWinsTotal();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetIndexTest()
        {
            User user = new("Adam");
            try
            {
                user.SetIndex(7);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int expected = 7;
            int actual = user.GetIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetIndexTest()
        {
            User user = new("Adam");
            user.SetIndex(7);
            int expected = 7;
            int actual = -1;
            try
            {
                actual = user.GetIndex();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
