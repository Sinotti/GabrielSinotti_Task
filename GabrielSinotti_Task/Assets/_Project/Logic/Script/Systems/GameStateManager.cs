using Main.SO.Input;
using UnityEngine;

namespace Main.Systems
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private InputReaderGameplay _inputReader;

        public enum GameState
        {
            Play,
            Pause
        }

        public static GameStateManager Instance { get; private set; }

        public GameState CurrentState { get; private set; } = GameState.Play;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            ToggleMouse(false);
        }

        public void SetGameState(GameState newState)
        {
            CurrentState = newState;
            if (newState == GameState.Pause)
            {
                _inputReader.ToggleGameplayInput(false, InputReaderGameplay.InputType.All);
                ToggleMouse(true);
                Time.timeScale = 0f;
            }
            else 
            {
                _inputReader.ToggleGameplayInput(true, InputReaderGameplay.InputType.All);
                ToggleMouse(false);
                Time.timeScale = 1f;
            } 
        }


        public void TogglePause()
        {
            if (CurrentState == GameState.Play) SetGameState(GameState.Pause);
            else if (CurrentState == GameState.Pause) SetGameState(GameState.Play);
        }

        private void ToggleMouse(bool enabled)
        {
            if(enabled) Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = enabled;
        }
    }
}
