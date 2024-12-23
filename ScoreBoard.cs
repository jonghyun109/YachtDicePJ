using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YachtDice
{
    
    enum Scores
    {
        Aces,
        Deuces,
        Threes,
        Fours,
        Fives,
        Sixes,
        Choice,
        FourOfaKind,
        FullHouse,
        SStraight,
        LStraight,
        Yacht,        
    }
    
    class ScoreBoard : Dice
    {
        int currentPos = 0;
        int leftCursor = 50;
        int topCursor = 0;
        ConsoleKeyInfo inputKey = new ConsoleKeyInfo();
        string[] scoreName = Enum.GetNames(typeof(Scores));
        bool isDiceNums = false;
        
        
        public void InGameDisplayBoard()
        {    
            foreach (string board in scoreName)
            {
                Console.SetCursorPosition(leftCursor, topCursor);
                Console.WriteLine(board);
                topCursor++;
            }
            topCursor = 0;
        }

        public int SetScoreBoard()
        {
            int[] score = new int[scoreName.Length];
            topCursor = 0;
            InGameDisplayBoard();
            CompareDices(dices);
            for (int i = 0; i < score.Length; i++)
            {
                score[i] = currentPos;
            }
            while (true)
            { 
                Console.SetCursorPosition(leftCursor, topCursor);
                inputKey = Console.ReadKey();

                if (inputKey.Key == ConsoleKey.Enter) break;
                
                else if (inputKey.Key == ConsoleKey.UpArrow)
                {
                    topCursor = (topCursor + 11) % 12;
                    Console.SetCursorPosition(leftCursor, topCursor);

                }
                else if (inputKey.Key == ConsoleKey.DownArrow)
                {
                    topCursor = (topCursor + 1) % 12;
                    Console.SetCursorPosition(leftCursor, topCursor);
                }                
            }
            return score[topCursor];
        }

        public void CompareDices(int[] dices)
        {
            //숫자들 정렬
            
            //숫자들
            int[] numsSum = new int[6];
            InGameDisplayBoard();

            foreach (int dice in dices)
            {
                numsSum[dice - 1] += dice;
            }
                        
            for(int i=0; i<numsSum.Length;i++)
            {
                Console.SetCursorPosition(65, topCursor);
                Console.WriteLine(numsSum[i]);
                topCursor++;
            }

            //전체합
            Console.SetCursorPosition(65, topCursor);
            Console.WriteLine(dices.Sum());
            topCursor++;

            //포카드
            bool isFourOfKind = false;
            int fourOfKindNum = 0;
            int[] counts = new int[6];
            Console.SetCursorPosition(65, topCursor);

            foreach (int dice in dices)
            {
                counts[dice - 1]++;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] == 4 || counts[i] == 5)
                {
                    isFourOfKind = true;
                    fourOfKindNum += dices[i];
                }
            }
            if(isFourOfKind)
            {
                Console.WriteLine(fourOfKindNum*4);
            }
            else
            {
                Console.WriteLine(0);
            }
            topCursor++;

            //풀하우스
            int[] countsFH = new int[6];
            bool isFullHouse = false;
            
            Console.SetCursorPosition(65, topCursor);  
            
            foreach (int dice in dices)
            {
                countsFH[dice - 1]++;                
            }

            bool hasThree = false;
            bool hasTwo = false;
                        
            for (int i = 0; i < countsFH.Length; i++)
            {
                if (countsFH[i]==3)
                { hasThree = true; }

                else if (countsFH[i]==2)
                { hasTwo = true; }
            }

            if(hasThree&&hasTwo)
            { isFullHouse = true; }

            if(isFullHouse)
            { Console.WriteLine(dices.Sum()); }

            else 
            { Console.WriteLine(0); }
            topCursor++;

            //스몰스트레이트
            Console.SetCursorPosition(65, topCursor);
            int[] countSS = new int[6];
            int countSmallStraight = 1;
            bool isSmallStraight = false;

            int[] dicesClones = (int[])dices.Clone();
            Array.Sort(dicesClones);
                        
            for(int i=1;i< dicesClones.Length;i++)
            {
                if (dicesClones[i]== dicesClones[i-1]+1)
                {
                    countSmallStraight++;
                    if (countSmallStraight>=4)
                    {
                        isSmallStraight = true;
                    }                    
                }
                else if (dicesClones[i]!= dicesClones[i-1]+1)
                {
                    countSmallStraight=1;
                }
            }            
            if (isSmallStraight)
            { Console.WriteLine(15); }
            else
            { Console.WriteLine(0); }
            topCursor++;


            //라지스트레이트
            Console.SetCursorPosition(65, topCursor);
            int[] countBS = new int[6];
            int countLargeStraight = 1;
            bool isLargeStraight = false;
            
            Array.Sort(dicesClones);
                        
            for (int i = 1; i < dicesClones.Length; i++)
            {
                if (dicesClones[i] == dicesClones[i - 1] + 1)
                {
                    countLargeStraight++;
                    if (countSmallStraight == 5)
                    {
                        isLargeStraight = true;
                    }
                }
                else if (dicesClones[i] != dicesClones[i - 1] + 1)
                {
                    countLargeStraight = 1;
                }
            }
            if (isLargeStraight)
            { Console.WriteLine(30); }
            else
            { Console.WriteLine(0); }
            topCursor++;

            //요트
            Console.SetCursorPosition(65, topCursor);
            int[] countFive = new int[6];
            bool isYatch = false;

            foreach(int dice in dices)
            {
                countFive[dice - 1]++;
            }
            for (int i = 0; i < countFive.Length; i++)
            {
                if (countFive[i] == 5)
                {
                    isYatch = true;                    
                }
            }
            if (isYatch)
            {
                Console.WriteLine(50);
            }
            else
            {
                Console.WriteLine(0);
            }
            topCursor++;

        }
    }
}
