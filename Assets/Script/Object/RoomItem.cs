using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public enum ItemType
    {
        PINK_KEY,
        GRAY_KEY,
        BATTERY,
        MAGNET
    }
    public class RoomItem : MonoBehaviour
    {
        public string _name = "";
        public ItemType _itemttype;
        Collider _col;

        public virtual void Init()
        {

        }

        protected virtual void OnMouseEnter()
        {
            //Debug.Log(_name);
        }
        protected virtual void OnMouseUp()
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
