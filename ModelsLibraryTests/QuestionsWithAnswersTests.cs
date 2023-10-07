using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsLibrary;

namespace ModelsLibraryTests
{
    public class QuestionsWithAnswersTests
    {
        private readonly IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddTransient<IUsers, Users>();
            services.AddScoped<IQuestions, Questions>();
            services.AddTransient<IQuestionWithAnswer, QuestionWithAnswer>();
            services.AddTransient<IUser, User>();
        })
    .Build();

        [Theory]
        [InlineData("sample question", "SAMPLE QUESTION")]
        [InlineData("Sample Question", "SAMPLE QUESTION")]
        [InlineData("SamplE QuestioN", "SAMPLE QUESTION")]
        [InlineData("Sample2!Question,", "SAMPLE2!QUESTION,")]
        [InlineData("  SamplE QuestioN  ", "SAMPLE QUESTION")]
        public void GetQuestionTest(string input, string expected)
        {
            var temp = _host.Services.GetRequiredService<IQuestionWithAnswer>();
            temp.SetQuestionAndAnswer(input, "some answer");
            string actual = temp.GetQuestion();
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
            var temp = _host.Services.GetRequiredService<IQuestionWithAnswer>();
            temp.SetQuestionAndAnswer("some question", input);
            string actual = temp.GetAnswer();
            Assert.Equal(expected.ToUpperInvariant(), actual);
        }
    }
}