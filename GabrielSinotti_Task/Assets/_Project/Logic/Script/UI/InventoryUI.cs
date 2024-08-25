using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Main.SO.Items;
using Main.Systems;

namespace Main.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private Transform _slotsParent;
        private List<InventorySlot> _slots = new List<InventorySlot>();

        private void OnEnable()
        {
            InventorySystem.OnAdded += UpdateUI;
            InventorySystem.OnRemoved += UpdateUI;
        }

        private void OnDisable()
        {
            InventorySystem.OnAdded -= UpdateUI;
            InventorySystem.OnRemoved -= UpdateUI;
        }

        private void InitializeSlots(List<InventoryItemSO> items)
        {
            foreach (InventoryItemSO item in items)
            {
                AddSlot(item);
            }
        }

        private void UpdateUI(InventoryItemSO item)
        {

            ClearSlots();

            InitializeSlots(InventorySystem.Instance.GetAllItems());
        }

        private void AddSlot(InventoryItemSO item)
        {
            GameObject newSlot = Instantiate(_slotPrefab, _slotsParent);
            InventorySlot slotComponent = newSlot.GetComponent<InventorySlot>();

            if (slotComponent != null)
            {
                slotComponent.SetItem(item);
            }

            Image slotImage = newSlot.GetComponent<Image>();
            if (slotImage != null && item != null)
            {
                slotImage.sprite = item.ItemImage;
            }

            _slots.Add(slotComponent);
        }

        private void ClearSlots()
        {
            foreach (InventorySlot slot in _slots)
            {
                if (slot != null)
                {
                    Destroy(slot.gameObject);
                }
            }
            _slots.Clear();
        }
    }
}
