using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class SingletonInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var objs = FindObjectsOfType(typeof(T)) as T[];

                    if (objs.Length == 0)
                        objs = FindObjectsOfType(typeof(T), true) as T[];

                    if (objs.Length > 0)
                        _instance = objs[0];

                    if (objs.Length > 1)
                    {
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                    }
                }

                return _instance;
            }
        }
    }
}
