using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager I;
        private void Awake()
        {
            I = this;
        }
    }
}
