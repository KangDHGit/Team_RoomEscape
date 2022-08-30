using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class RoomItem : MonoBehaviour
    {
        public string _name;
        Collider _col;
        
        private void OnMouseEnter()
        {
            Debug.Log(_name);
        }
        private void OnMouseDown()
        {
            if (!CameraManager.I._isZoom)
                return;
            Debug.Log(_name + " Get!!!!");
            Inventory.I.AddItem(_name);
            gameObject.SetActive(false);
        }

        public void SetCol(bool stat)
        {
            if (_col == null)
                _col = GetComponent<Collider>();
            _col.enabled = stat;
        }
    }
}
