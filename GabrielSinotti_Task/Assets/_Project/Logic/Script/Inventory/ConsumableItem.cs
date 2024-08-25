using Main.Interactables.Items;
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
    }
}
