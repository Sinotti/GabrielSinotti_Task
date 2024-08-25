using Main.SO.Input;
using Main.Systems;

//using Main.Systems;
using UnityEngine;

namespace Main.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("References")]
        [Space(6)]
        [SerializeField] private InputReaderUI _inputReader;

        private void OnEnable()
        {
            _inputReader.ConfirmEvent += OnConfirm;
            _inputReader.BackEvent += OnBack;
            _inputReader.PauseEvent += OnPause;
        }

        private void OnDisable()
        {
            _inputReader.ConfirmEvent -= OnConfirm;
            _inputReader.BackEvent -= OnBack;
            _inputReader.PauseEvent -= OnPause;
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
            GameStateManager.Instance.TogglePause();      
        }
        #endregion
    }
}

