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

        [SerializeField] GameObject _obj_Btn_Left;
        [SerializeField] GameObject _obj_Btn_Right;
        [SerializeField] GameObject _obj_Btn_Down;

        private GraphicRaycaster _gRayCaster; //UI Raycast

        private void Awake()
        {
            I = this;
            _gRayCaster = GetComponent<GraphicRaycaster>();
            _obj_Btn_Left = transform.Find("Btn_Left").gameObject;
            _obj_Btn_Right = transform.Find("Btn_Right").gameObject;
            _obj_Btn_Down = transform.Find("Btn_Down").gameObject;
        }

        public void Init()
        {
            OnChangeView(true);
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

        public void OnChangeView(bool isMainView) //true : 메인뷰 상태, false : 확대된 상태
        {
            _obj_Btn_Down.SetActive(!isMainView);
            _obj_Btn_Right.SetActive(isMainView);
            _obj_Btn_Left.SetActive(isMainView);
        }
    }
}
