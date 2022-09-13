using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Drawer : ChildObj
    {
        bool _isOpen;
        Vector3 _closePos;
        public Vector3 _openPos;

        public override void Init()
        {
            SetCol(false);
            _isOpen = false;
            _closePos = transform.localPosition;
        }

        protected override void OnMouseUp()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom_Child)
            {
                if (_isOpen && Hint_Pink_Drawers.I.RayCheckHint())
                    return;
                OnClick(true);
                MoveDrawer();
            }
        }

        protected override void OnClick(bool stat) // true : MouseDown, false : BackBtn
        {
            if (_objZCam != null)
            {
                _objZCam.SetActive(stat);
            }
        }
        void MoveDrawer()
        {
            if (_isOpen)
            {
                transform.localPosition = _closePos;
                ListSetCol(_list_Item, false);
                _isOpen = false;
            }
            else
            {
                transform.localPosition = _openPos;
                ListSetCol(_list_Item, true);
                _isOpen = true;
            }
        }
    }
}
