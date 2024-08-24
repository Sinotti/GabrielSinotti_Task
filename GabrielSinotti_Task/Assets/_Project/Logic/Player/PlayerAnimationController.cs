using Main.Input.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Gameplay.Player.Animations
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [Header("Animation Transition Parameters")]
        [Space(6)]
        [SerializeField] private float _increaseSpeed = 5f;
        [SerializeField] private float _decreaseSpeed = -5f;

        [Header("References")]
        [Space(6)]
        [SerializeField] private Animator _anim;
        [SerializeField] private InputReader _inputReader;

        private int _animatorSpeedXHash = Animator.StringToHash("VelocityX");
        private int _animatorSpeedZHash = Animator.StringToHash("VelocityZ");

        private float _forwardAnimSpeedLimit;
        private float _animSpeed = 0.0f;
        private float _runningSpeedModifier = 1;
        private float _runAnimationModfier;
        private bool _runInput;
        private Vector3 _currentDirectionInput;

        bool IsIdle => _currentDirectionInput == Vector3.zero;
        bool IsWalkingForward => _currentDirectionInput.z > 0 && _animSpeed < _forwardAnimSpeedLimit;
        bool SpeedOverLimit => _animSpeed > _forwardAnimSpeedLimit;
        bool SpeedUnderLimit => _animSpeed < _currentDirectionInput.z;

        private void Awake()
        {
            _inputReader.MoveVerticalEvent += OnMoveVertical;
        }

        private void OnDisable()
        {
            _inputReader.MoveVerticalEvent -= OnMoveVertical;
        }
        private void Start()
        {

        }

        private void Update()
        {
            _forwardAnimSpeedLimit = _currentDirectionInput.z + _runAnimationModfier;

            MoveAnimation();

            if (IsIdle)
            {
                IdleAnimation();
            }

            _anim.SetFloat(_animatorSpeedZHash, _animSpeed);
        }
        private void AdjustSpeedParameter(float velocity)
        {
            _animSpeed += Time.deltaTime * velocity;
        }

        private void IdleAnimation()
        {
            if (SpeedOverLimit)
            {
                AdjustSpeedParameter(_decreaseSpeed);
            }
            else if (SpeedUnderLimit)
            {
                AdjustSpeedParameter(_increaseSpeed);
            }

            else return;
        }

        private void MoveAnimation()
        {
            if (IsWalkingForward)
            {
                AdjustSpeedParameter(_increaseSpeed);
            }
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
