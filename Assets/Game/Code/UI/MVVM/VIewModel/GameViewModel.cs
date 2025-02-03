using Game.Analytics;
using Game.Lock;
using Game.ScreenManager;
using Game.Slot;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI
{
    public class GameViewModel
    {
        [Inject] private IScreenManager _screenManager;
        [Inject] private SlotMachine _slotMachine;
        [Inject] private LockSystem _lockSystem;
        [Inject] private IAnalytics _analytics;

        private readonly ICreditRepository _creditRepository;

        private const int COST_SPIN_CREDIT = 1;

        [Inject]
        public GameViewModel(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
        }

        public void SubscribeCreditUpdate(Label currentCreditLabel)
        {
            currentCreditLabel.text = _creditRepository.LoadCurrentData().ToString();

            _creditRepository.OnBindingContextPropertyChanged(credit => currentCreditLabel.text = credit.ToString());
        }

        public void SubscribeButtonOnLock(Button button)
        {
            _lockSystem.OnBindingContextPropertyChanged(isLock => button.SetEnabled(!isLock));
        }

        public void ShowCashIn()
        {
            _lockSystem.LockAll();
            _screenManager.GetOrCreate<CashInView>().Show();
        }

        public void StartSpin()
        {
            if (_creditRepository.LoadCurrentData() <= 0)
                return;

            _lockSystem.LockAll();

            long value = _creditRepository.LoadCurrentData() - COST_SPIN_CREDIT;

            _analytics.StartSpin(value);

            _creditRepository.UpdateCurrentData(value);

            _slotMachine.StartSpin();
        }

        public void Cashout()
        {
            _analytics.CashOut(_creditRepository.LoadCurrentData());
            _creditRepository.UpdateCurrentData(0);
        }
    }
}
