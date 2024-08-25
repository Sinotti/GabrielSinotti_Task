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

    private void Start()
    {
        CanInteract = true;    
    }

    public override void Interact()
    {
        base.Interact();
        if(CanInteract) CollectItem();
    }

    private void CollectItem()
    {
        CanInteract = false;

        InventorySystem.Instance.AddItem(_inventoryItem);
        Debug.Log(gameObject.name + " collected!");
        Destroy(gameObject);
    }
}
