using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class PhoneObj : ChildObj
    {
        Chatter_Phone _chatter_Phone;
        public GameObject _ui_Hint_ChatterPhone;
        public override void Init()
        {
            base.Init();
            if (!TryGetComponent(out _chatter_Phone))
                Debug.LogError("_chatter_Phone is Null");
            _ui_Hint_ChatterPhone = UIManager.I.transform.Find("UI_Hint_ChatterPhone").gameObject;
            if (_ui_Hint_ChatterPhone == null)
                Debug.LogError("_ui_Hint_ChatterPhone is null");
        }

        protected override void OnClick(bool stat)
        {
            base.OnClick(stat);
            if(_chatter_Phone._IsCall)
                _ui_Hint_ChatterPhone.SetActive(stat);
        }
    }
}
