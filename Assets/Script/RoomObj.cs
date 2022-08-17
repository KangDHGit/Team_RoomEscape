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
        
        public Room _room; // 이 오브젝트가 속한 방
        public GameObject _objZCam; // 오브젝트 클릭시 활성화할 줌(Zoom) 카메라
        public List<RoomItem> _itemList;    // 오브젝트의 자식 아이템

        void Start()
        {
            if (_room != Room.None)
            {
                _objZCam = CameraManager.CamMgr.transform.Find($"{_room}/Cam_{gameObject.name}").gameObject;
                if (_objZCam != null)
                    _objZCam.SetActive(false);
                _itemList = new List<RoomItem>(transform.GetComponentsInChildren<RoomItem>());
                ItemListSetCol(false);
            }
        }

        private void OnMouseDown()
        {
            if (_objZCam != null)
            {
                _objZCam.SetActive(true);
                GetComponent<Collider>().enabled = false;
                CameraManager.CamMgr._isZoom = true;
                ItemListSetCol(true);
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
            if (_itemList != null)
            {
                foreach (var item in _itemList)
                {
                    item.SetCol(stat);
                }
            }
        }
    }
}
