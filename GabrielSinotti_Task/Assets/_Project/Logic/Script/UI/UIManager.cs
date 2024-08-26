using Main.SO.Input;
using Main.Systems;
using UnityEngine;

namespace Main.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("UI Screens")]
        [Space(6)]

        [SerializeField] private GameObject _inventoryScreen;
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private GameObject _readableField;
        [SerializeField] private GameObject _collectedItemPopUp;

        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReaderUI _inputReader;

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

        private bool CanShowPauseScreen => _pauseScreen != null && !_inventoryScreen.activeSelf;
        private bool CanShowInventoryScreen => _inventoryScreen != null && !_pauseScreen.activeSelf;
        private bool CanDisableReadableField => _readableField != null && _readableField.activeSelf;
        private bool CanDisablePopUp => _collectedItemPopUp != null && _collectedItemPopUp.activeSelf;

        private void OnEnable()
        {
            _inputReader.PauseEvent += OnPause;
            _inputReader.InventoryEvent += OnInventory;
        }

        private void OnDisable()
        {
            _inputReader.PauseEvent -= OnPause;
            _inputReader.InventoryEvent -= OnInventory;
        }

        private void ToggleScreen(GameObject screen)
        {
            screen.SetActive(!screen.activeSelf);
        }

        #region Input Assigments


        private void OnPause()
        {
            if (CanShowPauseScreen)
            {
                _inputReader.ToggleUIInput(!CanShowInventoryScreen, InputReaderUI.UIInputType.Inventory);
                ToggleScreen(_pauseScreen);
                GameStateManager.Instance.TogglePause();
            }
        }

        private void OnInventory()
        {
            if (CanShowInventoryScreen)
            {
                _inputReader.ToggleUIInput(!CanShowPauseScreen, InputReaderUI.UIInputType.Pause);

                DisableUIOnInvetoryOpen();
                ToggleScreen(_inventoryScreen);

                GameStateManager.Instance.TogglePause();
            }
        }

        private void DisableUIOnInvetoryOpen()
        {
            if (CanDisableReadableField) ToggleScreen(_readableField);
            if (CanDisablePopUp) ToggleScreen(_collectedItemPopUp);
        }

        public void CloseInventoryAndResumeGame()
        {
            if (_inventoryScreen.activeSelf)
            {
                ToggleScreen(_inventoryScreen);
                GameStateManager.Instance.TogglePause(); // Resume game
            }
        }
        #endregion
    }
}
