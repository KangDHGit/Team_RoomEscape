using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public enum Room
    {
        None = -1,
        SPRING,
        SUMMER,
        FALL,
        WINTER
    }
    public class RoomObj : MonoBehaviour
    {
        
        [SerializeField] Room _room; // 이 오브젝트가 속한 방
        [SerializeField] GameObject _objZCam; // 오브젝트 클릭시 활성화할 줌(Zoom) 카메라
        public List<RoomObj> _list_ChildRoomObj; // 오브젝트의 자식 오브젝트
        public List<RoomItem> _list_Item;    // 오브젝트의 자식 아이템

        void Start()
        {
            if (_room != Room.None)
            {
                _objZCam = CameraManager.I.transform.Find($"{_room}/Cam_{gameObject.name}").gameObject;
                if (_objZCam != null)
                    _objZCam.SetActive(false);

                _list_ChildRoomObj = new List<RoomObj>(GetComponentsInDirectChildren<RoomObj>());

                _list_Item = new List<RoomItem>(GetComponentsInChildren<RoomItem>());
                ItemListSetCol(false);
            }
        }

        private void OnMouseDown()
        {
            if(UIManager.I.CheckClickUI())
            {
                Debug.Log("UI Crash");
                return;
            }

            if (_objZCam != null)
            {
                _objZCam.SetActive(true);
                GetComponent<Collider>().enabled = false;
                CameraManager.I._isZoom = true;
                ItemListSetCol(true);
            }

            foreach (Transform child in transform)
            {
                Debug.Log(child.name);
            }
        }

        public void OnClick_BackBtn()
        {
            if (_objZCam != null)
            {
                _objZCam.SetActive(false);
                GetComponent<Collider>().enabled = true;
                ItemListSetCol(false);
            }
        }

        public void ItemListSetCol(bool stat)
        {
            if (_list_Item != null)
            {
                foreach (var item in _list_Item)
                {
                    item.SetCol(stat);
                }
            }
        }
        public T[] GetComponentsInDirectChildren<T>()
        {
            List<T> list = new List<T>();
            foreach (Transform child in this.transform)
            {
                list.Add(child.GetComponent<T>());
            }
            T[] array = list.ToArray();
            return array;
        }

        //public T[] FindAll_DirectChild<T>()
        //{
        //    List<T> list = new List<T>();
        //    foreach (Transform child in this.transform)
        //    {
        //        list.Add(child.GetComponent<MonoBehaviour>());
        //    }
        //    T[] array = list.ToArray();
        //    return array;
        //}
    }
}
