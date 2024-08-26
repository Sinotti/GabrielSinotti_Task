using Main.Gameplay.Player;
using UnityEngine;

namespace Main.Interactables.Items
{
    public class ScalePotion : ConsumableItem
    {
        [Header("Potion Parameters")]
        [Space(6)]
        [SerializeField] public float _scaleModifier;

        public override void Interact()
        {
            base.Interact();
        }

        public override void UseInInventory()
        {
            if (StatusManager.Instance.IsUnderEffect()) return;

            StatusManager.Instance.SetPlayerSize(_scaleModifier);
            base.UseInInventory();            
        }
    }
}
