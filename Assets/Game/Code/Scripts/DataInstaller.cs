using Game.Credits;
using Game.Jackpot;
using UnityEngine;
using Zenject;

namespace Game
{
    [CreateAssetMenu(fileName = "DataInstaller", menuName = "Scriptable Objects/DataInstaller")]
    public class DataInstaller : ScriptableObjectInstaller<DataInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICreditRepository>().To<CreditData>().AsSingle().NonLazy();
            Container.Bind<IJackpotRepository>().To<JackpotRuntimeRepository>().AsSingle().NonLazy();
        }
    }
}
