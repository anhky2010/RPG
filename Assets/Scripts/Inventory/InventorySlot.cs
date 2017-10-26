
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{

    Item item;
    public Image icon;
    public Button removeButton;


    public void AddItem(Item newitem)
    {
        item = newitem;
        icon.enabled = true;
        icon.sprite = item.icon;
        removeButton.interactable = true;

    }
    public void RemoveSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
