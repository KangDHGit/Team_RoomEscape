using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToySafe : MonoBehaviour
{

    public GameObject _doorClosed;
    public GameObject _doorOpen;

    private void Start()
    {
        _doorClosed = transform.Find("DoorClosed").gameObject;
        _doorOpen = transform.Find("DoorOpen").gameObject;

        _doorClosed.SetActive(true);
        _doorOpen.SetActive(false);
    }

    public void DoorOpen()
    {
        _doorClosed.SetActive(false);
        _doorOpen.SetActive(true);
    }

}