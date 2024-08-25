using Main.SO.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : InteractableBase
{
    [SerializeField] private InventoryItemSO _inventoryItem;

    public override void Interact()
    {
        base.Interact();
        CollectItem();
    }

    private void CollectItem()
    {
        Debug.Log(gameObject.name + " collected!");
        Destroy(gameObject);
    }
}
