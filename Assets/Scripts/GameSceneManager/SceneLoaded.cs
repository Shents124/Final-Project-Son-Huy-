using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaded : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EventBroker.CallOnLoadSceneDone();
        AudioManager.Instance.PlayHouseMusic();
    }
}
