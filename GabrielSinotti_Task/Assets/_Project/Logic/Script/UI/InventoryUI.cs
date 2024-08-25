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
        private List<Image> _slotImages = new List<Image>();

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
            if (InventorySystem.Instance.HasSpecificItem(item)) AddSlot(item);
            else RemoveSlot(item);
        }

        private void AddSlot(InventoryItemSO item)
        {
            GameObject newSlot = Instantiate(_slotPrefab, _slotsParent);
            Image slotImage = newSlot.GetComponent<Image>();

            if (item != null)
            {
                slotImage.sprite = item.ItemImage;
            }

            _slotImages.Add(slotImage);
        }

        private void RemoveSlot(InventoryItemSO item)
        {
            for (int i = 0; i < _slotImages.Count; i++)
            {
                if (_slotImages[i].sprite == item.ItemImage)
                {
                    Destroy(_slotImages[i].gameObject);
                    _slotImages.RemoveAt(i);
                    break;
                }
            }
        }
    }
}

