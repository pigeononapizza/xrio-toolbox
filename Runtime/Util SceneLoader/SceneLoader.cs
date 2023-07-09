using UnityEngine;
using UnityEngine.SceneManagement;

namespace XRIO
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string _sceneToLoad;

        public void LoadScenePredefined()
        {
            Debug.Log($"<color=blue> Loading scene: {_sceneToLoad}");
            SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
        }
        public static void LoadScene(string name)
        {
            Debug.Log($"<color=blue> Loading scene: {name}");
            SceneManager.LoadScene(name);
        }

        public static void LoadScene(string name, LoadSceneMode loadType)
        {
            Debug.Log($"<color=blue> Loading scene: {name} in Mode: {loadType}");
            SceneManager.LoadScene(name, loadType);
        }

        public static void LoadSceneAsynchronously(string name)
        {
            Debug.LogWarning("LoadSceneAsynchronously has not been vetted");
            Debug.Log($"<color=blue> Loading scene: {name}");
            SceneManager.LoadSceneAsync(name);
        }
    }
}
