using UnityEngine;
using Main.SO.Items;
using Main.Systems;

namespace Main.UI
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private InventoryItemSO _currentItem;

        public void RemoveItem()
        {
            if (_currentItem != null)
            {
                InventorySystem.Instance.RemoveItem(_currentItem);
                Debug.Log($"{_currentItem.name} removed.");

                _currentItem = null;
            }
        }

        public void SetItem(InventoryItemSO item)
        {
            _currentItem = item;
        }
    }
}