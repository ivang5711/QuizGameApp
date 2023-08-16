using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        public void AddUser(string user, int index)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentException(user, nameof(user));
            }

            usersList.Add(new User($"{user}", 0, index));
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
        /// Increments the winsTotal of a user by 1.
        /// </summary>
        /// <param name="index">An index of a given user in the List of Users.</param>
        /// <exception cref="ArgumentOutOfRangeException">Checks if an index of a given user is within range and throws an exception otherwise.</exception>
        public void AddWin(int index)
        {
            if (index < 0 || index >= usersList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            usersList[index].IncrementWinsTotal();
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
        public int GetWinner()
        {
            List<int> usersScores = new List<int>();
            foreach (User item in usersList)
            {
                usersScores.Add(item.GetUserScore());
            }

            if (usersScores.Count == 0)
            {
                return -1;
            }

            int maximum = usersScores.Max();
            int i;
            int a;
            int counter;
            for (i = 0; i < usersScores.Count; i++)
            {
                if (usersScores[i] == maximum)
                {
                    break;
                }
            }

            return i;
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

        /// <summary>
        /// Saves users and score to CSV file.
        /// </summary>
        public void SaveToCSV(QuizUsers userInstance)
        {
            var records = userInstance.GetAllUsers();
            string file = $@"..\\user-score.csv";
            string separator = ",";
            StringBuilder output = new StringBuilder();
            string[] headings = { "name", "winsTotal" };
            output.AppendLine(string.Join(separator, headings));
            foreach (User user in records)
            {
                string[] newLine = { user.GetUserName(), user.GetWinsTotal().ToString() };
                output.AppendLine(string.Join(separator, newLine));
            }

            try
            {
                File.WriteAllText(file, output.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
            }

            Console.WriteLine("The data has been successfully saved to the CSV file");
        }
    }
}
