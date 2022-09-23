using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ToyTrain : MonoBehaviour
    {
        public GameObject _trainIn;
        GameObject _trainOut;
        GameObject _trainWrongOut;

        // Start is called before the first frame update
        void Start()
        {
            _trainIn = RoomObjManager.I.transform.Find("Room_Spring/North/Train_In").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
