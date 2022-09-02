using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Test_RoomEscape
{
    public class TestButton : MonoBehaviour
    {
        PhonePuzzle _puzzle;        

        private void Start()
        {
            _puzzle = transform.parent.GetComponent<PhonePuzzle>();
        }
        void OnMouseDown()
        {
            if (_puzzle._input.Count < 4)
            {   
                _puzzle._input.Add(gameObject.name);
                foreach(string a in _puzzle._input)
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

