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

    [SerializeField] GameObject currentEquipmentParent;
    InventorySlot[] currentEquipmentSlots;
    Equipment[] currentEquipment;
    [SerializeField] Transform RightHand;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] Equipment beginWeapon;
    //public SkinnedMeshRenderer playerMesh;
    //SkinnedMeshRenderer[] currentMeshes;
    private void Start()
    {

        int numslot = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[numslot];
        currentEquipmentSlots = currentEquipmentParent.GetComponentsInChildren<InventorySlot>();
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
        WeaponChangeAppreance(newEquipment);
        ShowCurrentEquipments();


    }
    private void WeaponChangeAppreance(Equipment _newItem)
    {
        if (_newItem.equipmentType == EquipmentType.Weapon)
        {
            MeshFilter newmeshFilter = _newItem.gameObject.GetComponent<MeshFilter>();
            MeshRenderer newmeshRenderer = _newItem.gameObject.GetComponent<MeshRenderer>();

            MeshFilter oldmeshFilter = currentWeapon.GetComponent<MeshFilter>();
            MeshRenderer oldmeshRenderer = currentWeapon.GetComponent<MeshRenderer>();
            oldmeshFilter.sharedMesh = newmeshFilter.sharedMesh;
            oldmeshRenderer.sharedMaterials = newmeshRenderer.sharedMaterials;

            currentWeapon.transform.localPosition = _newItem.gameObject.transform.position;
            currentWeapon.transform.localRotation = _newItem.gameObject.transform.rotation;
            currentWeapon.transform.localScale = _newItem.gameObject.transform.localScale;
        }
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
            ShowCurrentEquipments();
            return oldItem;
        }
        // WeaponChangeAppreance(beginWeapon);
        ShowCurrentEquipments();
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
        ShowCurrentEquipments();

        WeaponChangeAppreance(beginWeapon);

        //EquipDefaultItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            UnequipAll();
        }
    }

    private void ShowCurrentEquipments()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            if (currentEquipment[i] != null)
            {
                currentEquipmentSlots[i].AddItem(currentEquipment[i]);
            }
            else currentEquipmentSlots[i].RemoveSlot();

        }
    }


}
