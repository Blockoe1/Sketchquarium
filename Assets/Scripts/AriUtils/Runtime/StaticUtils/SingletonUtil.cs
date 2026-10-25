using UnityEngine;

namespace AriUtils
{
    public static class SingletonUtil
    {
        /// <summary>
        /// Assigns a MonoBehaviour instance to a singleton static variable with built in duplication checking and errors.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instanceVar">The static instance variable where the singleton will be stored.</param>
        /// <param name="obj">The object to set as the singleton.</param>
        /// <returns>True if the singleton was sucessfully set.</returns>
        public static bool SetSingleton<T>(ref T instanceVar, T obj) where T : MonoBehaviour
        {
            if (instanceVar != null && instanceVar != obj)
            {
                Debug.LogError($"Duplicate {obj.GetType().Name} found.  Deleting.");
                GameObject.Destroy(obj.gameObject);
                return false;
            }
            else
            {
                instanceVar = obj;
                return true;
            }
        }
    }
}
