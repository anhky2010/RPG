 
using UnityEngine;

public class ItemPickup : Intertactable {

    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        
        Debug.Log("Player picked up item " + item.name);
        if (Inventory.instance.Add(item))
        {
            Destroy(this.gameObject);
        }  
        
    }
}
