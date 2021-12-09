using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.NewGames
{
   public class GameModel
    {
        public int id { get; set; }

        public string name { get; set; }   // nome del gioco

        public string description { get; set; }  // descrizione del gioco

        public string FileName { get; set; }   // nome del file dove é memorizzato il gioco

        public int LenghtGoal { get; set; }   // lunghezza in termini di cifre del numero da indovinare

        public int MaxDigit { get; set; } // numero max di cifre

        public int MinDigit { get; set; }   // numero min di cifre
        

    }


   
}
