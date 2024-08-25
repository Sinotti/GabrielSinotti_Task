using Main.Interactables.Items;
using UnityEngine;

public class ReadableItem : InventoryItem
{
    public override void Interact()
    {
        base.Interact();
    }

    public override void UseInInventory()
    {
        base.UseInInventory();
        Debug.Log("Readable: " + gameObject.name + " used!");
    }
}

