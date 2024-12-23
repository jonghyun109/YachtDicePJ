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
        ScoreBoard scoreboard;
        public int[] dices = new int[5];
        bool[] isdiceRoll = new bool[5];
        Random shuffleDice = new Random();
        int rollCount = 0;
        int currentSelet = 0;

        
        public Dice()
        {
            for (int i = 0; i < 5; i++)
            {
                dices[i] = shuffleDice.Next(1, 7);
                isdiceRoll[i] = true;                
            }
            
        }       
        public void StartGame()
        {
            for(int i=0; i<isdiceRoll.Length;i++)
            {
                isdiceRoll[i] = true;
            }         
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dices[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("\n주사위 굴리기 : SpaceBar");

            while (true)
            {
                rollCount = 0;
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Spacebar)
                {
                    RollingDice();
                    break;
                }
            }
        }

        public void StopDice()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                if (isdiceRoll[i])
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(dices[i] + " ");
                Console.ResetColor();
                
            }
            Console.WriteLine();
        }

        public void RollingDice()
        {
            while (rollCount < 3)
            {
                bool isRolling = true;
                while (isRolling)
                {
                    Console.Clear();
                    for (int i = 0; i < 5; i++)
                    {
                        if (isdiceRoll[i])
                        {
                            dices[i] = shuffleDice.Next(1, 7);
                        }
                        if (isdiceRoll[i])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(dices[i] + " ");
                        Console.ResetColor();
                    }
                    Console.WriteLine($"\n\n주사위 멈추기 : SpaceBar (남은 횟수: {3 - rollCount})");
                    Thread.Sleep(20);

                    if (Console.KeyAvailable)
                    {
                        var input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.Spacebar)
                        {
                            isRolling = false;
                            rollCount++;
                        }
                    }
                }

                StopDice();
                Console.WriteLine($"\n다시 굴리기 : SpaceBar\n멈출 주사위 선택 : Enter (남은 횟수: {3 - rollCount})");
                scoreboard = new ScoreBoard();
                scoreboard.InGameDisplayBoard();
                scoreboard.CompareDices(dices);

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        var input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.Spacebar)
                        {
                            break;
                        }
                        else if (input.Key == ConsoleKey.Enter)
                        {
                            ChooseDice(); // 주사위 선택
                            break;
                        }
                    }
                }                
            }
            Console.Clear();
            Console.WriteLine("굴리기 횟수를 모두 사용했습니다.");
            StopDice();
        }

        public void ChooseDice()
        {
            
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("주사위를 선택하세요 \n이동 : ← →  \n선택/해제 : SpaceBar  \n완료 후 다시 굴리기 : Enter ");
                
                for (int i = 0; i < 5; i++)
                {
                    // 선택된 주사위는 회색 배경으로 강조 표시
                    if (i == currentSelet)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    if (isdiceRoll[i])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(dices[i] + " ");
                    Console.ResetColor();
                }

                var input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Enter)
                { break; }

                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    currentSelet = (currentSelet + 4) % 5;
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    currentSelet = (currentSelet + 1) % 5;
                }
                else if (input.Key == ConsoleKey.Spacebar)
                {
                    isdiceRoll[currentSelet] = !isdiceRoll[currentSelet];
                }
                
            }
        }
    }


}







