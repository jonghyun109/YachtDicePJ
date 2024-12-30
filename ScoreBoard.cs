using System;
using System.Linq;

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

    class ScoreBoard
    {
        private bool[] categoryUsed = new bool[12];
        private int[] categoryScores = new int[12];
        private int leftCursor = 50;
        private int topCursor = 0;
        private string[] scoreName = Enum.GetNames(typeof(Scores));

        public void InGameDisplayBoard()
        {
            topCursor = 0;
            foreach (string board in scoreName)
            {
                Console.SetCursorPosition(leftCursor, topCursor);
                Console.WriteLine($"{(topCursor + 1)}. {board}");
                topCursor++;
            }

            topCursor = 0;
        }

        public void SetScoreBoard(Player player)
        {
            int[] stoppedDices = player.GetStoppedDice();
            CompareDices(stoppedDices);
        }

        public void CompareDices(int[] dices)
        {
            //숫자들            
            int[] numsSum = new int[6];
            InGameDisplayBoard();

            foreach (int dice in dices)
            {
                if (dice < 1 || dice > 6)
                {
                    return;
                }

                numsSum[dice - 1] += dice;
            }

            for (int i = 0; i < numsSum.Length; i++)
            {
                Console.SetCursorPosition(65, topCursor);
                if (categoryUsed[i])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(categoryScores[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(numsSum[i]); // 새로 계산된 점수 출력
                }
                Console.ResetColor();
                topCursor++;
            }

            //전체합

            Console.SetCursorPosition(65, topCursor);
            if (categoryUsed[6]) // Choice가 이미 입력된 경우
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(categoryScores[6]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(dices.Sum());
            }
            Console.ResetColor();
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
                    fourOfKindNum = (i + 1);
                }
            }
            if (categoryUsed[7])
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(categoryScores[7]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (isFourOfKind)
                {
                    Console.WriteLine(fourOfKindNum * 4);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }

            Console.ResetColor();
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
                if (countsFH[i] == 3)
                { hasThree = true; }

                else if (countsFH[i] == 2)
                { hasTwo = true; }
            }
            if (categoryUsed[8])
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(categoryScores[8]);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (hasThree && hasTwo)
                { isFullHouse = true; }

                if (isFullHouse)
                { Console.WriteLine(dices.Sum()); }

                else
                { Console.WriteLine(0); }

            }
            Console.ResetColor();
            topCursor++;


            //스몰스트레이트
            Console.SetCursorPosition(65, topCursor);
            int[] countSS = new int[6];
            int countSmallStraight = 1;
            bool isSmallStraight = false;

            int[] dicesClones = (int[])dices.Clone();
            Array.Sort(dicesClones);

            for (int i = 1; i < dicesClones.Length; i++)
            {
                if (dicesClones[i] == dicesClones[i - 1] + 1)
                {
                    countSmallStraight++;
                    if (countSmallStraight >= 4)
                    {
                        isSmallStraight = true;
                    }
                }
                else if (dicesClones[i] != dicesClones[i - 1] + 1)
                {
                    countSmallStraight = 1;
                }
            }

            if (categoryUsed[9])
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(categoryScores[9]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (isSmallStraight)
                {
                    Console.WriteLine(15);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            Console.ResetColor();
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
            if (categoryUsed[10])
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(categoryScores[10]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (isLargeStraight)
                { Console.WriteLine(30); }
                else
                { Console.WriteLine(0); }

            }
            Console.ResetColor();
            topCursor++;

            //요트
            Console.SetCursorPosition(65, topCursor);
            int[] countFive = new int[6];
            bool isYatch = false;

            foreach (int dice in dices)
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
            if (categoryUsed[11])
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(categoryScores[11]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (isYatch)
                {
                    Console.WriteLine(50);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            Console.ResetColor();

            topCursor++;

        }
        public bool IsCategoryUsed(int index)
        {
            return categoryUsed[index];
        }

        public void MarkCategoryUsed(int index, int score)
        {
            if (!categoryUsed[index])
            {
                categoryUsed[index] = true; // 해당 카테고리를 사용으로 표시
                categoryScores[index] = score; // 점수를 저장
            }
            else
            {
                Console.WriteLine("그곳은 이미 입력되어있습니다");
            }
        }
        public void DisplayFinalScore()
        {
            Console.WriteLine("최종 점수판:");
            string[] categories = { "Aces", "Deuces", "Threes", "Fours", "Fives", "Sixes", "Choice", "Four of a Kind", "Full House", "Small Straight", "Large Straight", "Yacht" };

            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{categories[i]}: {(categoryUsed[i] ? categoryScores[i] : 0)}");
            }
        }
        public int GetTotalScore()
        {
            return categoryScores.Sum();
        }

    }
}