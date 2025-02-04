using R3;
using System;
using UnityEngine;

namespace Game.Credits
{
    public interface ICreditRepository
    {
        public void Init();
        public void UpdateCurrentData(long credits);
        public void UpdateWinData(long winCredit);
        public long LoadCurrentData();

        public void OnBindingContextPropertyChanged(Action<long> onAct);

        public void OnBindingWinContextPropertyChanged(Action<long> onAct);
    }
}