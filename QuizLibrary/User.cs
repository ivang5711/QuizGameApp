
namespace QuizLibrary
{
    public class User
    {
        private readonly string name;
        private int score;

        public User()
        {
            name = string.Empty;
            score = 0;
        }

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="name">string representing name.</param>
        public User(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Creates a new User and sets a score specified.
        /// </summary>
        /// <param name="name">string representing name.</param>
        /// <param name="score">integer represents initial score.</param>
        public User(string name, int score)
        {
            this.name = name;
            this.score = score;
        }   

        /// <summary>
        /// Gets user name.
        /// </summary>
        /// <returns>A string with user name.</returns>
        public string GetUserName()
        {
            return name;
        }

        /// <summary>
        /// Gets user score.
        /// </summary>
        /// <returns>returns an integer with user score.</returns>
        public int GetUserScore()
        {
            return score;
        }

        /// <summary>
        /// Increments user score
        /// </summary>
        public void IncrementScore()
        {
            score++;
        }
    }
}
