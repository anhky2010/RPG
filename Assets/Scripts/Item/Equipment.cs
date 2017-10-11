using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentType equipmentType;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshType[] equipmentMeshType;
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }


}
public enum EquipmentType { Head, Chest, Legs, Weapon, Shield };
public enum EquipmentMeshType { Head, Armor, Legs };