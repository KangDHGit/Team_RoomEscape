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
        GameObject _iven_Btn_Open;
        GameObject _iven_Btn_Close;
        GameObject _ui_Hint_GiftBox;
        GameObject _ui_Hint_Binoculars;

        private GraphicRaycaster _gRayCaster; //UI Raycast

        private void Awake()
        {
            I = this;

            _gRayCaster     = GetComponent<GraphicRaycaster>();
            _obj_Btn_Left   = transform.Find("Btn_Left").gameObject;
            _obj_Btn_Right  = transform.Find("Btn_Right").gameObject;
            _obj_Btn_Down   = transform.Find("Btn_Down").gameObject;
            _iven_Btn_Open  = transform.Find("Iven_Btn_Open").gameObject;
            _iven_Btn_Close = transform.Find("Iven_Btn_Closes").gameObject;
            _ui_Hint_GiftBox = transform.Find("UI_Hint_Paper(GiftBox)").gameObject;
            _ui_Hint_Binoculars = transform.Find("UI_Hint_Binoculars").gameObject;
        }

        public void Init()
        {
            OnChangeView(true);
            OnOpenIven  (false);
            _ui_Hint_GiftBox.SetActive(false);
            _ui_Hint_Binoculars.SetActive(false);
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
            _obj_Btn_Down.  SetActive(!isMainView);
            _obj_Btn_Right. SetActive(isMainView);
            _obj_Btn_Left.  SetActive(isMainView);
        }

        public void OnOpenIven(bool isOpen)
        {
            _iven_Btn_Open.           SetActive(!isOpen);
            _iven_Btn_Close.          SetActive(isOpen);
            UI_Inventory.I.gameObject.SetActive(isOpen);
        }

        public void Set_Ui_Hint_GiftBox(bool stat)
        {
            _ui_Hint_GiftBox.SetActive(stat);
        }
        public void Set_Ui_Hint_Binoculars(bool stat)
        {
            _ui_Hint_Binoculars.SetActive(stat);
        }
    }
}
