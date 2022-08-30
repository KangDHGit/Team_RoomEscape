using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RoomEscape
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager I;

        private GraphicRaycaster _gRayCaster; //UI Raycast

        private void Awake()
        {
            I = this;
            _gRayCaster = GetComponent<GraphicRaycaster>();
        }

        public void Init()
        {

        }

        private void Update()
        {
            //if(Input.GetMouseButtonDown(0))
            //    CheckClickUI();
        }

        public bool CheckClickUI()
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            // EventSystem.current : 씬에있는 현재 이벤트 시스템
            data.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            _gRayCaster.Raycast(data, results);

            if (results.Count > 0)
            {
                foreach (var item in results)
                {
                    Debug.Log(item.gameObject.name);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
