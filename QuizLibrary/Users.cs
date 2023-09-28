using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModelsLibrary
{
    public class Users
    {
        private readonly List<User> usersList;

        public Users()
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

            usersList.Add(new User(user, 0));
        }

        /// <summary>
        /// Adds a user at a picked index
        /// </summary>
        /// <param name="user"></param>
        /// <param name="index"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddUser(string user, int index)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentException(user, nameof(user));
            }

            usersList.Add(new User(user, 0, index));
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
        public void AddScore(int index)
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
        /// <returns>Returns an int with the index of the winner or -1 if there is no game being played yet or if there are more than 1 winner detected.</returns>
        public int GetWinner()
        {
            if (usersList.Count == 0)
            {
                return -1;
            }

            List<int> usersScores = new List<int>();
            foreach (User item in usersList)
            {
                usersScores.Add(item.GetUserScore());
            }

            int a = -1;
            int counter = 0;
            for (int i = 0; i < usersScores.Count; i++)
            {
                if (usersScores[i] == usersScores.Max())
                {
                    a = i;
                    counter++;
                }
            }

            if (counter > 1 || usersScores.Count == 1)
            {
                a = -1;
            }

            return a;
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

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>Returns a list of Users</returns>
        public List<User> GetAllUsers()
        {
            return usersList;
        }

        /// <summary>
        /// Saves users and score to CSV file.
        /// </summary>
        /// <param name="fileName">Provide a file name to store users data to. I.e. "users.csv"</param>
        public void SaveToCSV(string fileName)
        {
            string file = fileName;
            string separator = ",";
            StringBuilder output = new StringBuilder();
            string[] headings = { "name", "winsTotal" };
            output.AppendLine(string.Join(separator, headings));
            foreach (User user in usersList)
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

        /// <summary>
        /// Reads data from csv file and loads it to the memory
        /// </summary>
        /// <param name="fileName">Provide a file name to read users data from. I.e. "users.csv"</param>
        public void ReadFromCSV(string fileName)
        {
            string file = fileName;
            if (File.Exists(Path.Combine(file)))
            {
                List<string> keys = new List<string>();
                List<string> values = new List<string>();
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split(',');
                        keys.Add(data[0]);
                        values.Add(data[1]);
                    }
                }

                if (keys.Count > 1)
                {
                    for (int i = 1; i < keys.Count; i++)
                    {
                        usersList.Add(new User(keys[i], int.Parse(values[i])));
                    }
                }
            }
        }
    }
}