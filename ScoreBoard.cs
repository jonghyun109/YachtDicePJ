using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtDice
{
    enum SetScoreBoard
    {
        Ones,
        Twos,
        Threes,
        Fours,
        Fives,
        Sixes,
        Choice,
        FourOfaKind,
        FullHouse,
        SStraight,
        LStraight,
        Yacht
    }
    class ScoreBoard
    {
        public void InGameDisplayBoard()
        {
            string[] score = Enum.GetNames(typeof(SetScoreBoard));
            int leftCursor = 70;
            int topCursor = 0;

            foreach (string board in score)
            {
                Console.SetCursorPosition(leftCursor, topCursor);
                Console.WriteLine(board);
                topCursor++;
            }


        }
    }



}
