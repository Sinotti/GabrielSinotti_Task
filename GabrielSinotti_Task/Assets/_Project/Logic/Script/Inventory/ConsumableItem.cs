using Main.Interactables.Items;
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

        InventorySystem.Instance.RemoveItem(_inventoryItem);
    }
}
