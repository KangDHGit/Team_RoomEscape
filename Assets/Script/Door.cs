using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Door : MonoBehaviour
    {
        // 문이 연결된 방들
        public Room _roomA;
        public Room _roomB;
        // 열림여부
        public bool _isOpen;

        private void OnMouseDown()
        {
            if(_isOpen)
            {
                if(CameraManager.CamMgr._room_Now == _roomA)
                {
                    CameraManager.CamMgr.SetMCam(_roomB);
                }
                else if(CameraManager.CamMgr._room_Now == _roomB)
                {
                    CameraManager.CamMgr.SetMCam(_roomA);
                }
                Debug.Log("문은 열렸지만 이동오류");
            }
            else
                Debug.Log("문 잠김");
        }
    }
}
