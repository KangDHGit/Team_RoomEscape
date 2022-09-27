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

        [SerializeField] Renderer _trainBulb;
        [SerializeField] GameObject _trainLight;

        [SerializeField] bool _ismagnet = false;
        [SerializeField] bool _isbattery1 = false;
        [SerializeField] bool _isbattery2 = false;
        [SerializeField] bool _turn = false;
        [SerializeField] bool _isMove = false;

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

            _trainBulb = transform.Find("TrainBulb").GetComponent<Renderer>();
            _trainLight = transform.Find("TrainLight").gameObject;

            _magnet.SetActive(false);
            _key.SetActive(false);

            _ismagnet = false;
            _turn = false;

            _trainLight.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (_ismagnet == true)
            {
                _magnet.SetActive(true);
            }
            if (_isbattery1 == true && _isbattery2 == true)
            {
                _trainBulb.sharedMaterial = DialLock.I._bulbColor[2];
                _trainLight.SetActive(true);
            }
        }

        void OnMouseUp()
        {
            Debug.Log("이동");
            if (_isbattery1 == true && _isbattery2 == true)
            {
                if (_isMove == true)
                {
                    transform.position = _trainIn.transform.position;
                    _isMove = false;
                }
                else
                {
                    if (_turn == true)
                    {
                        transform.position = _trainOut.transform.position;
                        _isMove = true;
                        if (_ismagnet == true)
                            _key.SetActive(true);
                    }
                    else
                    {
                        transform.position = _trainWrongOut.transform.position;
                        _isMove = true;
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
