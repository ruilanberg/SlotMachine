using Game.Jackpot;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI
{
    public class JackpotViewModel
    {
        private readonly IJackpotRepository _jackpotRepository;

        private const int COST_SPIN_CREDIT = 1;

        [Inject]
        public JackpotViewModel(IJackpotRepository jackpotRepository)
        {
            _jackpotRepository = jackpotRepository;
        }

        public void SubscribeCreditUpdate(Label currentJackpotLabel)
        {
            _jackpotRepository.OnBindingContextPropertyChanged(credit => currentJackpotLabel.text = credit.ToString());
        }
    }
}