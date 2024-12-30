using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YachtDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();            
            IntroScreen introscreen = new IntroScreen();
            ScoreBoard scoreboard = new ScoreBoard();
            //int[] ints = new int[] { 3,4,3,4,6};

            //dice.SetPointInBoard(scoreboard);
            //scoreboard.SetScoreBoard();

            //scoreboard.CompareDices(ints);
            introscreen.ShowIntroScreen();
            //scoreboard.SetScoreBoard();
            //dice.DDDDDDice();
        }
    }
}
