using System.Collections;
using UnityEngine;

namespace Main.Gameplay.Player
{
    public class StatusManager : MonoBehaviour
    {
        public static StatusManager Instance { get; private set; }

        [Header("Status References")]
        [Space(6)]
        [SerializeField] private Collider _playerCollider;

        private Vector3 _originalSize;
        private Vector3 _playerSize;

        private bool _isUnderEffect;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _originalSize = transform.localScale;
            _playerSize = _originalSize;
            _isUnderEffect = false;
        }

        public void SetPlayerSize(float sizeModifier)
        {
            Vector3 targetSize = _originalSize * sizeModifier;
            _isUnderEffect = true;
            StartCoroutine(AnimatePlayerSizeChange(targetSize, 1f));
        }

        public void ResetScale()
        {
            StartCoroutine(AnimatePlayerSizeChange(_originalSize, 1f));
            _isUnderEffect = false;
        }

        public bool IsUnderEffect()
        {
            return _isUnderEffect;
        }

        public Vector3 GetPlayerSize()
        {
            return _playerSize;
        }

        public void TemporarilyDisableCollision(float duration)
        {
            StartCoroutine(DisableCollisionCoroutine(duration));
        }

        private IEnumerator DisableCollisionCoroutine(float duration)
        {
            if (_playerCollider != null)
            {
                _playerCollider.enabled = false;
                yield return new WaitForSeconds(duration);
                _playerCollider.enabled = true; 
            }
        }

        private IEnumerator AnimatePlayerSizeChange(Vector3 targetSize, float duration)
        {
            Vector3 initialSize = transform.localScale;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                transform.localScale = Vector3.Lerp(initialSize, targetSize, elapsedTime / duration);
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            transform.localScale = targetSize;
            _playerSize = targetSize;
        }
    }
}
