using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class PhonePuzzle : MonoBehaviour
    {
        string[] _solution = { "0", "3", "0", "2" };
        string[] _input;

        void Update()
        {
        }
        void OnMouseDown()
        {
            for (int i =0; _input.Length<4; i++)
            {
                if (_input[i] == null)
                {
                    // 저장하는 로직
                    _input[i] = gameObject.name;
                }
            }
            // 정답을 분별하는 로직
            if (_solution[0] == _input[0] && _solution[1] == _input[1] && _solution[2] == _input[2] && _solution[3] == _input[3])
            {
                Debug.Log("정답");
            }
            else
            {
                Debug.Log("오답");
            }



        }

    }

            
}




