using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ToyTrain : MonoBehaviour
    {
        public static ToyTrain I;

        [SerializeField] GameObject _trainIn;
        [SerializeField] GameObject _trainOut;
        [SerializeField] GameObject _trainWrongOut;
        [SerializeField] GameObject _magnet;
        [SerializeField] GameObject _key;

        [SerializeField] bool _ismagnet = false;
        [SerializeField] bool _isbattery1 = false;
        [SerializeField] bool _isbattery2 = false;
        [SerializeField] bool _turn = false;
        [SerializeField] bool _in = false;
        [SerializeField] bool _out = false;
        [SerializeField] bool _wrongout = false;

        void Awake()
        {
            I = this;
        }
            
        void Start()
        {
            _trainIn = RoomObjManager.I.transform.Find("Room_Spring/North/Train_In").gameObject;
            _trainOut = RoomObjManager.I.transform.Find("Room_Spring/North/Train_Out").gameObject;
            _trainWrongOut = RoomObjManager.I.transform.Find("Room_Spring/North/Train_WrongOut").gameObject;
            _magnet = transform.Find("Magnet").gameObject;
            _key = transform.Find("Key").gameObject;
            
            _magnet.SetActive(false);
            _key.SetActive(false);

            _ismagnet = false;
            _turn = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_ismagnet == true)
            {
                _magnet.SetActive(true);
            }
        }

        void OnMouseUp()
        {
            Debug.Log("이동");
            if (_isbattery1 == true && _isbattery2 == true)
            {
                if (_wrongout == true || _out == true)
                {
                    transform.position = _trainIn.transform.position;
                    _wrongout = false;
                    _out = false;
                }
                if (_wrongout == false)
                {

                    if (_turn == true)
                    {
                        transform.position = _trainOut.transform.position;
                        _out = true;
                        if (_ismagnet == true)
                            _key.SetActive(true);
                        else
                            _key.SetActive(false);
                    }
                    else
                    {
                        transform.position = _trainWrongOut.transform.position;
                        _wrongout = true;
                    }
                }
            }
        }

        protected void MountingItem()
        {
            
        }

        public void TurnTrain()
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            _turn = true;
        }
    }
}
