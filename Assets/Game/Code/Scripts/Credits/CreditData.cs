using R3;
using System;
using UnityEngine;

namespace Game.Credits
{
    public class CreditData : ICreditRepository
    {
        public ReactiveProperty<long> CurrentCredit {  get; private set; }
        public ReactiveProperty<long> WinCredit {  get; private set; }

        public CreditData() 
        {
            Init();
        }

        public void Init()
        {
            CurrentCredit = new ReactiveProperty<long>(0);
            WinCredit = new ReactiveProperty<long>(0);
        }

        public void UpdateCurrentData(long credits)
        {
            CurrentCredit.Value = credits;
        }

        public void UpdateWinData(long winCredit) 
        {
            WinCredit.Value = winCredit;

            CurrentCredit.Value += WinCredit.Value;
        }

        public long LoadCurrentData()
        {
            return CurrentCredit.Value;
        }

        public void OnBindingContextPropertyChanged(Action<long> onAct)
        {
            CurrentCredit.Subscribe(onAct);
        }

        public void OnBindingWinContextPropertyChanged(Action<long> onAct)
        {
            WinCredit.Subscribe(onAct);
        }
    }
}
