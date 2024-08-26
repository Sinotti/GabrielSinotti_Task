using Main.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.UI
{
    public class SceneController : MonoBehaviour
    {
        private void FinishScene()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Play);
            InventorySystem.Instance.ClearInventory();
        }

        public void RestartGame()
        {
            FinishScene();
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
#else
            Application.Quit();
#endif
        }

        public void EndGame()
        {
            FinishScene();
        }
    }
}
