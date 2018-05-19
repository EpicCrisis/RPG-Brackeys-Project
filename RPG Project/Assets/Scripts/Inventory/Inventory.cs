using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instances found!");
            return;
        }
        Instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item _item)
    {
        if (!_item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space!");
                return false;
            }

            items.Add(_item);

            if (OnItemChangedCallBack != null)
            {
                OnItemChangedCallBack.Invoke();
            }
        }

        return true;
    }

    public void Remove(Item _item)
    {
        items.Remove(_item);

        if (OnItemChangedCallBack != null)
        {
            OnItemChangedCallBack.Invoke();
        }
    }
}
