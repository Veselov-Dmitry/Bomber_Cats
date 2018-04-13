using UnityEngine;
using System.Collections;

public class SingletonGameObject<T> : MonoBehaviour where T : SingletonGameObject<T>
{
    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                var holder = new GameObject("Singleton_" + typeof(T).ToString());
                DontDestroyOnLoad(holder);
                s_instance = holder.AddComponent<T>();
            }
            return s_instance;
        }
    }

    private static T s_instance = null;
}