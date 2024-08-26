using Main.Interactables.Items;
using Main.SO.Items;
using Main.Systems;
using UnityEngine;
using static UnityEditor.Progress;

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

        if(_inventoryItem is ConsumableItemSO consumable)
        {
            if(consumable.Quantity > 1)
            {
                UpdateQuantity(consumable, -1);
            }

            else
            {
                InventorySystem.Instance.RemoveItem(_inventoryItem);
            }
        }
    }

    public void UpdateQuantity(ConsumableItemSO consumableItem, int quantity)
    {
        consumableItem.Quantity += quantity;
    }
}
