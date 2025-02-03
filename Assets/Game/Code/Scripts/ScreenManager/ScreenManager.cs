using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.ScreenManager
{
    /// <summary>
    /// Manager instances of screens
    /// </summary>
    public class ScreenManager : MonoBehaviour, IScreenManager
    {
        // Collection of screens prefabs
        [SerializeField] private ScreenInstaller[] _screenPrefabs;
        // Collection of screen instances
        private List<ScreenBase> _screensRuntime = new();

        // Screen factory
        private ScreenFactory _screenFactory;

        #region Injection Methods

        /// <summary>
        /// Get references in container
        /// </summary>
        /// <param name="sceneSwitch">Scene switch behavior</param>
        /// <param name="displayManager">Manager mobile display</param>
        /// <param name="screenFactory">Screen factory</param>
        [Inject]
        public void Construct(ScreenFactory screenFactory)
        {
            _screenFactory = screenFactory;
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitScreen();
        }

        #endregion

        /// <summary>
        /// Show first screen
        /// </summary>
        private void InitScreen()
        {
        }

        /// <summary>
        /// Get or create instance of screen
        /// </summary>
        /// <typeparam name="T">Type of screen</typeparam>
        /// <returns>Instance of screen object</returns>
        public T GetOrCreate<T>() where T : ScreenBase
        {
            try
            {
                T screenInstance = null;
                foreach (var scrRtm in _screensRuntime)
                {
                    if (scrRtm is T)
                    {
                        screenInstance = scrRtm as T;
                        break;
                    }
                }

                if (screenInstance == null)
                {
                    var prefab = _screenPrefabs.Where(t => t.View is T).FirstOrDefault();
                    T instantiateScreen = (T)_screenFactory.Create(prefab);

                    instantiateScreen.transform.SetParent(transform);

                    _screensRuntime.Add(instantiateScreen);
                    instantiateScreen.Initialize();

                    screenInstance = instantiateScreen;
                }

                return screenInstance;
            }
            catch (ArgumentException)
            {
                Debug.LogError($"Screen <b>{typeof(T).Name}</b> does not exist!");
                return null;
            }
        }

        /// <summary>
        /// Get or create instance of screen
        /// </summary>
        /// <param name="desiredType">Type of screen</param>
        /// <returns>Instance of screen object</returns>
        public ScreenBase GetOrCreate(Type desiredType)
        {
            ScreenBase screenInstance = null;
            foreach (var scrRtm in _screensRuntime)
            {
                if (scrRtm.GetType().Equals(desiredType))
                {
                    screenInstance = scrRtm;
                    break;
                }
            }

            if (screenInstance == null)
            {
                var prefab = _screenPrefabs.Where(t => t.View.GetType().Equals(desiredType)).FirstOrDefault();
                ScreenBase instantiateScreen = _screenFactory.Create(prefab);

                instantiateScreen.transform.SetParent(transform);

                _screensRuntime.Add(instantiateScreen);
                instantiateScreen.Initialize();

                screenInstance = instantiateScreen;
            }

            return screenInstance;
        }

        /// <summary>
        /// Get or create instance of screen
        /// </summary>
        /// <typeparam name="T">Type of screen</typeparam>
        /// <returns>Instance of screen object</returns>
        public T Get<T>() where T : ScreenBase
        {
            try
            {
                T screenInstance = null;
                foreach (var scrRtm in _screensRuntime)
                {
                    if (scrRtm is T)
                    {
                        screenInstance = scrRtm as T;
                        break;
                    }
                }

                return screenInstance;
            }
            catch (ArgumentException)
            {
                Debug.LogError($"Screen <b>{typeof(T).Name}</b> does not exist!");
                return null;
            }
        }

        /// <summary>
        /// Close and destroy instance of screen
        /// </summary>
        /// <typeparam name="T">Type of screen</typeparam>
        public void Close<T>() where T : ScreenBase
        {
            T screenInstance = null;
            foreach (var scrRtm in _screensRuntime)
            {
                if (scrRtm is T)
                {
                    screenInstance = scrRtm as T;
                    break;
                }
            }

            _screensRuntime.RemoveAll(t => t == null || t is T);

            if (screenInstance != null) Destroy(screenInstance.gameObject);
        }
    }
}
