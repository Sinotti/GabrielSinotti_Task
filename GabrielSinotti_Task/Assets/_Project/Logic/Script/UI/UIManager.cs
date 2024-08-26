using Main.SO.Input;
using Main.Systems;
using UnityEngine;

namespace Main.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI Screens")]
        [Space(6)]

        [SerializeField] private GameObject _inventoryScreen;
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private GameObject _readableField;
        [SerializeField] private GameObject _collectedItemPopUp;
        
        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReaderUI _inputReader;

        private bool CanShowPauseScreen => _pauseScreen != null && !_inventoryScreen.activeSelf;
        private bool CanShowInventoryScreen => _inventoryScreen != null && !_pauseScreen.activeSelf;
        private bool CanDisableReadableField => _readableField != null && _readableField.activeSelf;
        private bool CanDisablePopUp => _collectedItemPopUp != null && _collectedItemPopUp.activeSelf;

        private void OnEnable()
        {
            _inputReader.ConfirmEvent += OnConfirm;
            _inputReader.BackEvent += OnBack;
            _inputReader.PauseEvent += OnPause;
            _inputReader.InventoryEvent += OnInventory;
        }

        private void OnDisable()
        {
            _inputReader.ConfirmEvent -= OnConfirm;
            _inputReader.BackEvent -= OnBack;
            _inputReader.PauseEvent -= OnPause;
            _inputReader.InventoryEvent += OnInventory;
        }

        private void ToggleScreen(GameObject screen)
        {
            screen.SetActive(!screen.activeSelf);
        }

        #region Input Assigments
        private void OnConfirm()
        {
            Debug.Log("Confirm");
        }

        private void OnBack()
        {
            Debug.Log("Back"); 
        }

        private void OnPause()
        {
            if(CanShowPauseScreen)
            {
                _inputReader.ToggleUIInput(!CanShowInventoryScreen, InputReaderUI.UIInputType.Inventory);
                ToggleScreen(_pauseScreen);
                GameStateManager.Instance.TogglePause();
            }
        }

        private void OnInventory()
        {
            if(CanShowInventoryScreen) 
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
        #endregion
    }
}

