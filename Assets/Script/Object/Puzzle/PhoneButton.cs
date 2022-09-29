using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RoomEscape
{
    public class PhoneButton : MonoBehaviour
    {
        Chatter_Phone _puzzle;
        RoomObj _phone;


        // 버튼 누르기 효과
        Vector3 _originPos;
        Vector3 _pushPos;
        Coroutine _coroutine;
        bool _isCoroutineing = false;

        private void Start()
        {
            _puzzle = transform.parent.GetComponent<Chatter_Phone>();
            _phone = transform.parent.GetComponent<RoomObj>();
        }
        void OnMouseUp()
        {
            if (_isCoroutineing == false)
            {
                _coroutine = StartCoroutine(PhonePush());
            }
            /*
            switch (transform.gameObject.name)
            {
                case "Key-1":
                    _nowButton = _buttons.transform.Find("Key-1").gameObject;
                    break;
            }
            */
            IEnumerator PhonePush()
            {
                _pushPos = new Vector3(transform.localPosition.x, 0.0585f, transform.localPosition.z);
                _isCoroutineing = true;
                _originPos = transform.localPosition;
                while (transform.localPosition.y > _pushPos.y)
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, _pushPos, 0.15f * Time.deltaTime);
                    yield return null;
                }
                while (transform.localPosition.y < _originPos.y)
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, _originPos, 0.15f * Time.deltaTime);
                    yield return null;
                }
                _isCoroutineing = false;
                yield return null;
            }



            if (_phone._objZCam.activeSelf)
            {
                if (_puzzle._input.Count < 4)
                {
                    _puzzle._input.Add(gameObject.name);
                    foreach (string a in _puzzle._input)
                    {
                        Debug.Log(a);
                    }
                }
                if (_puzzle._input.Count == 4)
                {
                    _puzzle._input.Add(gameObject.name);
                    _puzzle.CheckAnswer();
                }
            }
        }
    }
}

