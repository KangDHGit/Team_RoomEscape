using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoomEscape
{
    public class Door : MonoBehaviour
    {
        Vector3 _openPos = new Vector3(0.68f,0,-0.65f);
        Image _img_Bg;
        GameObject _ui_GameEnd;
        AudioSource _as_DoorOpen;
        bool _isOpened = false;
        string _itemName = "회색열쇠";

        private void Start()
        {
            if (!UIManager.I.transform.Find("UI_GameCycle/UI_Black").TryGetComponent(out _img_Bg))
                Debug.LogError("_img_Bg is Null");
            _ui_GameEnd = UIManager.I.transform.Find("UI_GameCycle/UI_GameEnd").gameObject;
            if (_ui_GameEnd != null)
                _ui_GameEnd.SetActive(false);
            else
                Debug.LogError("_ui_GameEnd");
            if (!TryGetComponent(out _as_DoorOpen))
                Debug.LogError("_ui_GameEnd is Null");
        }
        private void OnMouseUp()
        {
            if (UI_Inventory.I._selItem != null)
            {
                if (UI_Inventory.I._selItem._txt_ItemName.text == _itemName && !_isOpened)
                {
                    transform.localPosition = _openPos;
                    transform.Rotate(0, 45, 0);
                    // 화면 어두워짐, 문열리는 사운드 재생
                    _as_DoorOpen.Play();
                    StartCoroutine(BGActive());
                    // 아웃트로 재생
                    UI_Inventory.I.DeleteItem();
                    _isOpened = true;
                }
            }
            else
            {
                transform.parent.GetComponent<AudioSource>().Play();
            }
        }
        IEnumerator BGActive()
        {
            _img_Bg.color = Color.clear;
            _img_Bg.gameObject.SetActive(true);

            while (_img_Bg.color.a < 1)
            {
                yield return null;
                _img_Bg.color += new Color(0, 0, 0, 1.0f * Time.deltaTime);
            }
            _ui_GameEnd.SetActive(true);
            yield return null;
        }
    }
}
