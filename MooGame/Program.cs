using MooGame.NewGames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MooGame.Interfaces;
using Microsoft.Extensions.DependencyInjection;



namespace MooGame
{
	 class MainClass 
	{
		public const bool IsDevelopment = true;         // IsDevelopment  = is under development         // true = In fase di sviluppo del progetto il codice da indovinare si vede
		public static void Main(string[] args)
		{

            var services = new ServiceCollection()
                .AddSingleton<IUserInterface, ConsoleIO>()
                .AddSingleton<IFileInterface, FileIO>()
            .BuildServiceProvider();

            var ui = services.GetService<IUserInterface>();

            var fi = services.GetService<IFileInterface>();




            GameList gameList = new GameList(ui, fi);

            GameSteps gameSteps = new GameSteps(ui);

            DataManager dataManager = new DataManager(ui, fi);

            var Game = gameList.SelectGame();

            string name = gameSteps.InsertPlayerName();

			while (!String.IsNullOrEmpty(name)) //Player name is required to play
			{
                //string goal = GoalManager.makeGoal();

                string goal = GoalManager.makeGoal(Game.LenghtGoal, Game.MaxDigit, Game.MinDigit);     //xx

                gameSteps.ShowMagicNumber(goal, IsDevelopment);

				var nGuess = gameSteps.PlayTheGame(goal);

                //DataManager.SaveTheGame(name + "#&#" + nGuess);

                dataManager.SaveTheGame(name + "#&#" + nGuess, Game.FileName);    //xx

                //DataManager.showTopList();

                dataManager.showTopList(Game.FileName);       //xx

                if ( gameSteps.TheEndGame(nGuess) == false) break;
			}	
				
		}

	}
}