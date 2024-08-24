using Main.Input.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReader _inputReader;

        private float _verticalDirection;
        private float _horizontalDirection;

        private void Awake()
        {
            _inputReader.MoveVerticalEvent += OnMoveVertical;
            _inputReader.MoveHorizontalEvent += OnMoveHorizontal;
        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        private void OnMoveVertical(float verticalMovement)
        {
            _verticalDirection = verticalMovement;
            Debug.Log("Vertical: " + _verticalDirection);
        }

        private void OnMoveHorizontal(float horizontalMovement)
        {
            _horizontalDirection = horizontalMovement;
            Debug.Log("Horizontal " + horizontalMovement);
        }
    }
}
