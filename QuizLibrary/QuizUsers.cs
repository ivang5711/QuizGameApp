using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizLibrary
{
    public class QuizUsers
    {
        private readonly List<User> usersList;
        public QuizUsers()
        {
            usersList = new List<User>();
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

            usersList.Add(new User($"{user}", 0));
        }

        /// <summary>
        /// Gets Users List from the Users property.
        /// </summary>
        /// <returns>Return Users List.</returns>
        public List<string> GetUserNames()
        {
            List<string> usersTemp = new List<string>();
            foreach (User item in usersList)
            {
                usersTemp.Add(item.GetUserName());
            }

            return usersTemp;
        }

        /// <summary>
        /// Gets the list of scores of all users.
        /// </summary>
        /// <returns>Returns a list of integers.</returns>

        public List<int> GetScores()
        {
            List<int> usersScores = new List<int>();
            foreach (User item in usersList)
            {
                usersScores.Add(item.GetUserScore());
            }

            return usersScores;
        }

        /// <summary>
        /// Increments the score of a user by 1.
        /// </summary>
        /// <param name="index">An index of a given user in the List of Users.</param>
        /// <exception cref="ArgumentOutOfRangeException">Checks if an index of a given user is within range and throws an exception otherwise.</exception>
        public void AddScores(int index)
        {
            if (index < 0 || index >= usersList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            usersList[index].IncrementScore();
        }

        /// <summary>
        /// Gets the score of a user.
        /// </summary>
        /// <param name="index">An index of a given user in the List of Users.</param>
        /// <returns>Returns a score of a given user.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Checks if an index of a given user is within range and throws an exception otherwise.</exception>
        public int GetScore(int index)
        {
            if (index < 0 || index >= usersList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return usersList[index].GetUserScore();
        }

        /// <summary>
        /// Gets users count from the Users property.
        /// </summary>
        /// <returns>Return Users count.</returns>
        public int GetUsersCount()
        {
            return usersList.Count;
        }

        /// <summary>
        /// Gets winner of a game.
        /// </summary>
        /// <returns>Returns a string with the name of the winner or "no winner" string if there is no game being played yet.</returns>
        public string GetWinner()
        {
            List<int> usersScores = new List<int>();
            foreach (User item in usersList)
            {
                usersScores.Add(item.GetUserScore());
            }

            if (usersScores.Count == 0)
            {
                return "no winner";
            }

            int maximum = usersScores.Max();
            int i;
            for (i = 0; i < usersScores.Count; i++)
            {
                if (usersScores[i] == maximum)
                {
                    break;
                }
            }

            return usersList[i].GetUserName();
        }

        /// <summary>
        /// Gets a Users object from the usersList.
        /// </summary>
        /// <param name="index">integer index of a particular user.</param>
        /// <returns>returns an object of type User.</returns>
        public User GetUserObject(int index)
        {
            return usersList[index];
        }

        public List<User> GetAllUsers()
        {
            return usersList;
        }
    }
}
