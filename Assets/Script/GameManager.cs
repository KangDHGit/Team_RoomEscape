using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            CameraManager.I.Init();                
        }
    }
}
