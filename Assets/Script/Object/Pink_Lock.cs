using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Pink_Lock : MonoBehaviour
    {
        [SerializeField] Toy_Chest _toy_Chest;
        private void Start()
        {
            if (!transform.parent.TryGetComponent(out _toy_Chest))
                Debug.LogError("_toy_Chest is Null");
        }
        private void OnMouseUp()
        {
            if(true && _toy_Chest._objZCam.activeSelf)
            {
                _toy_Chest.IsOpened();
                gameObject.SetActive(false);
            }
        }
    }
}
