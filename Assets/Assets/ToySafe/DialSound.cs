using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialSound : MonoBehaviour
{

    AudioSource _dialSound;

    void Start()
    {
        _dialSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dial")
        {
            _dialSound.Play();
        }
    }
}
