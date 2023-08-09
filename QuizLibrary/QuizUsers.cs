using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizLibrary
{
    public class QuizUsers
    {
        private readonly List<string> users;
        private readonly List<int> scores;
        public QuizUsers()
        {
            users = new List<string>();
            scores = new List<int>();
        }

        /// <summary>
        /// Adds a user to the Users property.
        /// </summary>
        /// <param name="user">Gets string "user" as an input</param>
        /// <exception cref="ArgumentException">Throws an exception if the user string is null, empty or Whitespace.</exception>
        public void AddUser(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentException(user, nameof(user));
            }

            users.Add(user);
            scores.Add(0);
        }

        /// <summary>
        /// Gets Users List from the Users property.
        /// </summary>
        /// <returns>Return Users List.</returns>
        public List<string> GetUsers()
        {
            return users;
        }

        /// <summary>
        /// Gets the list of scores of all users.
        /// </summary>
        /// <returns>Returns a list of integers.</returns>

        public List<int> GetScores()
        {
            return scores;
        }

        /// <summary>
        /// Increments the score of a user by 1.
        /// </summary>
        /// <param name="index">An index of a given user in the List of Users.</param>
        /// <exception cref="ArgumentOutOfRangeException">Checks if an index of a given user is within range and throws an exception otherwise.</exception>
        public void AddScores(int index)
        {
            if (index < 0 || index >= scores.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            scores[index]++;
        }

        /// <summary>
        /// Gets the score of a user.
        /// </summary>
        /// <param name="index">An index of a given user in the List of Users.</param>
        /// <returns>Returns a score of a given user.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Checks if an index of a given user is within range and throws an exception otherwise.</exception>
        public int GetScore(int index)
        {
            if (index < 0 || index >= scores.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return scores[index];
        }

        /// <summary>
        /// Gets users count from the Users property.
        /// </summary>
        /// <returns>Return Users count.</returns>
        public int GetUsersCount()
        {
            return users.Count;
        }

        /// <summary>
        /// Gets winner of a game.
        /// </summary>
        /// <returns>Returns a string with the name of the winner or "no winner" string if there is no game being played yet.</returns>
        public string GetWinner()
        {
            if (scores.Count == 0)
            {
                return "no winner";
            }
            int maximum = scores.Max();
            int i;
            for (i = 0; i < scores.Count; i++)
            {
                if (scores[i] == maximum)
                {
                    break;
                }
            }

            return users[i];
        }
    }
}
