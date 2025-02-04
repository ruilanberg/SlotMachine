using System;
using R3;
using UnityEngine;

namespace Game.Jackpot
{
    public class JackpotRuntimeRepository : IJackpotRepository
    {
        public ReactiveProperty<long> CurrentCredit {  get; private set; }
        private const long INIT_VALUE = 300;

        public JackpotRuntimeRepository() 
        {
            Init();
        }

        public void Init()
        {
            CurrentCredit = new ReactiveProperty<long>(INIT_VALUE);
        }

        public void OnBindingContextPropertyChanged(Action<long> onAct)
        {
            CurrentCredit.Subscribe(onAct);
        }

        public long Spinned(bool isWinJackpot)
        {
            if(isWinJackpot)
            {
                long valueWin = CurrentCredit.Value;
                CurrentCredit.Value = INIT_VALUE;

                return valueWin;
            }
            else
            {
                CurrentCredit.Value += (long)(CurrentCredit.Value * 0.01f);
                return 0;
            }
        }
    }
}