using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YachtDice
{
    class Dice
    {
        ConsoleKeyInfo keyInput = new ConsoleKeyInfo();        
        ConsoleKeyInfo stopInput = new ConsoleKeyInfo();        
        int[] dices = new int[6] {1,2,3,4,5,6};
        bool[] isdiceRoll = new bool[6];
        Random shuffleDice = new Random();       
        
         
        public void StopDice()
        { 
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                if (isdiceRoll[i] == false)
                {
                    int temp = dices[i];
                }
                dices[i] = shuffleDice.Next(1, 7);
                isdiceRoll[i] = true;

                Console.Write(dices[i] + "　");                
            }
            
        }

        public void JustDice()
        {
            Console.Clear() ;
            for (int i = 0; i < 5; i++)
            {                
                Console.Write(dices[i] + "　");
            }
            Console.WriteLine("\n주사위 굴리기 : SpaceBar");
            keyInput = Console.ReadKey();
            if (keyInput.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                RollingDice();                    
            }            
        }

        public void RollingDice()
        {
            while (true)
            {                
                for (int i = 0; i < 5; i++)
                {
                    dices[i] = shuffleDice.Next(1, 7);
                    Console.Write(dices[i] + "　");
                }
                Console.WriteLine("\n주사위 멈추기 : SpaceBar");
                Thread.Sleep(20);
                Console.Clear();
                if (Console.KeyAvailable == true)
                {
                    stopInput = Console.ReadKey();
                    if (stopInput.Key == ConsoleKey.Spacebar)
                    {
                        StopDice();
                        break;
                    }
                }
            }            
        }

        public void ChooseDice()
        {
            Console.Clear();
        }
        
    }
}
