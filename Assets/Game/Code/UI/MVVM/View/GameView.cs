using Game.ScreenManager;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI
{
    public class GameView : ScreenBase
    {
        #region Ref UI elements

        private Button _cashOutButton;
        private Button _cashInButton;
        private Button _helpButton;

        private Label _currentCreditLabel;
        private Label _winCreditLabel;

        private Button _lessBetButton;
        private Button _plusBetButton;
        private Button _maxBetButton;
        private Label _currentBetLabel;

        private Button _autoSpinButton;
        private Button _spinButton;

        #endregion

        [SerializeField] private InputAction _clickAdmin;
        private GameViewModel _gameViewModel;

        [Inject]
        public void Constructor(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }

        public override void Initialize()
        {
            FindUIReferences();
            SetButtonBehaviors();

            _gameViewModel.SubscribeCreditUpdate(_currentCreditLabel);
            _gameViewModel.SubscribeWinUpdate(_winCreditLabel);

            _gameViewModel.SubscribeButtonOnLock(_cashOutButton);
            _gameViewModel.SubscribeButtonOnLock(_helpButton);
            _gameViewModel.SubscribeButtonOnLock(_lessBetButton);
            _gameViewModel.SubscribeButtonOnLock(_plusBetButton);
            _gameViewModel.SubscribeButtonOnLock(_maxBetButton);
            _gameViewModel.SubscribeButtonOnLock(_autoSpinButton);
            _gameViewModel.SubscribeButtonOnLock(_spinButton);

            _clickAdmin.performed += AdminScreen;

            _clickAdmin.Enable();
        }

        private void AdminScreen(InputAction.CallbackContext context)
        {
            _gameViewModel.ShowAdmin();
        }

        private void FindUIReferences()
        {
            _cashOutButton = _root.Q<Button>("CashOutButton");
            _cashInButton = _root.Q<Button>("CashInButton");
            _helpButton = _root.Q<Button>("HelpButton");

            _currentCreditLabel = _root.Q<Label>("CurrentCreditLabel");
            _winCreditLabel = _root.Q<Label>("WinCreditLabel");

            _lessBetButton = _root.Q<Button>("LessBetButton");
            _plusBetButton = _root.Q<Button>("PlusBetButton");
            _maxBetButton = _root.Q<Button>("MaxBetButton");
            _currentBetLabel = _root.Q<Label>("CurrentBetLabel");

            _autoSpinButton = _root.Q<Button>("AutoSpinButton");
            _spinButton = _root.Q<Button>("SpinButton");
        }

        private void SetButtonBehaviors()
        {
            _cashOutButton.clicked += CashOutOnButtonPressed;
            _cashInButton.clicked += CashInOnButtonPressed;
            _helpButton.clicked += HelpOnButtonPressed;

            _lessBetButton.clicked += LessBetOnButtonPressed;
            _plusBetButton.clicked += PlusBetOnButtonPressed;
            _maxBetButton.clicked += MaxBetOnButtonPressed;

            _autoSpinButton.clicked += AutoSpinOnButtonPressed;
            _spinButton.clicked += SpinOnButtonPressed;
        }

        private void SpinOnButtonPressed()
        {
            Debug.Log("Spin Pressed");
            _gameViewModel.StartSpin();
        }

        private void AutoSpinOnButtonPressed()
        {
            Debug.Log("AutoSpin Pressed");
        }

        private void MaxBetOnButtonPressed()
        {
            Debug.Log("Max Bet Pressed");
        }

        private void PlusBetOnButtonPressed()
        {
            Debug.Log("Plus Bet Pressed");
        }

        private void LessBetOnButtonPressed()
        {
            Debug.Log("Less Bet Pressed");
        }

        private void HelpOnButtonPressed()
        {
            Debug.Log("Help Pressed");
        }

        private void CashInOnButtonPressed()
        {
            Debug.Log("CashIn Pressed");

            _gameViewModel.ShowCashIn();
        }

        private void CashOutOnButtonPressed()
        {
            Debug.Log("CashOut Pressed");

            _gameViewModel.Cashout();
        }
    }
}
