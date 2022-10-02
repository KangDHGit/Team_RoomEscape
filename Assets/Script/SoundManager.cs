using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager I;
        public AudioSource _as_PickUP;
        private void Awake()
        {
            I = this;
        }
        public void Init()
        {
            if (!transform.Find("Bgm_PickUP").TryGetComponent(out _as_PickUP))
                Debug.LogError("_as_PickUP is null");
        }
    }
}
