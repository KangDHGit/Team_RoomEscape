using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class RoomItem : MonoBehaviour
    {
        public string _name = "";
        Collider _col;

        public virtual void Init()
        {

        }

        protected virtual void OnMouseEnter()
        {
            //Debug.Log(_name);
        }
        protected virtual void OnMouseDown()
        {
            if (!CameraManager.I._isZoom)
                return;
            //Debug.Log(_name + " Get!!!!");
            if (UIManager.I.CheckClickUI() == false)
            {
                Inventory.I.AddItem(_name);

                gameObject.SetActive(false);
            }

        }

        public void SetCol(bool stat)
        {
            if (_col == null)
                _col = GetComponent<Collider>();
            _col.enabled = stat;
        }
    }
}
