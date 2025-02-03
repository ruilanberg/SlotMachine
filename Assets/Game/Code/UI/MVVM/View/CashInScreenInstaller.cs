using Game.ScreenManager;
using UnityEngine;

namespace Game.UI
{
    public class CashInScreenInstaller : ScreenInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CashViewModel>().AsTransient().NonLazy();
            Container.Bind<CashInView>().FromInstance((CashInView)View).AsSingle().NonLazy();
        }
    }
}
