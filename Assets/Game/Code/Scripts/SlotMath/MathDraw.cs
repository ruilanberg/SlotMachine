using System.Collections.Generic;
using UnityEngine;

namespace Game.SlotMath
{
    public class MathDraw
    {
        private const int NUM_SYMBOLS = 10;
        private const int NUM_REELS = 3;
        private const int SYMBOLS_PER_REEL = 3;
        private const int CHANCE_JACKPOT = 200;

        /// <summary>
        /// Random result of spin
        /// </summary>
        /// <returns>Is Win Jackpot, Prize, Draw Slots</returns>
        public (bool, long, List<int>[]) SimuteSpin()
        {
            List<int>[] drawnNumbers = GenerateNumbersGrid();

            long prize = 0;
            if(CheckCenterLineWinner(drawnNumbers))
                prize = PrizeCenterLineWinner(drawnNumbers);

            bool isWinJackpot = CheckJackpot();
            if (isWinJackpot)
            {
                Debug.Log($"Jackpot activated! You won!");
            }
            else
            {
                Debug.Log($"Jackpot not activated.");
            }

            return (isWinJackpot, prize, drawnNumbers);
        }

        /// <summary>
        /// Fake Random result of spin
        /// </summary>
        /// <returns>Is Win Jackpot, Jackpot Prize, Prize, Draw Slots</returns>
        public (bool, long, List<int>[]) SimuteSpin(bool isWinJackpot)
        {
            List<int>[] drawnNumbers = GenerateNumbersGrid();

            long prize = 0;


            if (isWinJackpot)
            {
                Debug.Log($"Jackpot activated! You won!");
            }
            else
            {
                Debug.Log($"Jackpot not activated");
            }

            return (isWinJackpot, prize, drawnNumbers);
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

        private bool CheckCenterLineWinner(List<int>[] reels) 
        {
            bool isWin = true;
            int idSlot = reels[0][1];

            for (int i = 0; i < reels.Length; i++)
            {
                if(idSlot == 10)
                    idSlot = reels[i][1];

                if(!(reels[i][1] == idSlot || reels[i][1] == 10))
                {
                    isWin = false;
                    break;
                }
            }

            return isWin;
        }

        private long PrizeCenterLineWinner(List<int>[] reels) 
        {
            int idSlot = reels[0][1];

            for (int i = 0; i < reels.Length; i++)
            {
                if(idSlot == 10)
                    idSlot = reels[i][1];
            }

            return idSlot;
        }
    }
}
