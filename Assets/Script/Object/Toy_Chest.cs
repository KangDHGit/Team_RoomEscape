using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Toy_Chest : ChildObj
    {
        public GameObject _objZCam_Open;
        [SerializeField] GameObject _obj_Lid;
        Vector3 _lid_OpenPos = new Vector3(-0.332f,-0.096f,0);
        public override void Init()
        {
            base.Init();
            _objZCam_Open = CameraManager.I.transform.Find($"{_room}/Cam_{gameObject.name}(Open)").gameObject;
            if (_objZCam_Open != null)
                _objZCam_Open.SetActive(false);
            _obj_Lid = transform.Find("Lid").gameObject;
            if (_obj_Lid == null)
                Debug.LogError("_obj_Lid is Null");
        }
        public void IsOpened()
        {
            _objZCam.SetActive(false);
            _objZCam = _objZCam_Open;
            _objZCam.SetActive(true);
            _obj_Lid.transform.position = _lid_OpenPos;
            _obj_Lid.transform.Rotate(new Vector3(0, 0, -30));
        }
    }
}
