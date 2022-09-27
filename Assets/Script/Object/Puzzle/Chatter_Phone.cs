using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Chatter_Phone : MonoBehaviour
    {
        string[] _solution = { "Key-0", "Key-3", "Key-0", "Key-2" };
        public List<string> _input = new List<string>();
        bool _isCall = false; public bool _IsCall { get { return _isCall; } }
        

        void Start()
        {
            //_input = new string[4];
        }
        public void CheckAnswer()
        {
            if (_solution[0] == _input[0] && _solution[1] == _input[1] && _solution[2] == _input[2] && _solution[3] == _input[3])
            {
                _isCall = true;
                if (TryGetComponent<PhoneObj>(out PhoneObj phone))
                    phone._ui_Hint_ChatterPhone.SetActive(true);
                Debug.Log("정답");
                ToyTrain.I.TurnTrain();
            }
            else
            {
                Debug.Log("오답");
                _input.Clear();
            }
        }

    }

            
}




