using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class CatDoll : MonoBehaviour
    {
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
