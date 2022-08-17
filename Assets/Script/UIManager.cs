using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RoomEscape
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager _uiMgr;

        private GraphicRaycaster _gRayCaster; //UI Raycast

        private void Awake()
        {
            _uiMgr = this;
            _gRayCaster = GetComponent<GraphicRaycaster>();
        }

        public bool CheckClickUI()
        {
            PointerEventData data = new PointerEventData(EventSystem.current); // 
            data.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            _gRayCaster.Raycast(data, results);

            if (results.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
