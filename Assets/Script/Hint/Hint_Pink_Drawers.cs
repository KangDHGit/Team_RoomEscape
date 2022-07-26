using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Hint_Pink_Drawers : MonoBehaviour
    {
        public static Hint_Pink_Drawers I;
        Camera _pink_drawersCam;
        RoomObj _binoculars;
        private RaycastHit[] _hits;

        private void Awake()
        {
            I = this;
        }
        public void Init()
        {
            _pink_drawersCam = CameraManager.I.transform.Find("SPRING/Cam_Pink_drawers").GetComponent<Camera>();
            _binoculars = RoomObjManager.I.transform.Find("Room_Spring/South1/ToyBoxes/Binoculars").GetComponent<RoomObj>();
            //_binoculars._lock = true;
        }
        public bool RayCheckHint()
        {
            if (_pink_drawersCam != null && _pink_drawersCam.gameObject.activeSelf)
            {
                Ray ray = _pink_drawersCam.ScreenPointToRay(Input.mousePosition);

                _hits = Physics.RaycastAll(ray);
                foreach (RaycastHit hit in _hits)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.name == this.gameObject.name)
                    {
                        UIManager.I.Set_Ui_Hint_Binoculars(true);
                        _binoculars._lock = false;
                        return true;
                    }
                    else
                        continue;
                }
                return false;
            }
            return false;
        }
    }
}
