using Main.Gameplay.Player;
using Main.Systems;
using Main.UI;
using System;
using UnityEngine;

namespace Main.Interactables.Items
{
    public class GhostPotion : ConsumableItem
    {
        [Header("Ghost Potion Parameters")]
        [SerializeField] private float _disabledColliderDuration;
        public override void Interact()
        {
            base.Interact();
        }

        public override void UseInInventory()
        {
            StatusManager.Instance.TemporarilyDisableCollision(_disabledColliderDuration);
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Play);
            base.UseInInventory();
        }
    }
}
