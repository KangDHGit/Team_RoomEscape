using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Door : MonoBehaviour
    {
        // ���� ����� ���
        public Room _roomA;
        public Room _roomB;
        // ��������
        public bool _isOpen;

        private void OnMouseDown()
        {
            if(_isOpen)
            {
                if(CameraManager.CamMgr._room_Now == _roomA)
                {
                    CameraManager.CamMgr.SetMCam(_roomB);
                }
                else if(CameraManager.CamMgr._room_Now == _roomB)
                {
                    CameraManager.CamMgr.SetMCam(_roomA);
                }
                Debug.Log("���� �������� �̵�����");
            }
            else
                Debug.Log("�� ���");
        }
    }
}
