using Game.ScreenManager;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using R3;

namespace Game.UI
{
    public class CashInView : ScreenBase
    {
        #region Ref UI elements

        private Label _currentCreditLabel;

        private Button _oneMoreButton;
        private Button _twoMoreButton;
        private Button _fiveMoreButton;

        private Button _confirmButton;

        #endregion

        private CashViewModel _cashViewModel;

        [Inject]
        public void Constructor(CashViewModel cashViewModel)
        {
            _cashViewModel = cashViewModel;
        }

        public override void Initialize()
        {
            FindUIReferences();

            _cashViewModel.CurrentCash.Subscribe(credit => _currentCreditLabel.text = credit.ToString());
            SetButtonBehaviors();
        }

        private void FindUIReferences()
        {
            _currentCreditLabel = _root.Q<Label>("CurrentCreditLabel");

            _oneMoreButton = _root.Q<Button>("OneMoreButton");
            _twoMoreButton = _root.Q<Button>("TwoMoreButton");
            _fiveMoreButton = _root.Q<Button>("FiveMoreButton");

            _confirmButton = _root.Q<Button>("ConfirmButton");
        }
        private void SetButtonBehaviors()
        {
            _oneMoreButton.clicked += OneMoreOnButtonPressed;
            _twoMoreButton.clicked += TwoMoreOnButtonPressed;
            _fiveMoreButton.clicked += FiveMoreOnButtonPressed;

            _confirmButton.clicked += ConfirmOnButtonPressed;
        }

        private void ConfirmOnButtonPressed()
        {
            _cashViewModel.ConfirmCredits();
        }

        private void FiveMoreOnButtonPressed()
        {
            _cashViewModel.PlushCredit(5);
        }

        private void TwoMoreOnButtonPressed()
        {
            _cashViewModel.PlushCredit(2);
        }

        private void OneMoreOnButtonPressed()
        {
            _cashViewModel.PlushCredit(1);
        }
    }
}
