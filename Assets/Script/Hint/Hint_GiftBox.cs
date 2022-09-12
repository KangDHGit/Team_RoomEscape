using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Hint_GiftBox : MonoBehaviour
    {
        GameObject _circleCheck;
        public void Init()
        {
            _circleCheck = RoomObjManager.I.transform.Find("Room_Spring/West/Calendar/CircleCheck").gameObject;
            if (_circleCheck != null)
                _circleCheck.SetActive(false);
        }

        private void OnMouseDown()
        {
            UIManager.I.Set_Ui_Hint_GiftBox(true);
            _circleCheck.SetActive(true);
        }
    }
}
