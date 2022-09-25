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

        private void Start()
        {
            _puzzle = transform.parent.GetComponent<Chatter_Phone>();
            _phone = transform.parent.GetComponent<RoomObj>();
        }
        void OnMouseDown()
        {
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

