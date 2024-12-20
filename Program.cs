using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtDice
{
    class Program
    {
        static void Main(string[] args)
        {            
            Dice dice = new Dice();
            EndScreen endScreen = new EndScreen();
            IntroScreen introscreen = new IntroScreen();

            introscreen.ShowIntroScreen();
            //dice.DDDDDDice();
        }
    }
}
