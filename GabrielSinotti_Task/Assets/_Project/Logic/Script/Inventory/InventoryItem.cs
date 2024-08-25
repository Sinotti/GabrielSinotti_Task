using Main.Interface;
using Main.SO.Items;
using Main.Systems;
using UnityEngine;

namespace Main.Interactables.Items
{
    public class InventoryItem : InteractableBase, IInventoryUsable
    {
        [Header("References")]
        [Space(6)]
        [SerializeField] private InventoryItemSO _inventoryItem;

        private bool InventoryFull => InventorySystem.Instance.InventoryFull;

        private void Start()
        {
            CanInteract = true;
        }

        public override void Interact()
        {
            base.Interact();
            if (CanInteract) CollectItem();
        }
        
        public virtual void UseInInventory() { }

        private void CollectItem()
        {
            if (!InventoryFull)
            {
                CanInteract = false;

                InventorySystem.Instance.AddItem(_inventoryItem);
                Debug.Log(gameObject.name + " collected!");
                Destroy(gameObject);
            }
        }
    }
}
