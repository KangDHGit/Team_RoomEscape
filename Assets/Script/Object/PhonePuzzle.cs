using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_RoomEscape
{
    public class PhonePuzzle : MonoBehaviour
    {
        string[] _solution = { "Key-0", "Key-3", "Key-0", "Key-2" };
        public List<string> _input = new List<string>();


        void Start()
        {
            //_input = new string[4];
        }
        public void CheckAnswer()
        {
            if (_solution[0] == _input[0] && _solution[1] == _input[1] && _solution[2] == _input[2] && _solution[3] == _input[3])
            {
                Debug.Log("정답");
            }
            else
            {
                Debug.Log("오답");
                _input = null;
            }
        }

    }

            
}




