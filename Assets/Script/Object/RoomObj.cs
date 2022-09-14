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
        
        [SerializeField] protected Room _room; // 이 오브젝트가 속한 방
        [SerializeField] public GameObject _objZCam; // 오브젝트 클릭시 활성화할 줌(Zoom) 카메라
        [SerializeField] Collider _col;
        public List<RoomItem> _list_Item;    // 오브젝트의 자식 아이템

        public bool _lock = false;

        public virtual void Init()
        {
            if (_room != Room.None)
            {
                _objZCam = CameraManager.I.transform.Find($"{_room}/Cam_{gameObject.name}").gameObject;
                if (_objZCam != null)
                    _objZCam.SetActive(false);

                SetCol(true);

                _list_Item = new List<RoomItem>(transform.GetComponentsInDirectChild<RoomItem>());
                ListSetCol(_list_Item, false);
                List_ItemInit();
            }
        }

        protected virtual void OnMouseUp()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom)
            {
                if (_objZCam != null)
                {
                    UIManager.I.OnChangeView(false);
                    OnClick(true);
                }
            }
        }

        public virtual bool OnClick_BackBtn()
        {
            if (_objZCam != null && _objZCam.activeSelf)
            {
                OnClick(false);
            }
            return false;
        }

        protected virtual void OnClick(bool stat) // true : MouseDown, false : BackBtn
        {
            if (!_lock)
            {
                _objZCam.SetActive(stat);
                SetCol(!stat);
                CameraManager.I._isZoom = stat;
                ListSetCol(_list_Item, stat);
            }
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

        public void List_ItemInit()
        {
            if(_list_Item != null)
            {
                foreach (RoomItem item in _list_Item)
                {
                    item.Init();
                }
            }
        }
        public void SetCol(bool stat)
        {
            if (_col == null)
                _col = GetComponent<Collider>();
            if (_col != null)
                _col.enabled = stat;
        }
    }
}
