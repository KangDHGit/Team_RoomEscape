using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager CamMgr; // 싱글턴

        private Room _room_Now; // 내가있는방
        private GameObject _objZCam_Now; // 현재 내가있는방의 활성화된 줌카메라
        private GameObject _objMCam_Now; // 현재 내가있는방의 메인카메라
        public List<GameObject> _objMCam_List;

        private void Awake()
        {
            CamMgr = this;
            _room_Now = Room.SPRING;
            _objMCam_List = new List<GameObject>(GameObject.FindGameObjectsWithTag("MainCamera"));
            _objMCam_List[(int)_room_Now].SetActive(true);
        }
    }
}
