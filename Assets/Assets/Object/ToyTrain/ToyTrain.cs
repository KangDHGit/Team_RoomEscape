using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ToyTrain : ChildObj
    {
        GameObject _trainIn;
        GameObject _trainOut;
        GameObject _trainWrongOut;

        [SerializeField] bool _magnet = false;
        [SerializeField] bool _battery1 = false;
        [SerializeField] bool _battery2 = false;
        [SerializeField] bool _hint = false;
        [SerializeField] bool _in = false;
        [SerializeField] bool _out = false;


        // Start is called before the first frame update
        public override void Init()
        {
            base.Init();
            _trainIn = RoomObjManager.I.transform.Find("Room_Spring/North/Train_In").gameObject;
            _trainOut = RoomObjManager.I.transform.Find("Room_Spring/North/Train_Out").gameObject;
            _trainWrongOut = RoomObjManager.I.transform.Find("Room_Spring/North/Train_WrongOut").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (_hint == true)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (_in == true)
            {
                transform.position = _trainIn.transform.position;
            }
            if (_out == true)
            {
                if (_hint == false)
                    transform.position = _trainWrongOut.transform.position;
                else
                    transform.position = _trainOut.transform.position;
            }
        }

        protected override void OnMouseUp()
        {
            if (!UIManager.I.CheckClickUI() && !CameraManager.I._isZoom_Child)
            {
                if (_objZCam != null)
                {
                    OnClick(true);
                }
                if (_hint == false)
                    transform.position = _trainWrongOut.transform.position;
                else
                    transform.position = _trainOut.transform.position;
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
        }
    }
}
