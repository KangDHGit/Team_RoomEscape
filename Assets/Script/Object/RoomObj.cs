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

                _list_ChildRoomObj = new List<RoomObj>(GetComponentsInDirectChild<RoomObj>());
                ListSetCol(_list_ChildRoomObj, false);

                _list_Item = new List<RoomItem>(GetComponentsInChildren<RoomItem>());
                ListSetCol(_list_Item, false);
            }
        }

        protected virtual void OnMouseDown()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom)
            {
                if (_objZCam != null)
                {
                    _objZCam.SetActive(true);
                    GetComponent<Collider>().enabled = false;
                    CameraManager.I._isZoom = true;
                    ListSetCol(_list_ChildRoomObj, true);
                    ListSetCol(_list_Item, true);
                }
            }
        }

        public void OnClick_BackBtn()
        {
            if (_objZCam != null)
            {
                if (_objZCam.gameObject.activeSelf)
                {
                    if (!(_list_ChildRoomObj.Count > 0))
                    {
                        _objZCam.SetActive(false);
                        GetComponent<Collider>().enabled = true;
                        ListSetCol(_list_ChildRoomObj, false);
                        ListSetCol(_list_Item, false);
                    }
                }
            }
        }

        public T[] GetComponentsInDirectChild<T>() where T : MonoBehaviour
        {
            List<T> list = new List<T>();
            if (this.transform.childCount > 0)
            {
                foreach (Transform child in this.transform)
                {
                    if (child.TryGetComponent<T>(out T component))
                        list.Add(component);
                }
            }
            T[] array = list.ToArray();
            return array;
        }

        public void ListSetCol<T>(List<T> list, bool stat) where T : MonoBehaviour
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.TryGetComponent<Collider>(out Collider col))
                        col.enabled = stat;
                }
            }
        }
    }
}
