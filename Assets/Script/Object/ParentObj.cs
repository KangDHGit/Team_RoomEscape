using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ParentObj : RoomObj
    {
        public List<RoomObj> _list_ChildRoomObj; // 오브젝트의 자식 오브젝트

        public override void Init()
        {
            base.Init();
            _list_ChildRoomObj = new List<RoomObj>(transform.GetComponentsInDirectChild<RoomObj>());

            foreach (var childObj in _list_ChildRoomObj)
            {
                childObj.Init();
            }

            ListSetCol(_list_ChildRoomObj, false);
        }

        protected override void OnMouseDown()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom)
            {
                if (_objZCam != null)
                {
                    ListSetCol(_list_ChildRoomObj, true);
                    UIManager.I.OnChangeView(false);
                    OnClick(true);
                }
            }
        }

        public override bool OnClick_BackBtn()
        {
            if (CheckOnChildCam())
            {
                foreach (ChildObj obj in _list_ChildRoomObj)
                {
                    obj.OnClick_BackBtn();
                }
                return true;
            }
            else
            {
                OnClick(false);
                return false;
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
