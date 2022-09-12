using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class GiftBox : ChildObj
    {
        [SerializeField] GameObject _cover;
        bool _isopen = false;
        Vector3 _openPos = new Vector3(0, -0.07f, 0.108f);
        Vector3 _openRot = new Vector3(45, 0, 0);

        public override void Init()
        {
            base.Init();
            _cover = transform.parent.Find("GiftBox_Cover").gameObject;
        }
        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            if (_cover != null && !_isopen)
            {
                _cover.transform.localPosition = _openPos;
                _cover.transform.Rotate(_openRot);
                _isopen = true;
            }
        }
    }
}
