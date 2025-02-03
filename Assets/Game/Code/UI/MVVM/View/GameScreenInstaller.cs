using Game.ScreenManager;
using UnityEngine;

namespace Game.UI
{
    public class GameScreenInstaller : ScreenInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameViewModel>().AsTransient().NonLazy();
            Container.Bind<GameView>().FromInstance((GameView)View).AsSingle().NonLazy();
        }
    }
}
