using Main.Gameplay.Player;
using Main.Systems;
using Main.UI;

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
            if (!StatusManager.Instance.IsUnderEffect()) return;
            StatusManager.Instance.ResetScale();

            base.UseInInventory();
        }
    }
}
