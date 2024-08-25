using UnityEngine;

namespace Main.Systems
{
    public class GameStateManager : MonoBehaviour
    {
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
        }

        public void SetGameState(GameState newState)
        {
            CurrentState = newState;
            if (newState == GameState.Pause) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }

        public void TogglePause()
        {
            if (CurrentState == GameState.Play) SetGameState(GameState.Pause);
            else if (CurrentState == GameState.Pause) SetGameState(GameState.Play);
        }
    }
}
