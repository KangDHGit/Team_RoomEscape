using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Backpack : ChildObj
    {
        [SerializeField] GameObject _cover;
        bool _isopen = false;
        Vector3 _openRot = new Vector3(0, 0, -109.746f);
        public override void Init()
        {
            base.Init();
            _cover = transform.Find("Base/Cover").gameObject;
        }
        protected override void OnMouseUp()
        {
            base.OnMouseUp();
            if(_cover != null && !_isopen)
            {
                _cover.transform.Rotate(_openRot);
                _isopen = true;
            }
        }
    }
}
