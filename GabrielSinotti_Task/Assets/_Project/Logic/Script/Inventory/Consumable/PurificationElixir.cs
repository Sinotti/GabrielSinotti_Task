using Main.Gameplay.Player;
using UnityEngine;

namespace Main.Interactables.Items
{
    public class PurificationElixir : ConsumableItem
    {
        public override void Interact()
        {
            base.Interact();
        }

        public override void UseInInventory()
        {
            StatusManager.Instance.ResetScale();
            base.UseInInventory();
        }
    }
}
