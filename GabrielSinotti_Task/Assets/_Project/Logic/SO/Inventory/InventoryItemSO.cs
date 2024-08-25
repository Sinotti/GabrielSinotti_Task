using Main.Interactables.Items;
using UnityEngine;

namespace Main.SO.Items
{
    [CreateAssetMenu(menuName = "SO/Interactable/Inventory Item", fileName = "New Inventory Item")]
    public class InventoryItemSO : ScriptableObject
    {
        [Header("inventory Item Inheritance")]
        [Space(6)]

        [SerializeField] private int _itemID;
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _itemImage;
        [SerializeField] private InventoryItem _itemTypeBaseScript;
        public int ItemID { get => _itemID; set => _itemID = value; }
        public string ItemName { get => _itemName; set => _itemName = value; }
        public Sprite ItemImage { get => _itemImage; set => _itemImage = value; }
        public InventoryItem ItemTypeBaseScript { get => _itemTypeBaseScript; set => _itemTypeBaseScript = value; }
    }
}

