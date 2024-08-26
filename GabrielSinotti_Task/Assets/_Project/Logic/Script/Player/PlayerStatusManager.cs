using System.Collections;
using UnityEngine;

namespace Main.Gameplay.Player
{
    public class StatusManager : MonoBehaviour
    {
        public static StatusManager Instance { get; private set; }

        private Vector3 _originalSize;
        private Vector3 _playerSize;

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
        }

        public void SetPlayerSize(float sizeModifier)
        {
            Vector3 targetSize = _originalSize * sizeModifier;
            StartCoroutine(AnimatePlayerSizeChange(targetSize, 1f));
        }

        public void ResetScale()
        {
            StartCoroutine(AnimatePlayerSizeChange(_originalSize, 1f));
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
