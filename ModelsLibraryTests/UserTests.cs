using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;

namespace ModelsLibraryTests
{
    public class UserTests
    {
        public IUser TestUser { get; set; }

        private readonly IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddTransient<IUsers, Users>();
            services.AddScoped<IQuestions, Questions>();
            services.AddTransient<IQuestionWithAnswer, QuestionWithAnswer>();
            services.AddTransient<IUser, User>();
        })
            .Build();

        public UserTests()
        {
            TestUser = new User();
            TestUser.CreateUser("JOHN", 18, 129);
        }

        [Fact]
        public void GetUserNameTest()
        {
            string actual = TestUser.GetName();
            string expected = "JOHN";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetWinsTotalTest()
        {
            int actual = TestUser.GetWinsTotal();
            int expected = 18;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetIndexTest()
        {
            int actual = TestUser.GetIndex();
            int expected = 129;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetUserScoreTest()
        {
            int actual = TestUser.GetScore();
            int expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IncrementWinsTotalTest()
        {
            IUser user = _host.Services.GetRequiredService<IUser>();
            user.CreateUser("JAKE", 30);
            user.IncrementWinsTotal();
            user.IncrementWinsTotal();
            user.IncrementWinsTotal();
            int expected = 30 + 3;
            int actual = user.GetWinsTotal();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetIndexTest()
        {
            IUser user = _host.Services.GetRequiredService<IUser>();
            user.CreateUser("JAKE", 30, 0);
            user.SetIndex(64);
            int expected = 64;
            int actual = user.GetIndex();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IncrementScoreTest()
        {
            IUser user = _host.Services.GetRequiredService<IUser>();
            user.CreateUser("JAKE", 30, 0);
            user.IncrementScore();
            user.IncrementScore();
            user.IncrementScore();
            int expected = 3;
            int actual = user.GetScore();
            Assert.Equal(expected, actual);
        }
    }
}