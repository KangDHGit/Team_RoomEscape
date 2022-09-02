using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjClick : MonoBehaviour
{
    public Camera _mainCam; //카메라
    [SerializeField]
    protected Vector3 _camPos; //카메라를 옮길 위치
    public virtual void OnClickObj()
    {
        //Debug.Log("CamMove");
        _mainCam.transform.position = _camPos;
    }
}
