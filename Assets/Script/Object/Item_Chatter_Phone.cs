using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Item_Chatter_Phone : RoomItem
    {
        GameObject _obj_Chatter_Phone;

        public override void Init()
        {
            base.Init();
            _obj_Chatter_Phone = transform.parent.parent.Find("Chatter_Phone").gameObject;
            if (_obj_Chatter_Phone != null)
                _obj_Chatter_Phone.SetActive(false);
        }
        protected override void OnMouseEnter()
        {
            //Debug.Log(_name);
        }
        protected override void OnMouseUp()
        {
            if (!CameraManager.I._isZoom)
                return;
            if (UIManager.I.CheckClickUI() == false)
            {
                if (DialLock.I.gameObject.activeSelf == false)
                {
                    _obj_Chatter_Phone.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
