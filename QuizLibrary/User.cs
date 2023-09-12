﻿namespace QuizLibrary
{
    public class User
    {
        private readonly string name;
        private int score;
        private int index;
        private int winsTotal;

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
        public User(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Creates a new User and sets a winsTotal specified.
        /// </summary>
        /// <param name="name">string representing name.</param>
        /// <param name="winsTotal">integer represents initial winsTotal.</param>
        public User(string name, int winsTotal)
        {
            this.name = name;
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
            this.name = name;
            this.index = index;
            this.winsTotal = winsTotal;
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

        /// <summary>
        /// Increments Wins total
        /// </summary>
        public void IncrementWinsTotal()
        {
            winsTotal++;
        }

        /// <summary>
        /// Gets user's wins total
        /// </summary>
        public int GetWinsTotal()
        {
            return winsTotal;
        }

        /// <summary>
        /// Sets user's index
        /// </summary>
        public void SetIndex(int index)
        {
            this.index = index;
        }

        /// <summary>
        /// Returns user's index
        /// </summary>
        public int GetIndex()
        {
            return index;
        }
    }
}