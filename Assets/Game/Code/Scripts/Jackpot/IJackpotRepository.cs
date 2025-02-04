using System;
using UnityEngine;

namespace Game.Jackpot
{
    public interface IJackpotRepository
    {
        public void Init();
        public long Spinned(bool isWinJackpot);
        public void OnBindingContextPropertyChanged(Action<long> onAct);
    }
}
