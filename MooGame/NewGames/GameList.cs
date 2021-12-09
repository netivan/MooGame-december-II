using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.NewGames
{
    public class GameList
    {

        private readonly IUserInterface _ui;

        public GameList(IUserInterface ui )       // Constructor
        {
            _ui = ui;
        }
            

        public List<GameModel> gameList = new List<GameModel>();

        public GameList()
        {
            gameList.Add(new GameModel { id = 1, name = "Bulls & Cows", description = "The player must guess 4 digits", FileName = "resultGame1.txt", LenghtGoal = 4, MaxDigit = 9, MinDigit = 0 });
            gameList.Add(new GameModel { id = 2, name = "Battle Bulls & Cows", description = "The player must guess 3 digits on 8 digits", FileName = "resultGame2.txt", LenghtGoal = 3, MaxDigit = 8, MinDigit = 0 });
        }

        public void PrintGame(GameModel game)
        {
           _ui.output($"The Game {game.id} {game.name} : {game.description} ");
        }

        public GameModel SelectGame()
        {
            foreach (var g in gameList)
            {
                _ui.output($"Game {g.id}: {g.name}");
            }

            while (true)
            {

                _ui.output("Choose Game:");
                var x = _ui.input();
                int gameNumber = 1;

                try
                {
                    gameNumber = int.Parse(x);
                }
                catch
                {
                    gameNumber = 0;
                }

                var selectedGame = gameList.FirstOrDefault(x => x.id == gameNumber);

                if (selectedGame != null)
                {
                    PrintGame(selectedGame);
                    return selectedGame;
                }
            }


        }


    }
}

