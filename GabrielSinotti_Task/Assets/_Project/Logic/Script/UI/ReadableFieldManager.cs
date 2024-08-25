using Main.SO.Items;
using TMPro;
using UnityEngine;

namespace Main.UI
{
    public class ReadableFieldManager : MonoBehaviour
    {
        public static ReadableFieldManager Instance { get; private set; }

        [SerializeField] private GameObject _readableField;
        [SerializeField] private TextMeshProUGUI _readableTextArea;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void SetTextInReadableField(string text)
        {
            ToggleReadableField(true);
            _readableTextArea.text = text; 
        }

        public void ToggleReadableField(bool enabled)
        {
            _readableField.SetActive(enabled);
        }
    }
}
