using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Pink_Lock : MonoBehaviour
    {
        [SerializeField] Toy_Chest _toy_Chest;
        Collider _col;
        string _keyName = "분홍열쇠";

        private void Start()
        {
            if (!transform.parent.TryGetComponent(out _toy_Chest))
                Debug.LogError("_toy_Chest is Null");
            if (TryGetComponent(out _col))
                _col.enabled = false;
            else
                Debug.LogError("Pink_Lock Collider is Null");

        }
        private void OnMouseUp()
        {
            if (UI_Inventory.I._selItem == null)
            {
                return;
            }
            else if (UI_Inventory.I._selItem._txt_ItemName.text == _keyName && _toy_Chest._objZCam.activeSelf)
            {
                _toy_Chest.IsOpened();
                gameObject.SetActive(false);
                UI_Inventory.I.DeleteItem();
            }
        }
        public void SetCol(bool stat)
        {
            if (gameObject.activeSelf)
                _col.enabled = stat;
        }
    }
}
