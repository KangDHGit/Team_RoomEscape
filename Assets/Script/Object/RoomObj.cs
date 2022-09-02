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

        protected virtual void Start()
        {
            if (_room != Room.None)
            {
                _objZCam = CameraManager.I.transform.Find($"{_room}/Cam_{gameObject.name}").gameObject;
                if (_objZCam != null)
                    _objZCam.SetActive(false);

                SetCol(true);

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
                    SetCol(false);
                    CameraManager.I._isZoom = true;
                    ListSetCol(_list_Item, true);
                    UIManager.I.OnChangeView(false);
                }
            }
        }

        public virtual void OnClick_BackBtn()
        {
            if (_objZCam != null)
            {
                if (_objZCam.gameObject.activeSelf)
                {
                    _objZCam.SetActive(false);
                    SetCol(true);
                    CameraManager.I._isZoom = false;
                    ListSetCol(_list_Item, false);
                    UIManager.I.OnChangeView(true);
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

        public void SetCol(bool stat)
        {
            if (_col == null)
                _col = GetComponent<Collider>();
            if (_col != null)
                _col.enabled = stat;
        }
    }
}
