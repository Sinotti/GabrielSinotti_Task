using Main.SO.Items;
using Main.Systems;
using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quantityText;
    public InventoryItemSO Item { get; private set; }

    public void UseItem()
    {
        Item.ItemTypeBaseScript.UseInInventory();   
    }

    public void SetItem(InventoryItemSO item)
    {
        Item = item;
    }


    public void RemoveItem()
    {
        if (Item != null)
        {
            InventorySystem.Instance.RemoveItem(Item);
            Debug.Log($"{Item.name} removed.");

            Item = null;
        }
    }

    public void UpdateUI()
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