using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Main.Input.Gameplay
{
    [CreateAssetMenu(menuName = "Input/ Input Reader", fileName = "Input Reader")]
    public class InputReader : ScriptableObject
    {
        [SerializeField] private InputActionAsset _asset;

        public UnityAction<float> MoveVerticalEvent;
        public UnityAction<float> MoveHorizontalEvent;
        public UnityAction InteractEvent;

        private InputAction _moveVertical;
        private InputAction _moveHorizontal;
        private InputAction _Interact;

        private void OnEnable()
        {
            _moveVertical = _asset.FindAction("Vertical");
            _moveHorizontal = _asset.FindAction("Horizontal");
            _Interact = _asset.FindAction("Interact");

            _moveVertical.started += OnMoveVertical;
            _moveVertical.canceled += OnMoveVertical;

            _moveHorizontal.started += OnMoveHorizontal;
            _moveHorizontal.canceled += OnMoveHorizontal;

            _Interact.started += OnInteract;
            _Interact.canceled += OnInteract;

            _moveVertical.Enable();
            _moveHorizontal.Enable();
            _Interact.Enable();
        }

        private void OnDisable()
        {
            _moveVertical.started -= OnMoveVertical;
            _moveVertical.canceled -= OnMoveVertical;

            _moveHorizontal.started -= OnMoveHorizontal;
            _moveHorizontal.canceled -= OnMoveHorizontal;

            _Interact.started -= OnInteract;
            _Interact.canceled -= OnInteract;

            _moveVertical.Disable();
            _moveHorizontal.Disable();
            _Interact.Disable();
        }
            
        #region OnEvent Functions

        private void OnMoveVertical(InputAction.CallbackContext context)
        {
            MoveVerticalEvent?.Invoke(context.ReadValue<float>());
        }

        private void OnMoveHorizontal(InputAction.CallbackContext context)
        {
            MoveHorizontalEvent?.Invoke(context.ReadValue<float>());
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            if (InteractEvent != null && context.started) InteractEvent.Invoke();
        }

        #endregion
    }
}
