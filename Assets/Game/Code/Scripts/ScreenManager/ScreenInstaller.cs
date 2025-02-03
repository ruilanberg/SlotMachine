using UnityEngine;
using Zenject;

namespace Game.ScreenManager
{
    public class ScreenInstaller : MonoInstaller
    {
        [SerializeField] private ScreenBase _view;
        public ScreenBase View => _view;
    }
}