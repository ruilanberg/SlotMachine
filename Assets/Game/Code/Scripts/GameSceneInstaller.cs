using Game.Analytics;
using Game.Lock;
using Game.Slot;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private SlotMachine _slotMachine;

        public override void InstallBindings()
        {
            Container.Bind<IAnalytics>().To<AnalyticsRuntime>().AsSingle().NonLazy();
            Container.Bind<LockSystem>().AsSingle().NonLazy();

            Container.BindInstance(_slotMachine).AsSingle().NonLazy();
        }
    }
}
