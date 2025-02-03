using Game.Credits;
using Game.ScreenManager;
using Game.Slot;
using Game.UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        [Inject] private IScreenManager _screenManager;

        public override void InstallBindings()
        {
            _screenManager.GetOrCreate<GameView>().Show();
        }
    }
}
