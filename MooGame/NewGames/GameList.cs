using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MooGame.Interfaces;

namespace MooGame.NewGames
{
    public class GameList
    {

        //private readonly IUserInterface _ui;

        //public GameList(IUserInterface ui )       // Constructor
        //{
        //    _ui = ui;
        //}

        private readonly IUserInterface _ui;

        private readonly IFileInterface _fi;

        public GameList(IUserInterface ui, IFileInterface fi)       // Constructor
        {
            _ui = ui;

            _fi = fi;
        }

        public List<GameModel> gameList = new List<GameModel>();


        //public GameList()
        //{
        //    gameList.Add(new GameModel { id = 1, name = "Bulls & Cows", description = "The player must guess 4 digits", FileName = "resultGame1.txt", LenghtGoal = 4, MaxDigit = 9, MinDigit = 0 });
        //    gameList.Add(new GameModel { id = 2, name = "Battle Bulls & Cows", description = "The player must guess 3 digits on 8 digits", FileName = "resultGame2.txt", LenghtGoal = 3, MaxDigit = 8, MinDigit = 0 });
        //    gameList.Add(new GameModel { id = 3, name = "Battle of Cows", description = "The player must guess .......", FileName = "resultGame3.txt", LenghtGoal = 3, MaxDigit = 8, MinDigit = 0 });
        //}

        public List<GameModel> ReadGameList()
        {
            List<GameModel> gameList = new List<GameModel>();

            var input = _fi.ReadGamesList();

            if(input != null)
            { 

            string line;
            while((line = input.ReadLine())!= null)
            {
                string[] game = line.Split(";");

                if(game.Length == 7)
                    {
                        try
                        {
                            gameList.Add(new GameModel { id = int.Parse(game[0]), name = game[1], description = game[2], FileName = game[3], LenghtGoal = int.Parse(game[4]), MaxDigit = int.Parse(game[5]), MinDigit = int.Parse(game[6]) });
                        }
                        catch { }
                        }                 

            }        
                   
            }
              return gameList;
        }




        public void PrintGame(GameModel game)
        {
           _ui.output($"The Game {game.id} {game.name} : {game.description} ");
        }

        public GameModel SelectGame()
        {
            //string d = "A";
            //while (true)
            //{
            //    _ui.output("select: single game A or multi game B");
            //    d = _ui.input();
            //    if (d is not null && (d == "A" || d == "B")) break;
            //}

            //if (d == "A") return gameList.FirstOrDefault(x => x.id == 1);


            var gameList = ReadGameList();

            if(gameList.Count() < 1)
            {
                return new GameModel { id = 1, name = "Bulls & Cows", description = "The player must guess 4 digits", FileName = "resultGame1.txt", LenghtGoal = 4, MaxDigit = 9, MinDigit = 0 }; 
            }
            foreach (var g in gameList)
            {
                _ui.output($"Game {g.id}: {g.name}");
            }

            while (true)
            {

                _ui.output("Choose Game:(1 for single game ");
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

