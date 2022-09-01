using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ChildObj : RoomObj
    {
        protected override void OnMouseDown()
        {
            CameraManager.I._isZoom = false;
            base.OnMouseDown();
        }
    }
}
