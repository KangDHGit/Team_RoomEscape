using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class TurnCheck : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Right_Side")
            {
                DialLock.I._rightMoving = true;
                DialLock.I._leftMoving = false;
                //_rightMoving = true;
                //_leftMoving = false;
            }
            if (other.name == "Left_Side")
            {
                DialLock.I._rightMoving = false;
                DialLock.I._leftMoving = true;
                //_rightMoving = false;
                //_leftMoving = true;
            }
        }
    }
}
