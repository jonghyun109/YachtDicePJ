using System;
using System.Linq;
using System.Threading;

namespace YachtDice
{
    class GameManager
    {
        public Player player;
        public Dice dice;
        public ScoreBoard scoreBoard;
        private int currentRound;

        public GameManager()
        {
            player = new Player();
            dice = new Dice();
            scoreBoard = new ScoreBoard();
            currentRound = 1;
        }

        public void StartGame()
        {
            while (currentRound <= 12)
            {
                Console.Clear();
                Console.WriteLine($"현재 라운드: {currentRound}");
                PlayRound();
            }

            Console.Clear();

            int totalScore = scoreBoard.GetTotalScore();
            string finalMessage = $"게임이 끝났습니다! 최종 점수: {totalScore} 점";

            int centerX = (Console.WindowWidth - finalMessage.Length) / 2;
            int centerY = Console.WindowHeight / 2;

            Console.SetCursorPosition(centerX, centerY);
            Console.WriteLine(finalMessage);
        }

        public bool PlayRound()
        {
            player.ResetDice();

            int rollCount = 0;

            while (rollCount < 3)
            {
                Console.Clear();
                DisplayDice(player.Dices, player.IsDiceRoll);
                scoreBoard.CompareDices(player.Dices); // 점수판 출력
                if (rollCount == 0)
                {
                    Console.WriteLine("\n주사위 굴리기 : [Space]");
                }
                else
                {
                    Console.WriteLine("\n주사위 굴리기 : [Space]\n선택 메뉴 : [Enter]\n점수판 : [S]");
                }
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Spacebar)
                {
                    RollingDice();
                    rollCount++;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    if (rollCount == 0)
                    {
                        Console.WriteLine("주사위를 한번 굴린후 가능합니다");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        ChooseDice();
                    }
                }
                else if (input.Key == ConsoleKey.S)
                {
                    if (rollCount == 0)
                    {
                        Console.WriteLine("주사위를 한번 굴린후 가능합니다");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        SelectScore();
                        return true; // 라운드 종료
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("3번 굴리기 완료\n점수를 입력합니다.");
            DisplayDice(player.Dices, player.IsDiceRoll);
            SelectScore();
            return true;
        }

        public void RollingDice()
        {
            Console.Clear();

            while (true)
            {
                int[] rolledValues = dice.RollDice(player.IsDiceRoll);
                for (int i = 0; i < rolledValues.Length; i++)
                {
                    if (player.IsDiceRoll[i])
                    {
                        player.Dices[i] = rolledValues[i];
                    }
                }

                Console.SetCursorPosition(0, 2);
                DisplayDice(player.Dices, player.IsDiceRoll);
                Console.WriteLine("\n[Space]를 눌러 멈추세요.");
                Thread.Sleep(20);

                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.Spacebar)
                    {
                        break;
                    }
                }
            }

            Console.Clear();
            DisplayDice(player.Dices, player.IsDiceRoll);
            scoreBoard.CompareDices(player.Dices);
            Console.WriteLine("\n주사위 굴리기 : [Space]\n선택 메뉴 : [Enter]\n점수판 : [S]");
        }



        public void ChooseDice()
        {
            Console.WriteLine("이동 : ← →\n선택/해제 : [Space] \n완료 : [Enter]");
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                DisplayDice(player.Dices, player.IsDiceRoll, selectedIndex);
                scoreBoard.CompareDices(player.Dices);
                Console.WriteLine("\n이동 : ← →\n선택/해제 : [Space] \n완료 : [Enter]");

                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.LeftArrow)
                {
                    selectedIndex = (selectedIndex + 4) % 5;
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    selectedIndex = (selectedIndex + 1) % 5;
                }
                else if (input.Key == ConsoleKey.Spacebar)
                {
                    player.IsDiceRoll[selectedIndex] = !player.IsDiceRoll[selectedIndex];
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            // 주사위 상태 출력 후 메뉴 다시 표시
            Console.Clear();
            DisplayDice(player.Dices, player.IsDiceRoll);
            scoreBoard.CompareDices(player.Dices);
            Console.WriteLine("\n주사위 굴리기 : [Space]\n선택 메뉴 : [Enter]\n점수판 : [S]");
        }

        public void StopDice()
        {
            scoreBoard.SetScoreBoard(player);
        }

        public void SelectScore()
        {
            Console.Clear();
            DisplayDice(player.Dices, player.IsDiceRoll);
            scoreBoard.CompareDices(player.Dices); // 현재 점수 표시

            Console.WriteLine($"\n현재 라운드: {currentRound}");
            Console.WriteLine("\n족보를 선택하세요:");
            string[] categories = { "Aces", "Deuces", "Threes", "Fours", "Fives", "Sixes", "Choice", "Four of a Kind", "Full House", "Small Straight", "Large Straight", "Yacht" };

            for (int i = 0; i < categories.Length; i++)
            {
                Console.ForegroundColor = scoreBoard.IsCategoryUsed(i) ? ConsoleColor.Blue : ConsoleColor.White;
                Console.WriteLine((i + 1) + ". " + categories[i]);
            }
            Console.ResetColor();

            int selectedCategory = -1;
            while (true)
            {
                Console.Write("선택 (1-12): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out selectedCategory) && selectedCategory >= 1 && selectedCategory <= 12)
                {
                    if (scoreBoard.IsCategoryUsed(selectedCategory - 1))
                    {
                        Console.WriteLine("그곳은 이미 입력되어있습니다");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("유효하지 않은 입력입니다.");
                }
            }

            int score = CheckScoreDice(selectedCategory - 1, player.Dices);
            scoreBoard.MarkCategoryUsed(selectedCategory - 1, score);
            Console.WriteLine($"{categories[selectedCategory - 1]}에 {score} 점수를 기록했습니다.");

            currentRound++;
            Thread.Sleep(500);
        }
        public void DisplayDice(int[] dices, bool[] isDiceRoll, int highlightIndex = -1)
        {
            Console.SetCursorPosition(0, 3);
            for (int i = 0; i < dices.Length; i++)
            {
                if (i == highlightIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.ForegroundColor = isDiceRoll[i] ? ConsoleColor.White : ConsoleColor.Red;
                Console.Write(dices[i] + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        private int CheckScoreDice(int categoryIndex, int[] dices)
        {
            int[] counts = new int[6];
            foreach (int dice in dices)
            {
                counts[dice - 1]++;
            }

            switch (categoryIndex)
            {
                case 0: // Aces
                    return dices.Where(d => d == 1).Sum();
                case 1: // Deuces
                    return dices.Where(d => d == 2).Sum();
                case 2: // Threes
                    return dices.Where(d => d == 3).Sum();
                case 3: // Fours
                    return dices.Where(d => d == 4).Sum();
                case 4: // Fives
                    return dices.Where(d => d == 5).Sum();
                case 5: // Sixes
                    return dices.Where(d => d == 6).Sum();
                case 6: // Choice
                    return dices.Sum();
                case 7: // Four of a Kind
                    return counts.Any(c => c >= 4) ? dices.Sum() : 0;
                case 8: // Full House
                    return counts.Contains(3) && counts.Contains(2) ? dices.Sum() : 0;
                case 9: // Small Straight
                    return CalculateSStraight(dices);
                case 10: // Large Straight
                    return CalculateLStraight(dices);
                case 11: // Yacht
                    return counts.Any(c => c == 5) ? 50 : 0;
                default:
                    return 0;
            }
        }
        private int CalculateSStraight(int[] dices)
        {
            int[] dicesClones = (int[])dices.Clone();
            Array.Sort(dicesClones);

            int countSmallStraight = 1;
            for (int i = 1; i < dicesClones.Length; i++)
            {
                if (dicesClones[i] == dicesClones[i - 1] + 1)
                {
                    countSmallStraight++;
                    if (countSmallStraight >= 4)
                    {
                        return 15;
                    }
                }
                else if (dicesClones[i] != dicesClones[i - 1])
                {
                    countSmallStraight = 1;
                }
            }
            return 0;
        }
        private int CalculateLStraight(int[] dices)
        {
            int[] dicesClones = (int[])dices.Clone();
            Array.Sort(dicesClones);

            int countLargeStraight = 1;
            for (int i = 1; i < dicesClones.Length; i++)
            {
                if (dicesClones[i] == dicesClones[i - 1] + 1)
                {
                    countLargeStraight++;
                    if (countLargeStraight == 5)
                    {
                        return 30;
                    }
                }
                else if (dicesClones[i] != dicesClones[i - 1])
                {
                    countLargeStraight = 1;
                }
            }
            return 0;
        }

    }
}
