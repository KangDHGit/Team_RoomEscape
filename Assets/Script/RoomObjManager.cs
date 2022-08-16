using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class RoomObjManager : MonoBehaviour
    {
        public List<RoomObj> _listSpring;
        public List<RoomObj> _listSummer;
        public List<RoomObj> _listFall;
        public List<RoomObj> _listWinter;

        void Start()
        {
            _listSpring = new List<RoomObj>(transform.Find("Room_Spring").GetComponentsInChildren<RoomObj>());
            _listSummer = new List<RoomObj>(transform.Find("Room_Summer").GetComponentsInChildren<RoomObj>());
            //_listFall = new List<RoomObj>(transform.Find("Room_Fall").GetComponentsInChildren<RoomObj>());
            //_listWinter = new List<RoomObj>(transform.Find("Room_Winter").GetComponentsInChildren<RoomObj>());
           
        }
        void Update()
        {

        }

        void OnClick_BackBtn()  // 뒤로가기 버튼을 눌렀을때 자신이 있는방의 RoomObj들만 함수 실행
        {
            switch (CameraManager.CamMgr._room_Now)
            {
                case Room.None:
                    break;
                case Room.SPRING:
                    SwitchToMainView(_listSpring);
                    break;
                case Room.SUMMER:
                    SwitchToMainView(_listSummer);
                    break;
                case Room.FALL:
                    break;
                case Room.WINTER:
                    break;
                default:
                    break;
            }
        }
        void SwitchToMainView(List<RoomObj> list)   //리스트 안의 RoomObj별 OnClick_BackBtn함수 실행
        {
            foreach (var roomObj in list)
            {
                roomObj.OnClick_BackBtn();
            }
            CameraManager.CamMgr._isZoom = false;
        }
    }
}
