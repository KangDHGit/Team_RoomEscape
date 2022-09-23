using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ToyTrain : MonoBehaviour
    {
        [SerializeField] GameObject _trainIn;
        [SerializeField] GameObject _trainOut;
        [SerializeField] GameObject _trainWrongOut;

        [SerializeField] bool _magnet = false;
        [SerializeField] bool _battery1 = false;
        [SerializeField] bool _battery2 = false;
        [SerializeField] bool _hint = false;
        [SerializeField] bool _in = false;
        [SerializeField] bool _out = false;


        // Start is called before the first frame update
        void Start()
        {
            _trainIn = RoomObjManager.I.transform.Find("Room_Spring/North/Train_In").gameObject;
            _trainOut = RoomObjManager.I.transform.Find("Room_Spring/North/Train_Out").gameObject;
            _trainWrongOut = RoomObjManager.I.transform.Find("Room_Spring/North/Train_WrongOut").gameObject;

            _in = true;
        }

        // Update is called once per frame
        void Update()
        {/*
            if (_hint == true)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (_in == true)
            {
                transform.position = _trainIn.transform.position;
            }
            if (_out == true)
            {
                if (_hint == false)
                    transform.position = _trainWrongOut.transform.position;
                else
                    transform.position = _trainOut.transform.position;
            }*/
        }

        void OnMouseUp()
        {
            if (_in == true && _out == false)
            {
                if (_hint == false)
                {
                    transform.position = _trainWrongOut.transform.position;
                    _out = true;
                    _in = false;
                }
                else
                {
                    transform.position = _trainOut.transform.position;
                    _out = true;
                    _in = false;
                }
                   
            }
            else if (_out == true && _in == false)
            {
                transform.position = _trainIn.transform.position;
            }
            
        }
    }
}
