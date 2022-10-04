using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Pink_Key : RoomItem
    {
        protected override void OnMouseUp()
        {
            if (transform.parent.Find("DoorOpen").gameObject.activeSelf)
            {
                base.OnMouseUp();
            }
        }
    }
}
