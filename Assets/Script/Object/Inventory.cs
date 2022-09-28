using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{

    public class ItemInfo
    {
        [SerializeField] string _names;
        [SerializeField] int    _count;
    }
    public class Inventory : MonoBehaviour
    {
        public static Inventory I;
        public List<string>     _itemList;

        private void Awake()
        {
            I = this;
        }

        public void AddItem(string itemName)
        {
            if (_itemList.Contains(itemName) == false)
            {
                _itemList.     Add(itemName);
                UI_Inventory.I.Add(itemName);
            }
            
            //Debug.Log("Inventory Add Success");
        }
    }
}
