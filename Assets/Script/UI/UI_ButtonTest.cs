using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class UI_ButtonTest : MonoBehaviour
    {
        public static UI_ButtonTest I;
        public UI_InvenItem _selected_Item; // 선택한 아이템
        private void Awake()
        {
            I = this;
        }
        public void ItemSelect(UI_InvenItem item)
        {
            if(_selected_Item != null)
            {
                // 전에 선택한 아이템 선택효과 비활성화 코드
            }
            _selected_Item = item; //선택한 아이템 넣어주기

            // 선택한 아이템 선택효과 활성화 시켜주기 코드
        }

        // 아이템 사용시 삭제시켜줄 함수
        public void DeleteItem()
        {
            _selected_Item = null; // 선택한 아이템 비워주기
            // Inventory 에서도 지워주기
            Destroy(_selected_Item.gameObject); //아이템 삭제
        }

        // 추가로 필요한 기능
        // 인벤토리 닫는버튼 누를때 선택한 아이템 효과 비활성화 코드, 선택한 아이템 빼주기
    }
}
