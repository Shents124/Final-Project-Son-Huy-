using UnityEngine.SceneManagement;

public class GameSceneManager : MonoSingleton<GameSceneManager>
{
    public static string sceneLoad;
    private enum Scene
    {
        MainMenu = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3
    }
    
    public void LoadScene(int sceneIndex)
    {
        Scene sceneName = (Scene) sceneIndex;
        sceneLoad = sceneName.ToString();
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Destroy()
    {
        Destroy(this);
    }
}