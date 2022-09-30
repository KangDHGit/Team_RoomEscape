using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RoomEscape
{
    public class UI_InvenItem : MonoBehaviour
    {
        public Text _txt_ItemName;
        public Text _txt_Count;
        int _itemcount;
        public GameObject _imgItemsel;
        Image _imgItem;
        Sprite _testsp;
        Vector3 _vecImgOrigin;

        private void Start()
        {
            _imgItemsel = transform.Find("Img_sel").gameObject;
            _imgItemsel.SetActive(false);
        }

        public void Info(string itemName)
        {

            Sprite[] spList = Resources.LoadAll<Sprite>("Item_Img");
            for (int i = 0; i < spList.Length; i++)
            {
                Sprite sp = spList[i];
                if (sp.name == itemName)
                {
                    _testsp = sp;
                    break;
                }

            }

            _txt_ItemName = transform.Find("Txt_Name").GetComponent<Text>();
            _txt_ItemName.text = itemName;

            _imgItem = transform.Find("Img_Item").GetComponent<Image>();
            _imgItem.sprite = _testsp;

            //_itemcount = count;
            //_txt_Count.text = _itemcount.ToString();

        }
        public void ItemCount(int count)
        {
            _itemcount += count;
            _txt_Count.text = _itemcount.ToString();
        }


    }
}
