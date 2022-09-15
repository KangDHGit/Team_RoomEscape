using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class TurnCheck : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains("Right"))
                DialLock.I._isRightMoving = true;
            if (other.gameObject.name.Contains("Left"))
                DialLock.I._isRightMoving = false;
        }
    }
}
