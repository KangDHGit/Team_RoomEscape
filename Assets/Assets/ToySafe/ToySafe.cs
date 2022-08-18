using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToySafe : MonoBehaviour
{

    public GameObject _doorClosed;
    public GameObject _doorOpen;

    // Update is called once per frame
    void Update()
    {
        _doorClosed = transform.Find("DoorClosed").gameObject;
        _doorOpen = transform.Find("DoorOpen").gameObject;

    }

    public void DoorOpen()
    {
        _doorClosed.SetActive(false);
        _doorOpen.SetActive(true);
    }

}