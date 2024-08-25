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

        public static event Action<InventoryItemSO> OnAdded;
        public static event Action<InventoryItemSO> OnRemoved;

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
                OnAdded?.Invoke(item);
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
                OnRemoved?.Invoke(item);
            }
        }

        public List<InventoryItemSO> GetAllItems()
        {
            return new List<InventoryItemSO>(_inventoryItems);
        }
    }

}