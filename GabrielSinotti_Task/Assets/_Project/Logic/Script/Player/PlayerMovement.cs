using Main.SO.Input;
using UnityEngine;

namespace Main.Gameplay.Player.Behaviors
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Parameters")]
        [Space(6)]
        [SerializeField] private float _speed;
        [SerializeField] private float _runSpeed;

        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReaderGameplay _inputReader;

        private float _currentSpeed;
        private Vector3 _currentDirectionInput;
        private bool _runInput;

        private bool MovingBackward => _currentDirectionInput.z < 0;

        private void Awake()
        {
            _inputReader.MoveVerticalEvent += OnMoveVertical;
            _inputReader.MoveHorizontalEvent += OnMoveHorizontal;
            _inputReader.RunEvent += OnRun;
        }

        private void OnDestroy()
        {
            _inputReader.MoveVerticalEvent -= OnMoveVertical;
            _inputReader.MoveHorizontalEvent -= OnMoveHorizontal;
            _inputReader.RunEvent -= OnRun;
        }

        private void FixedUpdate()
        {
            if (!MovingBackward)
            {
                MoveSpeedManager();
            }

            Movement();
        }

        private void Movement()
        {
            Vector3 moveDirection = new Vector3(_currentDirectionInput.x, 0, _currentDirectionInput.z).normalized;
            moveDirection = transform.TransformDirection(moveDirection);

            transform.position += moveDirection * _currentSpeed * Time.deltaTime;
        }

        private void MoveSpeedManager()
        {
            if (_runInput) _currentSpeed = _runSpeed;
            else _currentSpeed = _speed;
        }
        #region Input Assigments
        private void OnMoveVertical(float verticalMovementInput)
        {
            _currentDirectionInput.z = verticalMovementInput;
        }

        private void OnMoveHorizontal(float horizontalMovementInput)
        {
            _currentDirectionInput.x = horizontalMovementInput;
        }

        private void OnRun(bool runInput)
        {
            _runInput = runInput;
        }
        #endregion
    }
}
