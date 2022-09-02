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
            CameraManager.I._isZoom = false;
            base.OnMouseDown();
        }

        public override void OnClick_BackBtn()
        {
            base.OnClick_BackBtn();
            CameraManager.I._isZoom = true;
            UIManager.I.OnChangeView(false);
        }
    }
}
