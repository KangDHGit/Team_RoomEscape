using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{


    public class RoomItem : MonoBehaviour
    {
        public static RoomItem I;
        public string _name = "";
        Collider _col;

        //public bool _itemCheck() { return _name()};
        void Awake()
        {
            I = this;
        }

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
                SoundManager.I._as_PickUP.Play();
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
