using Main.Input.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Parameters")]
        [Space(6)]
        [SerializeField] private float _speed;
        [SerializeField] private float _runSpeed;

        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReader _inputReader;

        private Vector3 _currentDirectionInput;
        private bool _runInput;

        private void Awake()
        {
            _inputReader.MoveVerticalEvent += OnMoveVertical;
            _inputReader.MoveHorizontalEvent += OnMoveHorizontal;
            _inputReader.RunEvent += OnRun;
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 moveDirection = new Vector3(_currentDirectionInput.x, 0, _currentDirectionInput.z);
            transform.position += moveDirection * _speed * Time.deltaTime;
        }

        #region Input Assigments
        private void OnMoveVertical(float verticalMovementInput)
        {
            _currentDirectionInput.x = verticalMovementInput;
        }

        private void OnMoveHorizontal(float horizontalMovementInput)
        {
            _currentDirectionInput.z = horizontalMovementInput;
        }

        private void OnRun(bool runInput)
        {
            _runInput = runInput;
        }
        #endregion
    }
}
