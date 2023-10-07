using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;

namespace QuizTest
{
    [TestClass]
    public class UsersTest
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
        public void AddUserTest()
        {
            Users users = new(_host);
            string user = "Adam";
            try
            {
                users.Add(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int expected = 1;
            int actual = users.GetCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddUserPickTest()
        {
            Users users = new(_host);
            string user = "Adam";
            int index = 5;
            try
            {
                users.Add(user, index);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            int countExpected = 1;
            int actualCount = users.GetCount();
            if (countExpected != actualCount)
            {
                Assert.Fail($"Number of users in result is {actualCount}, number of users expected is {countExpected}");
            }

            bool expected = true;
            bool actual = true;
            IUser user1 = users.GetObject(0);
            if (user1.GetName() != user.Trim().ToUpperInvariant() || user1.GetWinsTotal() != 0 || user1.GetIndex() != index)
            {
                actual = false;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserNamesTest()
        {
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");

            List<string> expected = new() { "ADAM", "EVE", "MARK" };
            List<string> actual = users.GetNames();
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
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");
            users.GetObject(0).IncrementScore();
            users.GetObject(2).IncrementScore();
            users.GetObject(2).IncrementScore();
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
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");
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
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");

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

            List<IUser> userList = users.GetAllUsers();
            foreach (IUser user in userList)
            {
                result.Add(user.GetWinsTotal());
            }

            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        public void GetScoreTest()
        {
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");
            users.GetObject(0).IncrementScore();
            users.GetObject(0).IncrementScore();
            users.GetObject(0).IncrementScore();
            users.GetObject(1).IncrementScore();

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
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");
            int expected = 3;
            int actual = users.GetCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWinnerNoWinnerTest()
        {
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");
            int expected = -1;
            int actual = users.GetWinner();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWinnerTest()
        {
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");
            users.GetObject(0).IncrementScore();
            int expected = 0;
            int actual = users.GetWinner();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserObjectTest()
        {
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");

            User expectedUser = new();
            expectedUser.CreateUser("Eve");
            User actualUser = new();
            try
            {
                actualUser = (User)users.GetObject(1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            bool expected = true;
            bool actual = true;
            if (actualUser == null || actualUser.GetName() != expectedUser.GetName())
            {
                actual = false;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");
            List<IUser> expectedUsers = new()
            {
                new User(),
                new User(),
                new User()
            };
            expectedUsers[0].CreateUser("Adam");
            expectedUsers[1].CreateUser("Eve");
            expectedUsers[2].CreateUser("Mark");
            List<IUser> actualList = users.GetAllUsers();
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
                    if (expectedUsers[i].GetName() != actualList[i].GetName())
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
            Users users = new(_host);
            users.Add("Adam");
            users.Add("Eve");
            users.Add("Mark");

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
            Users initial = new(_host);
            initial.Add("Tom");
            initial.Add("Bob");
            List<IUser> expectedList = initial.GetAllUsers();
            initial.SaveToCSV("user-score-test.csv");
            Users temp = new(_host);
            try
            {
                temp.ReadFromCSV("user-score-test.csv");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            List<IUser> actualList = temp.GetAllUsers();
            if (expectedList.Count != actualList.Count)
            {
                Assert.Fail();
            }

            for (int i = 0; i < expectedList.Count; i++)
            {
                if (expectedList[i].GetName() != actualList[i].GetName() || expectedList[i].GetWinsTotal() != actualList[i].GetWinsTotal())
                {
                    Assert.Fail();
                }
            }
        }
    }
}