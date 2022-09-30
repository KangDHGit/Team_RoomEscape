using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RoomEscape
{
    public class UI_Inventory : MonoBehaviour
    {
        public static UI_Inventory I;

        public UI_InvenItem _selItem;

        public GameObject _itemTemplate;

        void Awake()
        {
            I = this;

            _itemTemplate = transform.Find("UI_InvenItem").gameObject;
            _itemTemplate.SetActive(false);

        }
        public void Init()
        {

            for (int i = 0; i < Inventory.I._itemList.Count; i++)
            {
                string itemName = Inventory.I._itemList[i];

                Add(itemName);
            }

            this.gameObject.SetActive(false);
        }

        public void Add(string itemName)
        {

            GameObject clone = Instantiate(_itemTemplate);
            clone.transform.parent = _itemTemplate.transform.parent;
            clone.SetActive(true);

            UI_InvenItem ivenItem = clone.GetComponent<UI_InvenItem>();
            ivenItem.Info(itemName);


        }

        public void SelectItem(UI_InvenItem item)
        {
            if (_selItem != null)
            {
                _selItem._imgItemsel.SetActive(false);
            }

            _selItem = item;
            _selItem._imgItemsel.SetActive(true);
            Debug.Log("나는 누구인가 ? : " + _selItem._txt_ItemName.text);

        }

        public void CloseSel()
        {
            if (_selItem == null)
            {
                return;
            }
            _selItem._imgItemsel.SetActive(false);
            _selItem = null;

        }

        public void DeleteItem()
        {

            for (int i = 0; i < Inventory.I._itemList.Count; i++)
            {
                if (Inventory.I._itemList[i] == _selItem._txt_ItemName.text)
                {
                    Inventory.I._itemList.RemoveAt(i);
                    break;
                }
            }

            Destroy(_selItem.gameObject);

        }

    }
}
