using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager I; // 싱글턴


        public Room _room_Now; // 내가있는방
        public GameObject _objMCam_Now; // 내가있는방의 메인카메라
        public List<GameObject> _objMCam_List; // 모든 방의 메인카메라 리스트
        public bool _isZoom = false;
        public bool _isZoom_Child = false;

        public bool _isZoom_Middle = false;

        private void Awake()
        {
            I = this;
        }

        public void Init()
        {
            _objMCam_List = new List<GameObject>(GameObject.FindGameObjectsWithTag("MainCamera")); // 모든방의 메인카메라를 가져옴
            SetMCam(Room.SPRING); // 초기 방설정 : 봄
        }

        void AllMCamOff()   // 모든방의 메인카메라 끄기
        {
            if(_objMCam_List != null)
            {
                foreach (var camera in _objMCam_List)
                {
                    camera.SetActive(false);
                }
            }
        }
        public void SetMCam(Room room)
        {
            _room_Now = room;                           // 방 설정
            _objMCam_Now = _objMCam_List[(int)room];    // 메인카메라를 내가있는방의 메인카메라로 설정
            AllMCamOff();
            _objMCam_Now.SetActive(true);               // 메인카메라 켜기
        }

        #region 카메라 좌우측 회전
        public void ClickRightButton()  // 오른쪽 화살표 클릭
        {
            _objMCam_Now.transform.Rotate(new Vector3(0, 90, 0));
        }

        public void ClickLeftButton()   // 왼쪽 화살표 클릭
        {
            _objMCam_Now.transform.Rotate(new Vector3(0, -90, 0));
        }
        #endregion
    }
}
