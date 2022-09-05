using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ChildObj : RoomObj
    {
        protected override void Start()
        {
            base.Start();
            SetCol(false);
        }
        protected override void OnMouseDown()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom_Child)
            {
                if (_objZCam != null)
                {
                    OnClick(true);
                }
            }
        }

        public override bool OnClick_BackBtn()
        {
            OnClick(false);
            return false;
        }
        protected override void OnClick(bool stat) // true : MouseDown, false : BackBtn
        {
            _objZCam.SetActive(stat);
            SetCol(!stat);
            CameraManager.I._isZoom_Child = stat;
            ListSetCol(_list_Item, stat);
        }
    }
}
