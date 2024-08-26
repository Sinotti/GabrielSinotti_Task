using Main.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.UI
{
    public class SceneController : MonoBehaviour
    {
        public void RestartGame()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Play);
            InventorySystem.Instance.ClearInventory();
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
    }
}
