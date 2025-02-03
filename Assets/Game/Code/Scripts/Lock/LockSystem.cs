using R3;
using System;
using UnityEngine;

namespace Game.Lock
{
    public class LockSystem
    {
        private ReactiveProperty<bool> _isLock;

        public LockSystem()
        {
            Init();
        }

        private void Init()
        {
            _isLock = new ReactiveProperty<bool>(false);
        }

        public void LockAll()
        {
            _isLock.Value = true;
        }

        public void UnlockAll()
        {
            _isLock.Value = false;
        }

        public void OnBindingContextPropertyChanged(Action<bool> onAct)
        {
            _isLock.Subscribe(onAct);
        }
    }
}
