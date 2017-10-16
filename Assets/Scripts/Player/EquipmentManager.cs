using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance; //singleton
    public void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public delegate void OnEquipmentChanged(Equipment oldItem, Equipment newItem);
    public OnEquipmentChanged onEquipmentChanged;

    Equipment[] currentEquipment;
    // public Equipment[] defaultEquipmentItems;
    //public SkinnedMeshRenderer playerMesh;
    //SkinnedMeshRenderer[] currentMeshes;
    private void Start()
    {
        int numslot = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[numslot];
        //  currentMeshes = new SkinnedMeshRenderer[numslot];
        //EquipDefaultItems();
    }

    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipmentType;
        Unequip(slotIndex);
        Equipment oldItem = Unequip(slotIndex);
        //SetEquipmentShapes(newEquipment, 100);
        currentEquipment[slotIndex] = newEquipment;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(oldItem, newEquipment);
        }
        //SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
        //newMesh.transform.parent = playerMesh.transform;
        //newMesh.bones = playerMesh.bones;
        //newMesh.rootBone = playerMesh.rootBone;
        //currentMeshes[slotIndex] = newMesh;

    }

    //void EquipDefaultItems()
    //{
    //    foreach (var item in defaultEquipmentItems)
    //    {
    //        Equip(item);
    //    }
    //}

    public Equipment Unequip(int slotIndex)
    {
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            //if (currentMeshes != null)
            //{
            //    Destroy(currentMeshes[slotIndex].gameObject);
            //}
            oldItem = currentEquipment[slotIndex];
            Inventory.instance.Add(oldItem);
            currentEquipment[slotIndex] = null;

            // SetEquipmentShapes(oldItem, 0);
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(oldItem, null);
            }
            return oldItem;
        }
        return null;

    }


    //scale body vs trang bi
    //public void SetEquipmentShapes(Equipment item, int index)
    //{
    //    foreach (EquipmentMeshType equipmentMesh in item.equipmentMeshType)
    //    {
    //        playerMesh.SetBlendShapeWeight((int)equipmentMesh, index);
    //    }
    //}
    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        //EquipDefaultItems();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            UnequipAll();
        }
    }



}
