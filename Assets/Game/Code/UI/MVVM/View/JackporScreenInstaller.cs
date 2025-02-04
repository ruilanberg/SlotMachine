using Game.ScreenManager;
using UnityEngine;

namespace Game.UI
{
    public class JackporScreenInstaller : ScreenInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<JackpotViewModel>().AsTransient().NonLazy();
            Container.Bind<JackpotView>().FromInstance((JackpotView)View).AsSingle().NonLazy();
        }
    }
}