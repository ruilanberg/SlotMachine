using UnityEngine;
using Zenject;


namespace Game.ScreenManager
{
    /// <summary>
    /// Injection factory of Screens
    /// </summary>
    public class ScreenFactory : PlaceholderFactory<UnityEngine.Object, ScreenBase> { }

    /// <summary>
    /// Factory of create prefab of Screen
    /// </summary>
    public class PrefabScreenFactory : IFactory<UnityEngine.Object, ScreenBase>
    {
        private readonly DiContainer _container;

        /// <summary>
        /// Constructor to set container
        /// </summary>
        /// <param name="container">Conateiner of injection</param>
        public PrefabScreenFactory(DiContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Instantiate prefab of Screen
        /// </summary>
        /// <param name="prefab">Prefab of screen</param>
        /// <returns>Instantiate object of prefab</returns>
        public ScreenBase Create(Object prefab)
        {
            var screenInstance = _container.InstantiatePrefabForComponent<ScreenBase>(prefab);

            return screenInstance;
        }
    }
}

