using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int Damage = 0;
    public int Defence = 0;
    public virtual void Use()
    {
        Debug.Log("Using item: " + this.name); 
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
