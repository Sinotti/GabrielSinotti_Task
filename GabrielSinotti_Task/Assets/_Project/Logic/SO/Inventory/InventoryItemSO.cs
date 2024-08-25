using UnityEngine;

namespace Main.SO.Items
{
    [CreateAssetMenu(menuName = "SO/Interactable/Inventory Item", fileName = "New Inventory Item")]
    public class InventoryItemSO : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _itemImage;
    }
}

