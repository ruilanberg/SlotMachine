using System;
using System.Collections.Generic;
using Game.ScreenManager;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI
{
    public class AnalyticsView : ScreenBase
    {
        #region Ref UI elements

        private Button _closetButton;

        private Button _englishButton;
        private Button _spanishButton;
        private Button _portuguesButton;

        private ListView _reportList;

        #endregion


        private AnalyticsViewModel _viewModel;

        [Inject]
        public void Constructor(AnalyticsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public override void Initialize()
        {
            FindUIReferences();
            SetBehaviourUI();

            _viewModel.PopulateList(_reportList);
        }

        private void FindUIReferences()
        {
            _closetButton = _root.Q<Button>("CloseButton");

            _englishButton = _root.Q<Button>("EnglishButton");
            _spanishButton = _root.Q<Button>("SpanishButton");
            _portuguesButton = _root.Q<Button>("PortuguesButton");

            _reportList = _root.Q<ListView>("ReportList");
        }

        private void SetBehaviourUI()
        {
            _closetButton.clicked += CloseOnButtonPressed;

            _englishButton.clicked += EnglishOnButtonPressed;
            _spanishButton.clicked += SpanishOnButtonPressed;
            _portuguesButton.clicked += PortugueseOnButtonPressed;
        }

        private void CloseOnButtonPressed()
        {
            _viewModel.CloseScreen();
        }

        private void EnglishOnButtonPressed()
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }

        private void SpanishOnButtonPressed()
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];
        }

        private void PortugueseOnButtonPressed()
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        }
    }
}