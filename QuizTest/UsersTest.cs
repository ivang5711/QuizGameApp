using ModelsLibrary;

namespace QuizTest
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public void AddUserTest()
        {
            Users users = new();
            string user = "Adam";
            try
            {
                users.AddUser(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int expected = 1;
            int actual = users.GetUsersCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddUserPickTest()
        {
            Users users = new();
            string user = "Adam";
            int index = 5;
            try
            {
                users.AddUser(user, index);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int countExpected = 1;
            int actualCount = users.GetUsersCount();
            if (countExpected != actualCount)
            {
                Assert.Fail($"Number of users in result is {actualCount}, number of users expected is {countExpected}");
            }

            bool expected = true;
            bool actual = true;
            User user1 = users.GetUserObject(0);
            if (user1.GetUserName() != user.Trim().ToUpperInvariant() || user1.GetWinsTotal() != 0 || user1.GetIndex() != index)
            {
                actual = false;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserNamesTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");

            List<string> expected = new() { "ADAM", "EVE", "MARK" };
            List<string> actual = users.GetUserNames();
            bool check = true;
            if (actual.Count != expected.Count)
            {
                check = false;
            }
            else
            {
                for (int i = 0; i < actual.Count; i++)
                {
                    if (actual[i] != expected[i])
                    {
                        check = false;
                    }
                }
            }

            Assert.IsTrue(check);
        }

        [TestMethod]
        public void GetScoresTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");
            users.GetUserObject(0).IncrementScore();
            users.GetUserObject(2).IncrementScore();
            users.GetUserObject(2).IncrementScore();
            List<int> expectedList = new() { 1, 0, 2 };
            List<int> result = new();
            try
            {
                result = users.GetScores();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        public void AddScoreTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");
            try
            {
                users.AddScore(0);
                users.AddScore(2);
                users.AddScore(2);
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.Message}", ex);
            }

            List<int> expectedList = new() { 1, 0, 2 };
            List<int> result = users.GetScores();
            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        public void AddWinTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");

            List<int> expectedList = new() { 2, 0, 1 };
            List<int> result = new();
            try
            {
                users.AddWin(0);
                users.AddWin(0);
                users.AddWin(2);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            List<User> userList = users.GetAllUsers();
            foreach (User user in userList)
            {
                result.Add(user.GetWinsTotal());
            }

            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        public void GetScoreTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");
            users.GetUserObject(0).IncrementScore();
            users.GetUserObject(0).IncrementScore();
            users.GetUserObject(0).IncrementScore();
            users.GetUserObject(1).IncrementScore();

            List<int> expected = new() { 3, 1, 0 };
            List<int> result = new()
            {
                users.GetScore(0),
                users.GetScore(1),
                users.GetScore(2)
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetUsersCountTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");
            int expected = 3;
            int actual = users.GetUsersCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWinnerNoWinnerTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");
            int expected = -1;
            int actual = users.GetWinner();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWinnerTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");
            users.GetUserObject(0).IncrementScore();
            int expected = 0;
            int actual = users.GetWinner();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserObjectTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");

            User expectedUser = new("Eve");
            User actualUser = new();
            try
            {
                actualUser = users.GetUserObject(1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            bool expected = true;
            bool actual = true;
            if (actualUser == null || actualUser.GetUserName() != expectedUser.GetUserName())
            {
                actual = false;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");

            List<User> expectedUsers = new()
            {
                new User("Adam"),
                new User("Eve"),
                new User("Mark")
            };

            List<User> actualList = users.GetAllUsers();
            bool expected = true;
            bool actual = true;
            if (actualList.Count != expectedUsers.Count)
            {
                actual = false;
            }
            else
            {
                for (int i = 0; i < expectedUsers.Count; i++)
                {
                    if (expectedUsers[i].GetUserName() != actualList[i].GetUserName())
                    {
                        actual = false;
                        break;
                    }
                }
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SaveToCSVTest()
        {
            Users users = new();
            users.AddUser("Adam");
            users.AddUser("Eve");
            users.AddUser("Mark");

            string file = "user-score-test.csv";

            try
            {
                users.SaveToCSV("user-score-test.csv");
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
                    var values = line!.Split(',');

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

            if (listA[0] != "name" || listB[0] != "winsTotal")
            {
                actual = false;
            }

            if (listA[1] != "ADAM" || listA[2] != "EVE" || listA[3] != "MARK")
            {
                actual = false;
            }

            if (listB[1] != "0" || listB[2] != "0" || listB[3] != "0")
            {
                actual = false;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadFromCSVTest()
        {
            Users initial = new();
            initial.AddUser("Tom");
            initial.AddUser("Bob");
            List<User> expectedList = initial.GetAllUsers();
            initial.SaveToCSV("user-score-test.csv");
            Users temp = new();
            try
            {
                temp.ReadFromCSV("user-score-test.csv");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            List<User> actualList = temp.GetAllUsers();
            if (expectedList.Count != actualList.Count)
            {
                Assert.Fail();
            }

            for (int i = 0; i < expectedList.Count; i++)
            {
                if (expectedList[i].GetUserName() != actualList[i].GetUserName() || expectedList[i].GetWinsTotal() != actualList[i].GetWinsTotal())
                {
                    Assert.Fail();
                }
            }
        }
    }
}