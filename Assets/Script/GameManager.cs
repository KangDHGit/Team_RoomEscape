using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I;
        private void Awake()
        {
            I = this;
        }

        private void Start()
        {
            RoomObjManager. I.Init();
            CameraManager.  I.Init();
            DialLock.       I.Init();
            UIManager.      I.Init();
            UI_Inventory.   I.Init();
        }
    }

    public static class Exclass
    {
        public static T[] GetComponentsInDirectChild<T>(this Transform trans) where T : MonoBehaviour
        {
            List<T> list = new List<T>();
            if (trans.childCount > 0)
            {
                foreach (Transform child in trans.transform)
                {
                    if (child.TryGetComponent<T>(out T component))
                        list.Add(component);
                }
            }
            T[] array = list.ToArray();
            return array;
        }
    }
}


