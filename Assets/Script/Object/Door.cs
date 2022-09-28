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
        private void Start()
        {
            if (!UIManager.I.transform.Find("Img_BlackBg").TryGetComponent(out _img_Bg))
                Debug.LogError("_img_Bg is Null");
            _img_Bg.gameObject.SetActive(false);
        }
        private void OnMouseUp()
        {
            if(true)
            {
                transform.localPosition = _openPos;
                transform.Rotate(0, -45, 0);
                // 화면 어두워짐, 문열리는 사운드 재생
                StartCoroutine(BGActive());
                // 아웃트로 재생
            }
        }
        IEnumerator BGActive()
        {
            while(_img_Bg.color.a < 1)
            {
                yield return null;
                _img_Bg.color += new Color(0, 0, 0, 1.0f * Time.deltaTime);
            }
            yield return null;
        }
    }
}
