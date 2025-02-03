using R3;
using System;
using UnityEngine;

public interface ICreditRepository
{
    public void Init();
    public void UpdateCurrentData(long credits);
    public long LoadCurrentData();

    public void OnBindingContextPropertyChanged(Action<long> onAct);
}
