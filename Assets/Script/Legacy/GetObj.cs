using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObj : MonoBehaviour
{
    public Camera _mainCam;
    private RaycastHit _hit; // 클릭한 물체를 담을 변수
    void Update()
    {
        GetObject();
    }
    void GetObject()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out _hit))
            { // 마우스 클릭 위치에 레이를쏴서 뭔가에 걸리면 _hit에 정보를 넣음
                string objname = _hit.collider.gameObject.name;
                Debug.Log(objname);
                _hit.collider.GetComponent<ObjClick>().OnClickObj();
            }

        }
    }
}
