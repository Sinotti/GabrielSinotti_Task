using Main.SO.Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Systems
{
    public class InventorySystem : MonoBehaviour
    {
        public static InventorySystem Instance { get; private set; }

        [SerializeField] private List<InventoryItemSO> _inventoryItems;
        [SerializeField] private int inventoryLimit = 10;

        [SerializeField] private bool _inventoryFull;

        public static event Action<InventoryItemSO> OnAdded;
        public static event Action<InventoryItemSO> OnRemoved;

        public bool InventoryFull { get => _inventoryFull; set => _inventoryFull = value; }

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
            if (item == null) return;

            if (item is ConsumableItemSO consumable)
            {
                ConsumableItemSO existingItem = _inventoryItems.Find(i => i is ConsumableItemSO && i.ItemID == item.ItemID) as ConsumableItemSO;

                if (existingItem != null)
                {
                    existingItem.Quantity += 1;
                    OnAdded?.Invoke(existingItem);
                    return;
                }
            }

            if (_inventoryItems.Count < inventoryLimit)
            {
                _inventoryItems.Add(item);
                Debug.Log(item.name + " added to inventory.");
                OnAdded?.Invoke(item);
            }
            else
            {
                Debug.Log("Inventory is full! Cannot add more items.");
            }

            _inventoryFull = _inventoryItems.Count >= inventoryLimit;
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
                OnRemoved?.Invoke(item);
            }
        }

        public List<InventoryItemSO> GetAllItems()
        {
            return new List<InventoryItemSO>(_inventoryItems);
        }
    }
}
