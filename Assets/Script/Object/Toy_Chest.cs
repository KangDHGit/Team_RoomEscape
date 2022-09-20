using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Toy_Chest : ChildObj
    {
        public GameObject _objZCam_Open;
        public override void Init()
        {
            base.Init();
            _objZCam_Open = CameraManager.I.transform.Find($"{_room}/Cam_{gameObject.name}(Open)").gameObject;
            if (_objZCam_Open != null)
                _objZCam_Open.SetActive(false);
        }
        public void IsOpen()
        {
            _objZCam = _objZCam_Open;
        }
    }
}
