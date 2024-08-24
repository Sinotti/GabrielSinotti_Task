using Main.SO.Input;
using UnityEngine;

namespace Main.Gameplay.Player.Animations
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [Header("Animation Transition Parameters")]
        [Space(6)]
        [SerializeField] private float _increaseSpeed = 5f;
        [SerializeField] private float _baseAnimSpeedLimit = 1.0f;
        [SerializeField] private float _runningAnimSpeedLimit = 2.0f;

        [Header("References")]
        [Space(6)]
        [SerializeField] private Animator _anim;
        [SerializeField] private InputReader _inputReader;

        private int _animatorSpeedXHash = Animator.StringToHash("VelocityX");
        private int _animatorSpeedZHash = Animator.StringToHash("VelocityZ");

        private float _currentAnimSpeedLimit = 1.0f;
        private float _animSpeedX = 0.0f;
        private float _animSpeedZ = 0.0f;
        private bool _runInput;
        private Vector3 _currentDirectionInput;

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

        private void Update()
        {
            _animSpeedX = Mathf.Lerp(_animSpeedX, _currentDirectionInput.x * _currentAnimSpeedLimit, Time.deltaTime * _increaseSpeed);
            _animSpeedZ = Mathf.Lerp(_animSpeedZ, _currentDirectionInput.z * _currentAnimSpeedLimit, Time.deltaTime * _increaseSpeed);

            _anim.SetFloat(_animatorSpeedXHash, _animSpeedX);
            _anim.SetFloat(_animatorSpeedZHash, _animSpeedZ);
        }

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

            if (_runInput) _currentAnimSpeedLimit = _runningAnimSpeedLimit;
            else _currentAnimSpeedLimit = _baseAnimSpeedLimit;
        }
    }
}