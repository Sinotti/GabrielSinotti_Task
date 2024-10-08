using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Main.SO.Input
{
    [CreateAssetMenu(menuName = "SO/Input/Input Reader UI", fileName = "New Input Reader UI")]
    public class InputReaderUI : ScriptableObject
    { 
        [SerializeField] private InputActionAsset _asset;
        
        public UnityAction ConfirmEvent;
        public UnityAction BackEvent;
        public UnityAction PauseEvent;
        public UnityAction InventoryEvent;

        private InputAction _confirm;
        private InputAction _back;
        private InputAction _pause;
        private InputAction _inventory;
        public enum UIInputType
        {
            Confirm,
            Back,
            Pause,
            Inventory,
            All
        }

        private void OnEnable()
        {
            _confirm = _asset.FindAction("Confirm");
            _back = _asset.FindAction("Back");
            _pause = _asset.FindAction("Pause");
            _inventory = _asset.FindAction("Inventory");

            _confirm.started += OnConfirm;
            _back.started += OnBack;
            _pause.started += OnPause;
            _inventory.started += OnInventory;

            _confirm.Enable();
            _back.Enable();
            _pause.Enable();
            _inventory.Enable();
        }

        private void OnDisable()
        {
            _confirm.started -= OnConfirm;
            _back.started -= OnBack;
            _pause.started -= OnPause;
            _inventory.started -= OnInventory;

            _confirm.Disable();
            _back.Disable();
            _pause.Disable();
            _inventory.Disable();
        }

        #region OnEventFunctions

        private void OnConfirm(InputAction.CallbackContext context)
        {
            if (ConfirmEvent != null && context.started) ConfirmEvent.Invoke();
        }

        private void OnBack(InputAction.CallbackContext context)
        {
            if (BackEvent != null && context.started) BackEvent.Invoke();
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            if (PauseEvent != null && context.started) PauseEvent.Invoke();
        }

        private void OnInventory(InputAction.CallbackContext context)
        {
            if (InventoryEvent != null && context.started) InventoryEvent.Invoke();
        }
        #endregion

        public void ToggleUIInput(bool value, UIInputType inputType = UIInputType.All)
        {
            switch (inputType)
            {
                case UIInputType.All:
                    if (value)
                    {
                        _confirm.Enable();
                        _back.Enable();
                        _pause.Enable();
                    }
                    else
                    {
                        _confirm.Disable();
                        _back.Disable();
                        _pause.Disable();
                    }
                    break;

                case UIInputType.Confirm:
                    if (value)
                    {
                        _confirm.Enable();
                    }
                    else
                    {
                        _confirm.Disable();
                    }
                    break;

                case UIInputType.Back:
                    if (value)
                    {
                        _back.Enable();
                    }
                    else
                    {
                        _back.Disable();
                    }
                    break;

                case UIInputType.Pause:
                    if (value)
                    {
                        _pause.Enable();
                    }
                    else
                    {
                        _pause.Disable();
                    }
                    break;
            }
        }

    }
}
