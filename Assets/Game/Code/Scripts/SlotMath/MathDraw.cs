using System.Collections.Generic;
using UnityEngine;

namespace Game.SlotMath
{
    public class MathDraw
    {
        private int _totalPlays = 0;
        private int _jackpot = 300;
        private const int NUM_SYMBOLS = 10;
        private const int NUM_REELS = 3;
        private const int SYMBOLS_PER_REEL = 3;
        private const int CHANCE_JACKPOT = 200;

        public (bool, long,List<int>[]) SimuteSpin()
        {
            _totalPlays++;

            List<int>[] drawnNumbers = GenerateNumbersGrid();

            bool isWinJackpot = CheckJackpot();
            if (isWinJackpot)
            {
                Debug.Log($"Jackpot activated! You won {_jackpot}!");
                foreach (var row in drawnNumbers)
                    row[1] = 10;

                _jackpot = 300;
            }
            else
            {
                Debug.Log($"Jackpot not activated. Current jackpot value: {_jackpot}");
            }

            return drawnNumbers;
        }

        private List<int>[] GenerateNumbersGrid()
        {
            List<int>[] reels = new List<int>[NUM_REELS];
            for (int i = 0; i < NUM_REELS; i++)
            {
                reels[i] = new List<int>();
                for (int j = 0; j < SYMBOLS_PER_REEL; j++)
                {
                    int randomSymbol = Random.Range(1, NUM_SYMBOLS + 1);
                    reels[i].Add(randomSymbol);
                }
            }

            return reels;
        }

        /// <summary>
        /// Generates a random number from 1 to 200 to verify is jackpot
        /// </summary>
        /// <returns>Is jackpot</returns>
        private bool CheckJackpot()
        {
            return (Random.Range(1, CHANCE_JACKPOT + 1) == 1);
        }
    }
}
