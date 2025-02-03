using System;

namespace Game.ScreenManager
{
    /// <summary>
    /// Manager instances of screens
    /// </summary>
    public interface IScreenManager
    {
        /// <summary>
        /// Get or create instance of screen
        /// </summary>
        /// <typeparam name="T">Type of screen</typeparam>
        /// <returns>Instance of screen object</returns>
        T Get<T>() where T : ScreenBase;

        /// <summary>
        /// Get or create instance of screen
        /// </summary>
        /// <typeparam name="T">Type of screen</typeparam>
        /// <returns>Instance of screen object</returns>
        T GetOrCreate<T>() where T : ScreenBase;

        /// <summary>
        /// Get or create instance of screen
        /// </summary>
        /// <param name="desiredType">Type of screen</param>
        /// <returns>Instance of screen object</returns>
        ScreenBase GetOrCreate(Type desiredType);

        /// <summary>
        /// Close and destroy instance of screen
        /// </summary>
        /// <typeparam name="T">Type of screen</typeparam>
        void Close<T>() where T : ScreenBase;
    }
}
