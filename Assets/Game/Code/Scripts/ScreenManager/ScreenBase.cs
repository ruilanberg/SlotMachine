using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.ScreenManager
{
    /// <summary>
    /// Base screen behaviour
    /// </summary>
    [RequireComponent(typeof(UIDocument))]
    public abstract class ScreenBase : MonoBehaviour
    {
        // UIDocument screen
        private UIDocument _uiDocument;
        // Root element
        protected VisualElement _root;

        // Screen manager
        private IScreenManager _screenManager;
        protected IScreenManager Manager => _screenManager;

        #region Injection Methods

        /// <summary>
        /// Get references in container
        /// </summary>
        /// <param name="screenManager"></param>
        [Inject]
        public void Construct(IScreenManager screenManager)
        {
            _screenManager = screenManager;
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;

            Hide();
        }

        #endregion

        /// <summary>
        /// Method call when initialize screen in scene
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Show screen
        /// </summary>
        public virtual void Show()
        {
            _root.style.display = DisplayStyle.Flex;
        }

        /// <summary>
        /// Hide screen
        /// </summary>
        public virtual void Hide()
        {
            _root.style.display = DisplayStyle.None;
        }

    }
}
