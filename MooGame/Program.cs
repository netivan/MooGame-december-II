using MooGame.NewGames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MooGame
{
	 class MainClass
	{
		public const bool IsDevelopment = false;         // IsDevelopment  = é in fase di sviluppo         // true = In fase di sviluppo del progetto il codice da indovinare si vede
		public static void Main(string[] args)
		{

            GameList gameList = new GameList();
            //var Game = gameList.SelectGame();

            string name = GameSteps.InsertPlayerName();

			while (!String.IsNullOrEmpty(name)) //Player name is required to play
			{
				string goal = GoalManager.makeGoal();

				//string goal = GoalManager.makeGoal(Game.LenghtGoal, Game.MaxDigit, Game.MinDigit);

				GameSteps.ShowMagicNumber(goal, IsDevelopment);

				var nGuess = GameSteps.PlayTheGame(goal);

				DataManager.SaveTheGame(name + "#&#" + nGuess);

				//DataManager.SaveTheGame(name + "#&#" + nGuess, Game.FileName);

				DataManager.showTopList();

				//DataManager.showTopList(Game.FileName);

				if ( GameSteps.TheEndGame(nGuess) == false) break;
			}	
				
		}

	}
}