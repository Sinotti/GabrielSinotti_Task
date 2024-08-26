using Main.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.UI
{
    public class SceneController : MonoBehaviour
    {
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
