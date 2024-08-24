using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Main.SO.Input
{
    [CreateAssetMenu(menuName = "SO/Input/Input Reader", fileName = "New Input Reader")]
    public class InputReader : ScriptableObject
    {
        [SerializeField] private InputActionAsset _asset;

        public UnityAction<float> MoveVerticalEvent;
        public UnityAction<float> MoveHorizontalEvent;
        public UnityAction InteractEvent;
        public UnityAction <bool> RunEvent;

        private InputAction _moveVertical;
        private InputAction _moveHorizontal;
        private InputAction _interact;
        private InputAction _run;

        private void OnEnable()
        {
            _moveVertical = _asset.FindAction("Vertical");
            _moveHorizontal = _asset.FindAction("Horizontal");
            _interact = _asset.FindAction("Interact");
            _run = _asset.FindAction("Run");

            _moveVertical.started += OnMoveVertical;
            _moveVertical.canceled += OnMoveVertical;

            _moveHorizontal.started += OnMoveHorizontal;
            _moveHorizontal.canceled += OnMoveHorizontal;

            _interact.started += OnInteract;
            _interact.canceled += OnInteract;

            _run.started += OnRun;
            _run.canceled += OnRun;

            _moveVertical.Enable();
            _moveHorizontal.Enable();
            _interact.Enable();
            _run.Enable();
        }

        private void OnDisable()
        {
            _moveVertical.started -= OnMoveVertical;
            _moveVertical.canceled -= OnMoveVertical;

            _moveHorizontal.started -= OnMoveHorizontal;
            _moveHorizontal.canceled -= OnMoveHorizontal;

            _interact.started -= OnInteract;
            _interact.canceled -= OnInteract;

            _moveVertical.Disable();
            _moveHorizontal.Disable();
            _interact.Disable();
            _run.Disable();
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

        private void OnRun(InputAction.CallbackContext context)
        {
            if (RunEvent != null && context.started) RunEvent.Invoke(true);

            else if (RunEvent != null && context.canceled) RunEvent.Invoke(false);
        }

        #endregion
    }
}
