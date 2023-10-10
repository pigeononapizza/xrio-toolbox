using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SimpleOnSceneLoaded : DebugBehaviour
{
    [Header("Events")]
    public UnityEvent onSceneLoaded;

    private void Start()
    {
        // Register a callback for the scene loaded event.
        SceneManager.sceneLoaded += OnSceneLoadedCallback;
    }

    private void OnSceneLoadedCallback(Scene scene, LoadSceneMode mode)
    {
        // Invoke the UnityEvent when the specified scene is loaded.
        onSceneLoaded.Invoke();

    }

    private void OnDestroy()
    {
        // Unregister the callback when this GameObject is destroyed to avoid memory leaks.
        SceneManager.sceneLoaded -= OnSceneLoadedCallback;
    }
}
