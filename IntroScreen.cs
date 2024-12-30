using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace YachtDice
{
    class IntroScreen
    {
        public void ShowIntroScreen()
        {
            GameManager playGame = new GameManager();
            Console.CursorVisible = false;

            Console.Clear();


            Console.WindowHeight = 40;
            Console.WindowWidth = 100;

            int windowWidth = Console.WindowWidth;


            SetCursorCenter(" ##  ##                                                ####                              ", windowWidth);
            SetCursorCenter(" ##  ##                     ##         ##              ## ##      ##                     ", windowWidth);
            SetCursorCenter(" ##  ##    ####     ####    ##       ######            ##  ##             ####     ####  ", windowWidth);
            SetCursorCenter("  ####        ##   ##       #####      ##              ##  ##    ###     ##       ##  ## ", windowWidth);
            SetCursorCenter("   ##      #####   ##       ##  ##     ##              ##  ##     ##     ##       ###### ", windowWidth);
            SetCursorCenter("   ##     ##  ##   ##       ##  ##     ##              ## ##      ##     ##       ##     ", windowWidth);
            SetCursorCenter("   ##      #####    ####    ##  ##      ###            ####      ####     ####     ####  ", windowWidth);

            Console.WriteLine("\n\n\n\n\n\n\n");

            SetCursorCenter("==========================================================================================\n", windowWidth);
            SetCursorCenter(" 1. 게임 시작", windowWidth - 5);
            SetCursorCenter(" 2. 게임 설명", windowWidth - 5);
            SetCursorCenter(" 3. 종료\n", windowWidth - 5);
            SetCursorCenter("==========================================================================================", windowWidth);

            ConsoleKeyInfo inputKey = Console.ReadKey();
            switch (inputKey.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    playGame.StartGame();

                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    ShowDescription();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                    Thread.Sleep(300);
                    ShowIntroScreen();
                    break;
            }
        }
        public void ShowDescription()
        {
            int windowWidth = Console.WindowWidth;
            Console.Clear();
            SetCursorCenter("==========================================================================================\n", windowWidth);
            SetCursorCenter("       요트 다이스 게임 설명:\n", windowWidth - 15);
            SetCursorCenter("==========================================================================================\n", windowWidth);
            SetCursorCenter("요트 다이스는 주사위를 사용하여 점수를 기록하는 게임입니다.", windowWidth - 20);
            SetCursorCenter("각 플레이어는 주사위를 굴려 특정 조합을 만들어 점수를 얻습니다.", windowWidth - 18);
            SetCursorCenter("게임은 총 12라운드로 진행 됩니다 ", windowWidth - 34);
            SetCursorCenter("각 라운드마다 플레이어는 주사위를 최대 세 번까지 굴릴 수 있습니다.", windowWidth - 15);
            SetCursorCenter("각라운드의 종료는 점수판에 입력한 순간입니다. ", windowWidth - 27);
            SetCursorCenter("주사위가 3번이 구르거나 그전에 점수판에 입력을 하면 다음라운드로 넘어갑니다", windowWidth - 12);
            SetCursorCenter("12개의 점수판을 모두 채울시 점수판의 합이 게임결과로 나타납니다", windowWidth - 18);
            Console.WriteLine("\n\n");
            SetCursorCenter("아무 키나 눌러 인트로 화면으로 돌아가기..", windowWidth - 20);
            Console.ReadKey();
            ShowIntroScreen();
        }
        static void SetCursorCenter(string text, int windowWidth)
        {

            Console.SetCursorPosition((windowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}
