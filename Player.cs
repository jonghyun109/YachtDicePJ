using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtDice
{
    class Player
    {
        public int[] Dices { get; private set; } = new int[5];
        public bool[] IsDiceRoll { get; private set; } = new bool[5];

        public Player()
        {
            ResetDice();
        }

        public void ResetDice()
        {
            for (int i = 0; i < IsDiceRoll.Length; i++)
            {
                IsDiceRoll[i] = true;
            }
        }

        public int[] GetStoppedDice()
        {
            return Dices; // 현재 멈춘 주사위 값 반환
        }
    }

}
