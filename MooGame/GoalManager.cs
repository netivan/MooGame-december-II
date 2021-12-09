using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
  public  class GoalManager
    {
        //TODO: da modificare se vogliamo aggiungere un an´altro gioco

        /// <summary>when the input parameters are not defined
        /// creates a 4-digit number between 0 and 9 
        /// The digits are all different
        /// </summary>
        /// 
        public static string makeGoal(int LenghtGoal = 4, int MaxDigit = 9, int MinDigit = 0)      // modified ->  public static string makeGoal() 
        {
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < LenghtGoal; i++)
			{
				int random = randomGenerator.Next(MinDigit,MaxDigit +1);    // modified -> int random = randomGenerator.Next(0,10); 
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(MinDigit, MaxDigit +1);       // modified  random = randomGenerator.Next(0,10); 
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}

		/// <summary> Check how many digits have been guessed</summary> 
		/// <param name="goal">The number to guess to</param> 
		/// <param name="guess">The number proposed by the player</param>  

		public static string checkBC(string goal, string guess)
		{
			int LenghtGoal = goal.Length;
			int cows = 0, bulls = 0;
			guess += "        ";     // if player entered less than  chars of the goal
			for (int i = 0; i < goal.Length; i++)
			{
				for (int j = 0; j < goal.Length; j++)
				{
					if (goal[i] == guess[j])
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}
				}
			}
			
			//return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
			return new String('B', bulls)+","+ new String('C', cows);
		}




	}
}
