using UnityEngine;

namespace Main.SO.Items
{
    [CreateAssetMenu(menuName = "SO/Interactable/Inventory Item/Readable Item", fileName = "New Readable Item")]
    public class ReadableItemSO : InventoryItemSO
    {
        [Header("Readable Item")]
        [Space(6)]

        [TextArea(5, 10)]
        [SerializeField] private string _readableText;

        public string ReadableText { get => _readableText; set => _readableText = value; }
    }
}

