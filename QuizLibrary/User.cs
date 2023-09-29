namespace ModelsLibrary
{
    public class User
    {
        private readonly string name;
        private int winsTotal;
        private int index;
        private int score;

        public User()
        {
            name = string.Empty;
            score = 0;
            index = -1;
            winsTotal = 0;
        }

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="name">string representing name.</param>
        public User(string name) => this.name = name.Trim().ToUpperInvariant();

        /// <summary>
        /// Creates a new User and sets a winsTotal specified.
        /// </summary>
        /// <param name="name">string representing name.</param>
        /// <param name="winsTotal">integer represents initial winsTotal.</param>
        public User(string name, int winsTotal)
        {
            this.name = name.Trim().ToUpperInvariant();
            this.winsTotal = winsTotal;
        }

        /// <summary>
        /// Creates a new User and sets a winsTotal and index picked as specified.
        /// </summary>
        /// <param name="name">string representing name.</param>
        /// <param name="winsTotal">integer represents initial winsTotal.</param>
        /// <param name="index">integer represents index picked</param>
        public User(string name, int winsTotal, int index)
        {
            this.name = name.Trim().ToUpperInvariant();
            this.index = index;
            this.winsTotal = winsTotal;
        }

        /// <summary>
        /// Gets user name.
        /// </summary>
        /// <returns>A string with user name.</returns>
        public string GetName() => name;

        /// <summary>
        /// Gets user's wins total
        /// </summary>
        /// <returns>returns an int with user's wins</returns>
        public int GetWinsTotal() => winsTotal;

        /// <summary>
        /// Returns user's index
        /// </summary>
        /// <returns>returns in with user's index</returns>
        public int GetIndex() => index;

        /// <summary>
        /// Gets user score.
        /// </summary>
        /// <returns>returns an integer with user score.</returns>
        public int GetScore() => score;

        /// <summary>
        /// Increments Wins total
        /// </summary>
        public void IncrementWinsTotal() => winsTotal++;

        /// <summary>
        /// Sets user's index
        /// </summary>
        public void SetIndex(int index) => this.index = index;

        /// <summary>
        /// Increments user score
        /// </summary>
        public void IncrementScore() => score++;
    }
}