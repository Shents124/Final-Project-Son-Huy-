using UnityEngine.SceneManagement;

public class GameSceneManager : MonoSingleton<GameSceneManager>
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        UIManager.Instance.DisableUI();
        AudioManager.Instance.StopPlayMusic();
    }
}