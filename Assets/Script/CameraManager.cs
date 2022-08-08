using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager CamMgr;
        private Room _room_Now; // 내가있는방
        private GameObject _objZCam_Now; // 현재 내가있는방의 활성화된 줌카메라
        public List<Camera> _MCamList;



        private void Awake()
        {
            CamMgr = this;
            _MCamList = new List<Camera>(GetComponentsInChildren<Camera>());
        }


        public void SetCam(RoomObj roomObj)
        {
            _objZCam_Now = roomObj._objZCam; // 줌카메라 셋팅
            if (_room_Now == roomObj._room) // 같은 방일경우 탈출
                return;
            else
            {
                _room_Now = roomObj._room; // 내가있는방 변경
            }
        }
        public void ChangeView(bool isMainView) // true : 메인카메라 켜짐, false : 줌카메라 켜짐
        {
            if (_objZCam_Now != null)
            {
                _objZCam_Now.SetActive(!isMainView);
            }
        }
    }
}
