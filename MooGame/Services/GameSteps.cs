using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MooGame.Interfaces;



namespace MooGame
{
    public  class GameSteps
    {        

        private  readonly IUserInterface _ui;

        public GameSteps(IUserInterface ui)       // Constructor
        {
            _ui = ui;
       
        }


        public  string InsertPlayerName()                                 
        {
            _ui.output("Enter your user name:\n");
            string name = _ui.input();
            return name;
        }

        public  void ShowMagicNumber(string goal, bool show = true)
        {
            _ui.output("New game:\n");
            if(show == true)
                //Only in development environment
                Console.WriteLine("For practice, number is: " + goal + "\n");
            else
            {
                string hiddenGoal = new String('*', goal.Length);
                _ui.output("The nummber is "+ hiddenGoal);
            }
        }
     
        public  int PlayTheGame(string goal)
        {
            string guess = _ui.input();
            int nGuess = 1;
            string bbcc = GoalManager.checkBC(goal, guess);
            _ui.output(bbcc + "\n");

            string BBBB = new String('B', goal.Length);     //added code line

            while (bbcc != BBBB + ",")                     //modified line of code --> while (bbcc != "BBBB,")   
            {
                nGuess++;
                guess = _ui.input();
                _ui.output(guess + "\n");
                bbcc = GoalManager.checkBC(goal, guess);
                _ui.output(bbcc + "\n");
            }
            return nGuess;
        }

        /// <summary> choose if to continue or end the game. The game ends only if it´s n </summary>
        public  bool TheEndGame(int nGuess)                                                               
        {
            _ui.output("Correct, it took " + nGuess + " guesses\nContinue?");
            string answer = _ui.input();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }
            else return true;
        }
    }
}
