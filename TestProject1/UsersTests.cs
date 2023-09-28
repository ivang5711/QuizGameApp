using ModelsLibrary;
using System;

namespace ModelsLibraryTests
{
    public class UsersTests
    {
        public Users TestUser { get; set; } = new Users();
        public UsersTests()
        {
            TestUser.Add("JOHN");
            TestUser.Add("ANNA");
            TestUser.Add("EVE");
        }

        [Fact]
        public void AddTest()
        {
            int expected = 3;
            int actual = TestUser.GetCount();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddWithIndexTest()
        {
            Users users = new Users();
            users.Add("JOHN", 78);
            int expected = 78;
            int actual = users.GetAllUsers()[0].GetIndex();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNamesTest()
        {
            List<string> expected = new() { "JOHN", "ANNA", "EVE" };
            List<string> actual = TestUser.GetNames();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetScoresTest()
        {
            List<int> expected = new() { 0, 0, 0 };
            List<int> actual = TestUser.GetScores();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddScoreTest()
        {
            Users users = new();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");
            users.AddScore(1);
            List<int> expected = new() { 0, 1, 0 };
            List<int> actual = users.GetScores();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddWinTest()
        {
            Users users = new();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");
            users.AddWin(1);
            List<int> expected = new() { 0, 1, 0 };
            List<int> actual = new();
            for (int i = 0; i < 3; i++)
            {
                User user = users.GetObject(i);
                actual.Add(user.GetWinsTotal());
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetScoreTest()
        {
            Users users = new();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(2);
            users.AddScore(1);
            int expected = 4;
            int actual = users.GetScore(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCountTest()
        {
            Users users = new();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");
            users.Add("MARK");
            users.Add("OM");
            int expected = 5;
            int actual = users.GetCount();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 2, 1)]
        [InlineData(2, 5, 2)]
        public void GetWinnerTest(int index, int numberOfWins, int expected)
        {
            Users users = new();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(2);
            for (int i = 0; i < numberOfWins; i++)
            {
                users.AddScore(index);
            }

            int actual = users.GetWinner();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(2, 3)]
        public void GetWinnerFailTest(int index, int numberOfWins)
        {
            Users users = new();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(1);
            users.AddScore(2);
            for (int i = 0; i < numberOfWins; i++)
            {
                users.AddScore(index);
            }

            int expected = -1;
            int actual = users.GetWinner();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetWinnerFailNoUsersTest()
        {
            Users users = new();
            int expected = -1;
            int actual = users.GetWinner();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(1023)]
        public void GetWinnerFailSingleUserTest(int numberOfWins)
        {
            Users users = new();
            users.Add("JOHN");
            for (int i = 0; i < numberOfWins; i++)
            {
                users.AddScore(0);
            }

            int expected = -1;
            int actual = users.GetWinner();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetObjectTest()
        {
            Users users = new();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");

            User user = new("ANNA");
            string expected = user.GetName();
            string actual = users.GetObject(1).GetName();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(1023)]
        public void GetAllUsersTest(int numberOfUsers)
        {
            Users users = new();
            for (int i = 0; i < numberOfUsers; i++)
            {
                users.Add($"sampleUser{i}");
            }

            int expected = numberOfUsers;
            int actual = users.GetAllUsers().Count;
            Assert.Equal(expected, actual);
        }
    }
}
