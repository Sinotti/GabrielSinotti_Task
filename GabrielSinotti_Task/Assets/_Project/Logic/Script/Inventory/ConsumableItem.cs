using Main.Interactables.Items;
using Main.SO.Items;
using Main.Systems;
using UnityEngine;

public class ConsumableItem : InventoryItem
{
    public override void Interact()
    {
        base.Interact();
    }

    public override void UseInInventory()
    {
        base.UseInInventory();
        Debug.Log("Consumable: " + gameObject.name + " used!");

        if (_inventoryItem is ConsumableItemSO consumable)
        {
            if (consumable.Quantity > 1)
            {
                UpdateQuantity(consumable, -1);
            }
            else
            {
                InventorySystem.Instance.RemoveItem(_inventoryItem);
            }

            InventorySlot slot = FindSlot(); 
            if (slot != null)
            {
                slot.UpdateUI();
            }
        }
    }

    public void UpdateQuantity(ConsumableItemSO consumableItem, int quantity)
    {
        consumableItem.Quantity += quantity;
    }

    private InventorySlot FindSlot()
    {

        InventorySlot[] slots = FindObjectsOfType<InventorySlot>();
        foreach (InventorySlot slot in slots)
        {
            if (slot.Item != null && slot.Item.ItemID == _inventoryItem.ItemID)
            {
                return slot;
            }
        }
        return null;
    }
}
