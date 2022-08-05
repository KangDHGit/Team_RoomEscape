using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager CamMgr;
        private GameObject _objMCam_Now; // 현재 내가 있는방의 메인카메라
        private GameObject _objZCam_Now; // 현재 내가 있는방의 활성화된 줌카메라
        public List<Camera> _MCamList;

        private void Awake()
        {
            CamMgr = this;
            _MCamList = new List<Camera>(GetComponentsInChildren<Camera>());
        }

        public void SetMCam(GameObject objMCam)
        {
            _objMCam_Now = objMCam;
        }

        public void SetZCam(GameObject objZCam)
        {
            _objZCam_Now = objZCam;
        }

        public void ChangeView(bool isMainView) // true : 메인카메라 켜짐, false : 줌카메라 켜짐
        {
            if(_objZCam_Now != null)
                _objZCam_Now.SetActive(!isMainView);
        }
    }
}
