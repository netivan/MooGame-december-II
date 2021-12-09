using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    /// <summary>
    /// This class manages the game results obtained by the various players
    /// </summary>
    public class DataManager 
    {
        private static readonly IFileInterface _fl = new FileIO();
        private static readonly IUserInterface _ui = new ConsoleIO();
        /// <summary>
        /// Save the game result and player name to file
        /// </summary>
        /// <param name="s">game result and player name</param>
        /// <param name="fileName"></param>
        public static void SaveTheGame(string s, string fileName = "results.txt")
        {
            _fl.save(s, fileName);
        }

        /// <summary>
        /// Read the results of previous games from the file
        /// 
        /// </summary>
        /// <param name="fileName">Name of the file where the data is located</param>
        public static void showTopList(string fileName = "results.txt")
        {

            var results = CreateListFromFile(fileName);
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));        /////////???????????
            _ui.output("Player   games average");
            foreach (PlayerData p in results.OrderByDescending(p => p.Average()))
            {
                _ui.output(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
           
        }
        /// <summary>
        /// Read the player's data from the file and put it in a list
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static List<PlayerData>CreateListFromFile(string fileName)
        {
            var input = _fl.ReadFile(fileName);
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);        ////////??????????
                }
            }
            input.Close();
            return results;
        }
    }
}
