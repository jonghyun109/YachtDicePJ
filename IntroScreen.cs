using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtDice
{
    class IntroScreen
    {
        public void ShowIntroScreen()
        {
            InGameScreen inGameScreen = new InGameScreen();
            Description description = new Description();
            Console.Clear(); 
            Console.WriteLine("=====================================");
            Console.WriteLine("         요트 다이스 게임");
            Console.WriteLine("=====================================");
            Console.WriteLine("           1. 게임 시작"); 
            Console.WriteLine("           2. 게임 설명");
            Console.WriteLine("           3. 종료");
            Console.WriteLine("=====================================");
            Console.Write("선택: ");
            ConsoleKeyInfo inputKey = Console.ReadKey();
            switch (inputKey.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    inGameScreen.ShowInGameScreen();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    description.ShowDescription();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                    ShowIntroScreen();
                    break;
            }
        }
    }
    class InGameScreen
    {
        Dice dice = new Dice();
        public void ShowInGameScreen()
        {
            dice.JustDice();
        }
        
    }
    class Description
    {
        public void ShowDescription()
        {
            IntroScreen introScreen = new IntroScreen();
            Console.Clear ();
            Console.WriteLine("=====================================");
            Console.WriteLine("       요트 다이스 게임 설명:");
            Console.WriteLine("=====================================");
            Console.WriteLine("요트 다이스는 주사위를 사용하여 점수를 기록하는 게임입니다.");
            Console.WriteLine("각 플레이어는 주사위를 굴려 특정 조합을 만들어 점수를 얻습니다.");
            Console.WriteLine("게임은 총 12라운드로 진행 됩니다");
            Console.WriteLine("각 라운드마다 플레이어는 주사위를 최대 세 번까지 굴릴 수 있습니다.");
            Console.WriteLine("주사위는 SpaceBar를 눌러 굴리고 SpaceBar를 다시 쓰면 멈춥니다.");
            Console.WriteLine("\n아무 키나 눌러 인트로 화면으로 돌아가기..");
            Console.ReadKey();            
            introScreen.ShowIntroScreen();
        }
    }
    class EndScreen
    {
        IntroScreen introScreen = new IntroScreen();
        bool isWin = true;
        public void ShowEndScreen()
        {            
            if (isWin)
            {
                Console.WriteLine("축하합니다! 승리했습니다!");
            }
            else
            {
                Console.WriteLine("패배했습니다..");
            }
            Console.WriteLine("아무 키나 눌러 인트로 화면으로 돌아가기..");
            Console.ReadKey();
            introScreen.ShowIntroScreen();
        }

    }
    
}
