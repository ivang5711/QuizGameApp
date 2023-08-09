using System;
using System.Collections.Generic;
namespace QuizLibrary
{
    public class QuizUsers
    {
        private readonly List<string> users;

        public QuizUsers()
        {
            users = new List<string>();
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
        /// Gets users count from the Users property.
        /// </summary>
        /// <returns>Return Users count.</returns>
        public int GetUsersCount()
        {
            return users.Count;
        }
    }
}
