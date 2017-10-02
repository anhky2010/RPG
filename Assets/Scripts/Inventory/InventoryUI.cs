
using UnityEngine;

public class InventoryUI : MonoBehaviour {

 

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject InformationUI;
    Inventory inventory;
    InventorySlot[] slot;

    bool isInitial = false;
	// Use this for initialization
	void Start () {
        
        inventory = Inventory.instance;
        inventory.onItemChangeCallBack += UpdateUI;
        slot = itemsParent.GetComponentsInChildren<InventorySlot>();

      
        
    } 
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
           
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            InformationUI.SetActive(!InformationUI.activeSelf);
           

        }

        if (isInitial == false)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            InformationUI.SetActive(!InformationUI.activeSelf);
            isInitial = true;
        }
    }
    void UpdateUI()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (i < inventory.listItem.Count)
            {
                slot[i].AddItem(inventory.listItem[i]);
            }
            else slot[i].RemoveSlot();
            
        }
         
    }
}
