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
        ConsoleKeyInfo stopKey = new ConsoleKeyInfo();
        
        
        int[] dices = new int[6] { 1, 2, 3, 4, 5, 6 };
        int[] _dices;
        public int[] Dices 
        { 
            get { return _dices; } 
            set { _dices = value; }
        }

        bool[] isdiceRoll = new bool[6];
        Random shuffleDice = new Random();       
        
        
        public void StopDice()
        { 
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                if (isdiceRoll[i] == true)
                {
                    dices[i] = shuffleDice.Next(1, 7);                    
                }

                int temp = dices[i];
                
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
                    stopKey = Console.ReadKey();
                    if (stopKey.Key == ConsoleKey.Spacebar)
                    {
                        ChooseDice();
                        break;
                    }
                }
            }            
        }
        public void ChooseDice()
        {
            
            StopDice();
            Console.WriteLine("\n멈출 주사위를 선택해주세요");            
            {
                
            }
        }
        
        //LinkedList<Dice> allDices = new LinkedList<Dice>();
        //public void DDDDDDice()
        //{
        //    Dice dice1 = new Dice();
            
        //    dices[0] = shuffleDice.Next(1, 7);
            
        //    dice1.dices = dices;
        //    allDices.AddLast(dice1);

        //    Console.WriteLine(allDices.Last.Next);
            
            
        //    foreach (Dice dice in new LinkedList<Dice>(allDices))
        //    {
        //        dice.shuffleDice.Next(1,7);
        //        Console.WriteLine(dice._dices);
        //    }
            
        //}
    }
}
