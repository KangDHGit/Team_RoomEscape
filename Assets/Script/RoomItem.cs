using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class RoomItem : MonoBehaviour
    {
        public string _name;

        private void OnMouseEnter()
        {
            Debug.Log(_name);
        }
        private void OnMouseDown()
        {
            if (!CameraManager.CamMgr._isZoom)
                return;
            Debug.Log(_name + " Get!!!!");
            Inventory.I.AddItem(_name);
            gameObject.SetActive(false);
        }
    }
}
