using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RoomEscape
{
    public class UI_InvenItem : MonoBehaviour
    {
        Text _txt_ItemName;
        Image _imgItem;
        Vector3 _vecImgOrigin;

        private void Start()
        {
            //_txt_ItemName = transform.Find("Txt_Name").GetComponent<Text>();
            //_imgItem = transform.Find("Img_Item").GetComponent<Image>();
            //_vecImgOrigin = _imgItem.transform.localPosition;
        }

        public void Init()
        {
            //_txt_ItemName = transform.Find("Txt_Name").GetComponent<Text>();
            //_imgItem = transform.Find("Img_Item").GetComponent<Image>();
            //_vecImgOrigin = _imgItem.transform.localPosition;
        }
        //public void DragItem()
        //{
        //    _imgItem.rectTransform.position = Input.mousePosition;
        //}
        //public void EndDrag()
        //{
        //    // 레이 = 마우스 클릭위치
        //    Ray ray = CameraManager.I._objMCam_Now.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        //    // ray위치에 레이캐스트를 해서 걸리면 hitInfo에 정보를 넣음
        //    if (Physics.Raycast(ray, out RaycastHit hitInfo))
        //    {
        //        Debug.Log(hitInfo.transform.gameObject.name);
        //        if (hitInfo.transform.TryGetComponent<Door>(out Door hitDoor))
        //        {
        //            if (hitDoor.CheckItem(_txt_ItemName.text))
        //            {
        //                _imgItem.rectTransform.localPosition = _vecImgOrigin;
        //                this.gameObject.SetActive(false);
        //            }
        //        }
        //        _imgItem.rectTransform.localPosition = _vecImgOrigin;
        //    }
        //    else
        //    {
        //        _imgItem.rectTransform.localPosition = _vecImgOrigin;
        //    }
        //}
        public void Info(string itemName)
        {
            _txt_ItemName = transform.Find("Txt_Name").GetComponent<Text>();


            _txt_ItemName.text = itemName;
        }
        
    }
}
