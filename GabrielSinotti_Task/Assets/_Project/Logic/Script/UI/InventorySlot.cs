using Main.SO.Items;
using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quantityText;
    public InventoryItemSO Item { get; private set; }

    public void UseItem()
    {
        UpdateQuantity(-1);
    }

    public void SetItem(InventoryItemSO item)
    {
        Item = item;
        UpdateUI();
    }

    public void UpdateQuantity(int quantity)
    {
        if (Item is ConsumableItemSO consumable)
        {
            consumable.Quantity += quantity;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (Item is ConsumableItemSO consumable)
        {
            quantityText.text = consumable.Quantity.ToString();
        }
        else
        {
            quantityText.text = "";
        }
    }
}