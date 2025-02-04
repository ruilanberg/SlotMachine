using Game.ScreenManager;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI
{
    public class JackpotView : ScreenBase
    {
        private Label _currentJackpotLabel;

        private JackpotViewModel _viewModel;

        [Inject]
        public void Constructor(JackpotViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Initialize()
        {
            _currentJackpotLabel = _root.Q<Label>("CurrentJackpotLabel");

            _viewModel.SubscribeCreditUpdate(_currentJackpotLabel);
        }
    }
}