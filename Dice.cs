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
        private Random random = new Random();

        public int[] RollDice(bool[] isDiceRoll)
        {
            int[] dices = new int[5];
            for (int i = 0; i < dices.Length; i++)
            {
                if (isDiceRoll[i])
                {
                    dices[i] = random.Next(1, 7); // 1부터 6까지 랜덤 값 생성
                }
            }
            return dices;
        }
    }
}