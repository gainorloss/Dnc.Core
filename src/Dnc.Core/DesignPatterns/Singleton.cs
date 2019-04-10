using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.DesignPatterns
{
    /// <summary>
    /// Create instance.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Singleton<T>
        where T : class, new()
    {
        #region Public member.
        public static T Instance = null;
        #endregion

        #region private member.
        private static object mLock = new object();
        #endregion

        #region Method for creating singleton.
        public static T CreateSingleton()
        {
            if (Instance == null)
            {
                lock (mLock)
                {
                    if (Instance == null)
                    {
                        Instance = new T();
                    }
                }
            }
            return Instance;
        } 
        #endregion
    }
}
