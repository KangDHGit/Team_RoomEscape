using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory I;
        public List<string> _itemList;

        private void Awake()
        {
            I = this;
        }

        public void AddItem(string itemname)
        {
            _itemList.Add(itemname);
            Debug.Log("Inventory Add Success");
        }
    }
}
