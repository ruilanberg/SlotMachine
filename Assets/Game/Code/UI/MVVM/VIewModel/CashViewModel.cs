using UnityEngine;
using R3;
using Zenject;
using Game.ScreenManager;
using Game.Credits;
using Game.Lock;
using Game.Analytics;

namespace Game.UI
{
    public class CashViewModel
    {
        [Inject] private IScreenManager _screenManager;
        [Inject] private LockSystem _lockSystem;
        [Inject] private IAnalytics _analytics;

        private readonly ICreditRepository _creditRepository;

        public ReactiveProperty<long> CurrentCash { get; private set; }

        [Inject]
        public CashViewModel(ICreditRepository creditRepository) 
        {
            _creditRepository = creditRepository;

            CurrentCash = new ReactiveProperty<long>(0);
        }

        public void PlushCredit(long valuePlus)
        {
            CurrentCash.Value += valuePlus;
        }

        public void ConfirmCredits()
        {
            long value = _creditRepository.LoadCurrentData() + CurrentCash.Value;
            _creditRepository.UpdateCurrentData(value);

            _analytics.CashIn(value);
            _lockSystem.UnlockAll();

            _screenManager.Close<CashInView>();
        }
    }
}
