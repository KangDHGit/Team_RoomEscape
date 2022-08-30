using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Door : MonoBehaviour
    {
        // 문이 연결되있는 방
        public Room _roomOut;

        public string _requireItemName;

        // 조건만족 여부
        bool _satisfaction = false;

        private void OnMouseDown()
        {
            if(_satisfaction && !CameraManager.I._isZoom)
            {
                CameraManager.I.SetMCam(_roomOut);
            }
            else
                Debug.Log("Door is Close or Zoom Activate");
        }

        public bool CheckItem(string itemName)
        {
            if(_requireItemName == itemName)
            {
                _satisfaction = true;
                transform.Rotate(new Vector3(0, -45, 0));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
