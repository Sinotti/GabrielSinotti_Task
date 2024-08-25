using Main.SO.Input;
using Main.Systems;

//using Main.Systems;
using UnityEngine;

namespace Main.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Screens")]
        [Space(6)]
        [SerializeField] private GameObject _inventoryScreen;
        [SerializeField] private GameObject _pauseScreen;

        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReaderUI _inputReader;

        private bool CanShowPauseScreen => _pauseScreen != null && !_inventoryScreen.activeSelf;
        private bool CanShowInventoryScreen => _inventoryScreen != null && !_pauseScreen.activeSelf;
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
                ToggleScreen(_inventoryScreen);
                GameStateManager.Instance.TogglePause();
            }
        }
        #endregion
    }
}

