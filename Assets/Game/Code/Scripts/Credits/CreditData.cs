using R3;
using System;
using UnityEngine;

namespace Game.Credits
{
    public class CreditData : ICreditRepository
    {
        public ReactiveProperty<long> CurrentCredit {  get; private set; }

        public CreditData() 
        {
            Init();
        }

        public void Init()
        {
            CurrentCredit = new ReactiveProperty<long>(0);
        }

        public void UpdateCurrentData(long credits)
        {
            CurrentCredit.Value = credits;
        }


        public long LoadCurrentData()
        {
            return CurrentCredit.Value;
        }

        public void OnBindingContextPropertyChanged(Action<long> onAct)
        {
            CurrentCredit.Subscribe(onAct);
        }

    }
}
