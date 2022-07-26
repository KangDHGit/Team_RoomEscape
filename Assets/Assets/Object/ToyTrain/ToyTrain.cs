using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class ToyTrain : MonoBehaviour
    {
        public static ToyTrain I;

        GameObject _trainIn;
        GameObject _trainOut;
        GameObject _trainWrongOut;
        GameObject _magnet;
        GameObject _key;

        Renderer   _trainBulb;
        GameObject _trainLight;

        [SerializeField] bool _turn =       false;
        [SerializeField] bool _isMove =     false;

        [SerializeField] bool[] _isitem;
        [SerializeField] string[] _itemName;


        AudioSource _trainHorn;

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

            _turn = false;

            _trainLight.SetActive(false);

            

            _isitem = new bool[3];

            _trainHorn = GetComponent<AudioSource>();
        }

        void OnMouseUp()
        {
            MountingItem();


            Debug.Log("이동");
            if (_isitem[1] == true && _isitem[2] == true)
            {  
                if (_isMove == true)
                {
                    transform.position = _trainIn.transform.position;
                    _isMove = false;
                }
                else
                {
                    _trainHorn.Play();
                    if (_turn == true)
                    {
                        transform.position = _trainOut.transform.position;
                        _isMove = true;
                        if (_isitem[0] == true)
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
            if (UI_Inventory.I._selItem == null)
            {
                return;
            }

            else
            {
                _isMove = true;
                for (int i = 0; i < _itemName.Length-1; i++)
                {
                    if (UI_Inventory.I._selItem._txt_ItemName.text == _itemName[i])
                    {
                        
                        if (_isitem[1] == true)
                        {
                            _isitem[2] = true;
                        }
                        _isitem[i] = true;
                    }
                }
                UI_Inventory.I.DeleteItem();
            }


            if (_isitem[0] == true)
            {
                _magnet.SetActive(true);
            }
            if (_isitem[1] == true && _isitem[2] == true)
            {
                _trainBulb.sharedMaterial = DialLock.I._bulbColor[2];
                _trainLight.SetActive(true);
            }
        }

        public void TurnTrain()
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            _turn = true;
        }


    }
}
