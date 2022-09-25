using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Cabaninha : RoomObj
    {
        Collider _col_CatDoll;

        public override void Init()
        {
            base.Init();
            if (transform.Find("CatDoll").TryGetComponent(out _col_CatDoll))
                _col_CatDoll.enabled = false;
            else
                Debug.LogError("_col_CatDoll is Null");
        }

        protected override void OnClick(bool stat)
        {
            base.OnClick(stat);
            _col_CatDoll.enabled = true;
        }
    }
}
