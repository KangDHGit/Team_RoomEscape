using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    enum Room
    {
        CENTER,
        ROOM1,
        ROOM2,
        ROOM3,
        ROOM4,
    }
    public class RoomObj : MonoBehaviour
    {
        
        Room _room = Room.CENTER; // 이 오브젝트가 속한 방
        GameObject _objMCam; // 방 메인(Main) 카메라
        GameObject _objZCam; // 오브젝트 클릭시 활성화할 줌(Zoom) 카메라


        void Start()
        {
            _objMCam = CameraManager.CamMgr.transform.Find($"{_room}/Cam_{_room}").gameObject;
            _objZCam = CameraManager.CamMgr.transform.Find($"{_room}/Cam_{gameObject.name}").gameObject;
            if (_objZCam != null)
                _objZCam.SetActive(false);
        }

        private void OnMouseDown()
        {
            CameraManager.CamMgr.SetMCam(_objMCam);
            CameraManager.CamMgr.SetZCam(_objZCam);
            CameraManager.CamMgr.ChangeView(false);
        }
    }
}
