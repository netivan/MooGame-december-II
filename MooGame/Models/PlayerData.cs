using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{ /// <summary>  This class contains the data of the player </summary>
	public class PlayerData
	{

		
		public string Name { get; private set; }
		public int NGames { get; private set; }
		
		int totalGuess;  // quante ne sono state azzeccate


		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NGames = 1;
			totalGuess = guesses;
		}

		public void Update(int guesses)
		{
			totalGuess += guesses;
			NGames++;
		}

		public double Average()
		{
			return (double)totalGuess / NGames;
		}


		public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
