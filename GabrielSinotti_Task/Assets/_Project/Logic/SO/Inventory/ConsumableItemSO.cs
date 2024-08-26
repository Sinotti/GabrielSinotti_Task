using UnityEngine;

namespace Main.SO.Items
{
    [CreateAssetMenu(menuName = "SO/Interactable/Inventory Item/Consumable Item", fileName = "New Consumable Item")]
    public class ConsumableItemSO : InventoryItemSO
    {
        [Header("Consumable Item")]
        [Space(6)]
        [SerializeField] private int _quantity = 1;

        public int Quantity { get => _quantity; set => _quantity = value; }

        private void OnEnable()
        {
            _quantity = 1;
        }   
    }
}

