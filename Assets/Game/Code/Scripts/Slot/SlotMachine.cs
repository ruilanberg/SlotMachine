using Cysharp.Threading.Tasks;
using Game.Analytics;
using Game.Lock;
using Game.SlotMath;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using Zenject;

namespace Game.Slot
{
    public class SlotMachine : MonoBehaviour
    {
        [SerializeField] private SymbolStorageData _symbolStorageData;
        [SerializeField] private RowSlot[] _rows;

        [Inject] private LockSystem _lockSystem;
        [Inject] private IAnalytics _analytics;
        [Inject] private ICreditRepository _creditRepository;

        private const int DELAY_SHOW_RESULT = 5000;
        private const int INIT_SYMBOLS = 5;

        private void Start()
        {
            GenerateInitRandomRows();
        }

        public async void StartSpin()
        {
            for (int i = 0; i < _rows.Length; i++)
                _rows[i].StartFakeRoll();

            await UniTask.Delay(DELAY_SHOW_RESULT);

            MathDraw math = new MathDraw();
            var (isWinJackpot, jackpotPrize, prize, drawnNumbers) = math.SimuteSpin();
            for (int i = 0; i < drawnNumbers.Length; i++)
            {
                List<SymbolData> symbols = new List<SymbolData>();
                for (int x = 0; x < drawnNumbers[i].Count; x++)
                {
                    symbols.Add(_symbolStorageData.FindByID(drawnNumbers[i][x]));
                }
                SymbolData offsetRandomSymbol = _symbolStorageData.FindByID(Random.Range(1, 10 + 1));
                symbols.Add(offsetRandomSymbol);

                _rows[i].ShowResult(symbols.ToArray());

                _lockSystem.UnlockAll();
            }

            _analytics.EndSpin(_creditRepository.LoadCurrentData());
        }

        private void GenerateInitRandomRows()
        {
            for (int i = 0; i < _rows.Length; i++)
            {
                List<SymbolData> symbols = new List<SymbolData>();
                for (int x = 0; x < INIT_SYMBOLS; x++)
                {
                    int id = Random.Range(1, 11);
                    symbols.Add(_symbolStorageData.FindByID(id));
                }

                _rows[i].CreateFirstRow(symbols.ToArray());
            }
        }
    }
}
