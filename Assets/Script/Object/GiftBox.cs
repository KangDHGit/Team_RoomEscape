using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class GiftBox : ChildObj
    {
        [SerializeField] GameObject _cover;
        [SerializeField] GameObject _obj_Paper; //Hint_Paper(GiftBox)
        bool _isopen = false; public bool IsOpen { get { return _isopen; } }

        Vector3 _openPos = new Vector3(0, -0.07f, 0.108f);
        Vector3 _openRot = new Vector3(45, 0, 0);

        public override void Init()
        {
            base.Init();
            _cover = transform.parent.Find("GiftBox_Cover").gameObject;
            _obj_Paper = transform.Find("Hint_Paper(GiftBox)").gameObject;
            _obj_Paper.GetComponent<Hint_GiftBox>().Init();
            _obj_Paper.SetActive(false);
        }
        protected override void OnMouseUp()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom_Child)
            {
                if (_objZCam != null)
                {
                    OnClick(true);
                }
                if (_cover != null && !_isopen)
                {
                    _cover.transform.localPosition = _openPos;
                    _cover.transform.Rotate(_openRot);
                    _isopen = true;
                }
            }
        }
        public override bool OnClick_BackBtn()
        {
            OnClick(false);
            return false;
        }
        protected override void OnClick(bool stat) // true : MouseDown, false : BackBtn
        {
            _objZCam.SetActive(stat);
            SetCol(!stat);
            CameraManager.I._isZoom_Child = stat;
            ListSetCol(_list_Item, stat);
            _obj_Paper.SetActive(true);
        }
    }
}
