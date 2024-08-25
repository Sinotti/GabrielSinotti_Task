using Main.Interactables.Items;
using Main.SO.Items;
using Main.UI;
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

        ReadableItemSO readableItem = _inventoryItem as ReadableItemSO;

        ReadableFieldManager.Instance.SetTextInReadableField(readableItem.ReadableText);
    }
}

