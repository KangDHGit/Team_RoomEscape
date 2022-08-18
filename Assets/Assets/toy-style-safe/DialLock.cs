using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialLock : MonoBehaviour
{
    public ToySafe _toySafe;

    GameObject _dial;



    public float[] _password = new float[] { 36, 72, 108, 144 };
    public bool[] _password_bool = new bool[] { true, false, true, false };
    int index = 0;
    bool[] _clear = new bool[] { false, false, false, false };

    float _nowAngle = 0;

    Light[] _bulbColor;

    private float speed = 10f;

    public bool _leftMoving = false;
    public bool _rightMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        _leftMoving = false;
        _rightMoving = false;

        _dial = transform.Find("Cube.003/Dial").gameObject;
        _bulbColor = new Light[4];

        _bulbColor[0] = transform.Find("Bulb/Bulb_1/Light").GetComponent<Light>();
        _bulbColor[1] = transform.Find("Bulb/Bulb_2/Light").GetComponent<Light>();
        _bulbColor[2] = transform.Find("Bulb/Bulb_3/Light").GetComponent<Light>();
        _bulbColor[3] = transform.Find("Bulb/Bulb_4/Light").GetComponent<Light>();

        ColorWhite();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float yRot = -Input.GetAxis("Mouse Y") * speed;

            Debug.Log("yRot: " + yRot);

            if (yRot > 0.0f)
            {
                _rightMoving = true;
                _leftMoving = false;
            }

            if (yRot < 0.0f)
            {
                _rightMoving = false;
                _leftMoving = true;
            }

            _dial.transform.Rotate(0f, 0f, yRot);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _nowAngle = _dial.transform.eulerAngles.z;
            //Debug.Log($"_nowAngle : {_nowAngle}");


            Dial_Fixed(ref _nowAngle);
            //Debug.Log($"_nowAngle : {_nowAngle}");

            if (_nowAngle == _password[index] && _rightMoving == _password_bool[index])
            {
                _clear[index] = true;
                _bulbColor[index].color = Color.green;

                if (index == 3)
                    _toySafe.DoorOpen();
                else
                    index++;

            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    _clear[i] = false;
                }
                index = 0;
                ColorWhite();
            }

            _dial.transform.rotation = Quaternion.Euler(180f, 0f, 180f + _nowAngle);

            _leftMoving = false;
            _rightMoving = false;

        }

    }

    public void ColorWhite()
    {
        _bulbColor[0].color = Color.red;
        _bulbColor[1].color = Color.red;
        _bulbColor[2].color = Color.red;
        _bulbColor[3].color = Color.red;
    }

    void Dial_Fixed(ref float _nowAngle)
    {
        float[] _fixedAngle = new float[12] { 0f, 36f, 72f, 108f, 144f, 180f, 216f, 252f, 288f, 324f, 360f, 360f };

        if (_nowAngle >= 360)
        {
            _nowAngle -= 360;
        }


        int j = 0;

        for (int i = 0; i < 11; i++)
        {
            j++;

            if (_nowAngle >= _fixedAngle[i] && _nowAngle <= _fixedAngle[j])
            {

                float gou = (_fixedAngle[i] + _fixedAngle[j]) / 2;

                if (_nowAngle <= gou)
                {
                    _nowAngle = _fixedAngle[i];
                }
                else
                {
                    _nowAngle = _fixedAngle[j];
                }

            }
        }

    }
}


