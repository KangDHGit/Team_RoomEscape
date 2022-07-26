using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class RoomObjManager : MonoBehaviour
    {
        public static RoomObjManager I;
        public List<RoomObj> _listSpring;
        public List<RoomObj> _listSummer;
        public List<RoomObj> _listFall;
        public List<RoomObj> _listWinter;

        void Awake()
        {
            I = this;
            //_listSummer = new List<RoomObj>(transform.Find("Room_Summer").GetComponentsInDirectChild<RoomObj>());
            //_listFall = new List<RoomObj>(transform.Find("Room_Fall").GetComponentsInChildren<RoomObj>());
            //_listWinter = new List<RoomObj>(transform.Find("Room_Winter").GetComponentsInChildren<RoomObj>());
        }

        public void Init()
        {
            Transform room = transform.Find("Room_Spring");
            for (int i = 0; i < room.childCount; i++)
            {
                _listSpring.AddRange(room.GetChild(i).GetComponentsInDirectChild<RoomObj>());
            }

            InitList(_listSpring);
        }

        void InitList<T>(ICollection<T> list) where T : RoomObj 
        {
            foreach (var roomObj in list)
            {
                roomObj.Init();
            }
        }

        public void OnClick_BackBtn()  // 뒤로가기 버튼을 눌렀을때 자신이 있는방의 RoomObj들만 함수 실행
        {
            switch (CameraManager.I._room_Now)
            {
                case Room.None:
                    break;
                case Room.SPRING:
                    OnClick_BackBtn_List(_listSpring);
                    break;
                case Room.SUMMER:
                    OnClick_BackBtn_List(_listSummer);
                    break;
                case Room.FALL:
                    break;
                case Room.WINTER:
                    break;
                default:
                    break;
            }
        }
        void OnClick_BackBtn_List(List<RoomObj> list)   //리스트 안의 RoomObj별 OnClick_BackBtn함수 실행
        {
            bool isParentActive = false;
            foreach (RoomObj roomObj in list)
            {
                 if (roomObj.OnClick_BackBtn())
                     isParentActive = true;
            }
            UIManager.I.OnChangeView(!isParentActive);
        }

    }
}
