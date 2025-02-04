using Game.ScreenManager;
using UnityEngine;

namespace Game.UI
{
    public class AnalyticsScreenInstaller : ScreenInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AnalyticsViewModel>().AsTransient().NonLazy();
            Container.Bind<AnalyticsView>().FromInstance((AnalyticsView)View).AsSingle().NonLazy();
        }
    }
}
