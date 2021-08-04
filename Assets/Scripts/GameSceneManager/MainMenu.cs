using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;

    public GameObject loadingInterface;

    public Image loadingProgressBar;

    private List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();

    
    public void StartGame()
    {
        HideMenu();
        ShowLoadingScene();
        sceneToLoad.Add(SceneManager.LoadSceneAsync("Level1"));
        sceneToLoad.Add(SceneManager.LoadSceneAsync("Level01Part1", LoadSceneMode.Additive));
        StartCoroutine(LoadingScene());
    }

    private void HideMenu()
    {
        menu.SetActive(false);
    }

    private void ShowLoadingScene()
    {
        loadingInterface.SetActive(true);
    }

    IEnumerator LoadingScene()
    {
        float totalProgress = 0;

        foreach (var t in sceneToLoad)
        {
            while (t.isDone == false)
            {
                totalProgress += t.progress;
                loadingProgressBar.fillAmount = totalProgress / sceneToLoad.Count;
                yield return null;
            }
        }
    }
}
