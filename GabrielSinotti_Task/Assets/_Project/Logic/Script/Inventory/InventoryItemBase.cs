using Main.SO.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItemBase : InteractableBase
{
    [Header("References")]
    [Space(6)]
    [SerializeField] private InventoryItemSO _inventoryItem;

    public override void Interact()
    {
        base.Interact();
        CollectItem();
    }

    private void CollectItem()
    {
        InventorySystem.Instance.AddItem(_inventoryItem);
        Debug.Log(gameObject.name + " collected!");
        Destroy(gameObject);
    }
}
