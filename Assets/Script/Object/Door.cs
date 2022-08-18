using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Door : MonoBehaviour
    {
        // 문이 연결되있는 방
        public Room _roomOut;
        // 열려있는지 여부
        public bool _isOpen;

        private void OnMouseDown()
        {
            if(_isOpen && !CameraManager.CamMgr._isZoom)
            {
                CameraManager.CamMgr.SetMCam(_roomOut);
            }
            else
                Debug.Log("Door is Close or Zoom Activate");
        }
    }
}
