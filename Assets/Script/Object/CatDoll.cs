using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class CatDoll : MonoBehaviour
    {
        AudioSource _AS_Meow;

        Vector3 _originPos;
        Vector3 _jumpPos = new Vector3(0, 0.2f, 0);
        Coroutine _coroutine;
        bool _isCoroutineing = false;
        private void OnMouseUp()
        {
            if (_isCoroutineing == false)
            {
                _coroutine = StartCoroutine(CatJump());
            }
        }

        IEnumerator CatJump()
        {
            _isCoroutineing = true;
            _originPos = transform.position;
            if (_AS_Meow == null)
                _AS_Meow = GetComponent<AudioSource>();
            _AS_Meow.Play();

            while (transform.position.y < _jumpPos.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, _jumpPos, 0.5f * Time.deltaTime);
                yield return null;
            }
            while (transform.position.y > _originPos.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, _originPos, 0.5f * Time.deltaTime);
                yield return null;
            }
            _isCoroutineing = false;
            yield return null;
        }
    }
}
