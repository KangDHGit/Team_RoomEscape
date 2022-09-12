using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Hint_GiftBox : MonoBehaviour
    {
        //public Collider _col; 
        //public void Init()
        //{
        //    _col = GetComponent<Collider>();
        //    if(_col != null)
        //        _col.enabled = false;
        //}

        private void OnMouseDown()
        {
            UIManager.I.Set_Ui_Hint_GiftBox(true);
        }
    }
}
