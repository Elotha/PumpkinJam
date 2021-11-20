using UnityEngine;

namespace Core
{
    [DisallowMultipleComponent]
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T i;
        public static T I
        {
            get
            {
                if (i == null) i = (T) FindObjectOfType(typeof(T));
                return i;
            }
        }
    }
}