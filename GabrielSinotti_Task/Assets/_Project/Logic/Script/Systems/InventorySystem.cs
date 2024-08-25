using Main.SO.Items;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance { get; private set; }

    [SerializeField] private List<InventoryItemSO> _inventoryItems;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _inventoryItems = new List<InventoryItemSO>();
    }

    public void AddItem(InventoryItemSO item)
    {
        if (item != null)
        {
            _inventoryItems.Add(item);
            Debug.Log(item.name + " added to inventory.");
        }
    }

    public bool HasSpecificItem(InventoryItemSO item)
    {
        return _inventoryItems.Contains(item);
    }

    public void RemoveItem(InventoryItemSO item)
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
            Debug.Log(item.name + " removed from inventory.");
        }
    }

    public List<InventoryItemSO> GetAllItems()
    {
        return new List<InventoryItemSO>(_inventoryItems);
    }
}
