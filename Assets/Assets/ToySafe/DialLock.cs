using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialLock : MonoBehaviour
{
    public static DialLock I; //싱글턴
    GameObject _obj_Cam_DialSafeToy;

    GameObject _dial;

    public float[] _password = new float[] { 36, 72, 108, 144 };//비밀번호 숫자
    public bool[] _password_bool = new bool[] { true, false, true, false };//비밀번호 좌우판정
    int index = 0;
    bool[] _clear = new bool[] { false, false, false, false };//성공판정

    float _nowAngle = 0;//마우스 각도
    float _setAngle = 0;//설정 각도

    public Material[] _bulbColor;//전구 머티리얼
    [SerializeField] Renderer[] _bulb;//전구

    private float speed = 10f;

    public bool _leftMoving = false;
    public bool _rightMoving = false;

    public bool _onDial = false;

    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _leftMoving = false;
        _rightMoving = false;

        _dial = transform.Find("Cube.003/Dial").gameObject;

        _bulbColor = Resources.LoadAll<Material>("Materials/LightColor");

        _bulb = new Renderer[4];

        _bulb[0] = transform.Find("Bulb/Bulb_1").GetComponent<Renderer>();
        _bulb[1] = transform.Find("Bulb/Bulb_2").GetComponent<Renderer>();
        _bulb[2] = transform.Find("Bulb/Bulb_3").GetComponent<Renderer>();
        _bulb[3] = transform.Find("Bulb/Bulb_4").GetComponent<Renderer>();



        ColorSeting();
    }



    // Update is called once per frame
    void Update()
    {
        //if (_onDial == true)//다이얼 움직임을 막음
        {
            if (Input.GetMouseButton(0))//마우스 클릭중 다이얼 각도 변환
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
            if (Input.GetMouseButtonUp(0))//마우스 땠을시
            {
                _nowAngle = _dial.transform.eulerAngles.z;

                _setAngle = Dial_Fixed(_nowAngle);//다이얼 각도를 설정값으로 변환
                Debug.Log($"_nowAngle : {_nowAngle}");
                Debug.Log($"_setAngle : {_setAngle}");


                _dial.transform.rotation = Quaternion.Euler(180f, 0f, 180f + _setAngle);

                //비밀번호와 대조후 정답 판정
                if (_setAngle == _password[index] && _rightMoving == _password_bool[index])
                {
                    _clear[index] = true;
                    _bulb[index].sharedMaterial = _bulbColor[0];

                    if (index == 3)
                        ToySafe.I.DoorOpen();
                    else
                        index++;

                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        _clear[i] = false;
                    }

                    //틀렸을시 각도 초기화
                    _dial.transform.rotation = Quaternion.Euler(180f, 0f, 180f);

                    index = 0;
                    ColorSeting();
                }



                _leftMoving = false;
                _rightMoving = false;

            }
        }
    }

    void ColorSeting()
    {
        _bulb[0].sharedMaterial = _bulbColor[1];
        _bulb[1].sharedMaterial = _bulbColor[1];
        _bulb[2].sharedMaterial = _bulbColor[1];
        _bulb[3].sharedMaterial = _bulbColor[1];
    }

    float Dial_Fixed(float _nowAngle)//다이얼각도를 설정값으로 변환
    {
        //다이얼 번호 고정
        float[] _fixedAngle = new float[12] { 0f, 36f, 72f, 108f, 144f, 180f, 216f, 252f, 288f, 324f, 360f, 360f };

        if (_nowAngle >= 360)
        {
            _nowAngle -= 360;
        }


        //마우스 땠을시 각도를 고정값과 대조후 더 가까운 값으로 변환
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

        return _nowAngle;
    }
}


