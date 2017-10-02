using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;
    public int space = 20;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Inventory!");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> listItem = new List<Item>();

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallBack;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (listItem.Count >= space)
            {
                Debug.Log("Inventory is full!");
                return false;
            }
            listItem.Add(item);
            if (onItemChangeCallBack != null)
            {
                onItemChangeCallBack.Invoke();
            }
        }
        return true;

    }
    public void Remove(Item item)
    {
        listItem.Remove(item);
        if (onItemChangeCallBack != null)
        {
            onItemChangeCallBack.Invoke();
        } 
    }
}
