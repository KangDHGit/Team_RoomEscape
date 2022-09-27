using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RoomEscape
{
    public class UI_Inventory : MonoBehaviour
    {
        public static UI_Inventory I;
        public GameObject _itemTemplate;
        public Sprite _testsp;

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
            clone.transform.parent = _itemTemplate.transform;
            clone.SetActive(true);

            UI_InvenItem ivenItem = clone.GetComponent<UI_InvenItem>();
            ivenItem.Info(itemName);

        }


    }
}
