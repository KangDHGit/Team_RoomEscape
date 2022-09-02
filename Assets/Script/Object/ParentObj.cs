using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ParentObj : RoomObj
    {
        public List<RoomObj> _list_ChildRoomObj; // 오브젝트의 자식 오브젝트

        protected override void Start()
        {
            base.Start();
            _list_ChildRoomObj = new List<RoomObj>(transform.GetComponentsInDirectChild<RoomObj>());
            ListSetCol(_list_ChildRoomObj, false);
        }

        protected override void OnMouseDown()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom)
            {
                if (_objZCam != null)
                {
                    ListSetCol(_list_ChildRoomObj, true);
                }
            }
            base.OnMouseDown();
        }

        public override void OnClick_BackBtn()
        {
            if (_objZCam != null)
            {
                if (_objZCam.gameObject.activeSelf)
                {
                    if (CheckOnChildCam())
                    {
                        foreach (ChildObj obj in _list_ChildRoomObj)
                        {
                            obj.OnClick_BackBtn();
                        }
                    }
                    else
                    {
                        base.OnClick_BackBtn();
                    }
                }
            }
        }

        bool CheckOnChildCam()
        {
            if (_list_ChildRoomObj == null)
                return false;
            foreach (RoomObj roomObj in _list_ChildRoomObj)
            {
                if (roomObj._objZCam.activeSelf)
                    return true;
                else if (!roomObj._objZCam.activeSelf)
                {
                    continue;
                }
            }
            return false;
        }
    }
}
