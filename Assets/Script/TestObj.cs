using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public enum TYPE
    {
        DEFAULT,
        PARENT,
        MIDDLE,
        CHILD
    }
    public class TestObj : MonoBehaviour
    {
        [SerializeField] protected Room _room; 
        TYPE _type; public TYPE _Type { get { return _type; } }
        public GameObject _objZCam; 
        [SerializeField] Collider _col;
        public List<TestObj> _list_ChildObj;
        public TestObj _parentObj;
        public List<RoomItem> _list_Item;

        public virtual void Init()
        {
            if (_room != Room.None)
            {
                _objZCam = CameraManager.I.transform.Find($"{_room}/Cam_{gameObject.name}").gameObject;
                if (_objZCam != null)
                    _objZCam.SetActive(false);
                _list_ChildObj = new List<TestObj>(transform.GetComponentsInDirectChild<TestObj>());
                if (transform.parent.TryGetComponent(out _parentObj))
                {
                    if (_list_ChildObj == null)
                    {
                        _type = TYPE.CHILD;
                        SetCol(false);
                    }
                    else
                    {
                        _type = TYPE.MIDDLE;
                        SetCol(false);
                    }
                }
                else if (_list_ChildObj != null)
                {
                    _type = TYPE.PARENT;
                    SetCol(true);
                }
                else if (_list_ChildObj == null)
                {
                    _type = TYPE.DEFAULT;
                    SetCol(true);
                }

                _list_Item = new List<RoomItem>(transform.GetComponentsInDirectChild<RoomItem>());
                ListSetCol(_list_Item, false);
                List_ItemInit();
            }
        }

        public virtual bool OnClick_BackBtn()
        {
            switch (_type)
            {
                case TYPE.DEFAULT:
                    if (_objZCam != null && _objZCam.activeSelf)
                    {
                        OnClick(false);
                    }
                    return false;
                case TYPE.PARENT:
                    if (CheckOnChildCam())
                    {
                        foreach (TestObj obj in _list_ChildObj)
                        {
                            obj.OnClick_BackBtn();
                        }
                        return true;
                    }
                    else
                    {
                        OnClick(false);
                        ListSetCol(_list_ChildObj, false);
                        return false;
                    }
                case TYPE.MIDDLE:
                    if (CheckOnChildCam())
                    {
                        foreach (TestObj obj in _list_ChildObj)
                        {
                            obj.OnClick_BackBtn();
                        }
                        return true;
                    }
                    else
                    {
                        OnClick(false);
                        ListSetCol(_list_ChildObj, false);
                        return false;
                    }
                case TYPE.CHILD:
                    return false;
                default:
                    return false;
            }
        }

        protected virtual void OnClick(bool stat) // true : MouseDown, false : BackBtn
        {
            if (_objZCam != null)
                _objZCam.SetActive(stat);
            SetCol(!stat);
            if(_list_ChildObj != null)
                ListSetCol(_list_ChildObj, true);
            switch (_type)
            {
                case TYPE.DEFAULT:
                case TYPE.PARENT:
                    CameraManager.I._isZoom = stat;
                    break;
                case TYPE.MIDDLE:
                    CameraManager.I._isZoom_Middle = stat;
                    break;
                case TYPE.CHILD:
                    CameraManager.I._isZoom_Child = stat;
                    break;
                default:
                    break;
            }
            ListSetCol(_list_Item, stat);
        }

        public void ListSetCol<T>(List<T> list, bool stat) where T : MonoBehaviour
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.TryGetComponent(out Collider col))
                        col.enabled = stat;
                }
            }
        }

        public void List_ItemInit()
        {
            if (_list_Item != null)
            {
                foreach (RoomItem item in _list_Item)
                {
                    item.Init();
                }
            }
        }
        public void SetCol(bool stat)
        {
            if (_col == null)
                _col = GetComponent<Collider>();
            if (_col != null)
                _col.enabled = stat;
        }

        bool CheckOnChildCam()
        {
            if (_list_ChildObj == null)
                return false;
            foreach (TestObj roomObj in _list_ChildObj)
            {
                if (roomObj._objZCam != null)
                {
                    if (roomObj._objZCam.activeSelf)
                        return true;
                    else if (!roomObj._objZCam.activeSelf)
                    {
                        continue;
                    }
                }
            }
            return false;
        }
    }
}
