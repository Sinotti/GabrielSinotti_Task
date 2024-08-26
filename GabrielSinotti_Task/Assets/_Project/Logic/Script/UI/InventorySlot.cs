using Main.SO.Items;
using Main.Systems;
using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [Header("Slot References")]
    [Space(6)]
    [SerializeField] private TextMeshProUGUI _quantityText;
    [SerializeField] private GameObject _quantityField;

    public InventoryItemSO Item { get; private set; }

    public void UseItem()
    {
        Item.ItemTypeBaseScript.UseInInventory();
    }

    public void SetItem(InventoryItemSO item)
    {
        Item = item;
        UpdateUI();
    }

    public void RemoveItem()
    {
        if (Item != null)
        {
            if (Item is ConsumableItemSO consumable) consumable.Quantity = 1;

            InventorySystem.Instance.RemoveItem(Item);
            Debug.Log($"{Item.name} removed.");
            Item = null;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (Item is ConsumableItemSO consumable)
        {
            _quantityField.SetActive(true);
            _quantityText.text = consumable.Quantity.ToString();
        }
        else
        {
            _quantityText.text = "";
        }
    }
}
