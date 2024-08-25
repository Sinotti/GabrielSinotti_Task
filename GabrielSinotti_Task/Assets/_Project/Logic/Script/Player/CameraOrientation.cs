using Main.SO.Input;
using UnityEngine;

namespace Main.Gameplay.Player.Behaviors
{
    public class CameraOrientation : MonoBehaviour
    {
        [Header("Rotation Parameters")]
        [Space(6)]
        [SerializeField] private float _rotationSpeed = 10f;

        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReaderGameplay _inputReader;

        private float _verticalInput;
        private Vector3 _directionToLook;
        private Vector3 _cameraForward;
        private bool WalkingForward => _verticalInput > 0;
        private bool WalkingBackward => _verticalInput < 0;

        private void Awake()
        {
            _inputReader.MoveVerticalEvent += OnMoveVertical;
        }

        private void OnDestroy()
        {
            _inputReader.MoveVerticalEvent -= OnMoveVertical;
        }

        private void Update()
        {
            if (WalkingForward)
            {
                RotateTowardsCamPosition();
            }
            else if (WalkingBackward)
            {
                RotateWhenWalkingBackwards();
            }
        }

        private void RotateTowardsCamPosition()
        {
            _directionToLook = new Vector3(0, 0, _verticalInput);

            _directionToLook = GetCameraRotation() * _directionToLook;

            if (_directionToLook != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_directionToLook);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }

        private void RotateWhenWalkingBackwards()
        {
            _directionToLook = new Vector3(0, 0, Mathf.Abs(_verticalInput));

            _directionToLook = GetCameraRotation() * _directionToLook;

            if (_directionToLook != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_directionToLook);

                Vector3 currentEulerAngles = transform.rotation.eulerAngles;
                Vector3 targetEulerAngles = targetRotation.eulerAngles;

                targetEulerAngles.y = Mathf.LerpAngle(currentEulerAngles.y, targetEulerAngles.y, _rotationSpeed * Time.deltaTime);

                transform.rotation = Quaternion.Euler(currentEulerAngles.x, targetEulerAngles.y, currentEulerAngles.z);
            }
        }

        private Quaternion GetCameraRotation()
        {
            _cameraForward = Camera.main.transform.forward;
            _cameraForward.y = 0;
            Quaternion cameraRotation = Quaternion.LookRotation(_cameraForward);

            return cameraRotation;
        }

        #region Input Assignments
        private void OnMoveVertical(float verticalMovementInput)
        {
            _verticalInput = verticalMovementInput;
        }
        #endregion
    }
}
