using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;

namespace ModelsLibraryTests
{
    public class UsersTests
    {
        public IUsers TestUser { get; set; }

        readonly IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddTransient<IUsers, Users>();
            services.AddScoped<IQuestions, Questions>();
            services.AddTransient<IQuestionWithAnswer, QuestionWithAnswer>();
            services.AddTransient<IUser, User>();
        })
    .Build();


        public UsersTests()
        {
            TestUser = new Users(_host);
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");
            users.AddWin(1);
            List<int> expected = new() { 0, 1, 0 };
            List<int> actual = new();
            for (int i = 0; i < 3; i++)
            {
                IUser user = users.GetObject(i);
                actual.Add(user.GetWinsTotal());
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetScoreTest()
        {
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
            users.Add("JOHN");
            users.Add("ANNA");
            users.Add("EVE");

            IUser user = _host.Services.GetRequiredService<IUser>();
            user.CreateUser("ANNA");
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
            IUsers users = _host.Services.GetRequiredService<IUsers>();
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
