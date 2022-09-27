using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Magnet : RoomItem
    {
        protected override void OnMouseUp()
        {
            if (Toy_Chest.I._IsOpen)
            {
                base.OnMouseUp();
            }
        }
    }
}
