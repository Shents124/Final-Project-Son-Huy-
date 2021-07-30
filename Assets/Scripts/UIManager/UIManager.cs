using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    private const float FadeDuration = 1f;
    
    public GameObject joystick;
    public GameObject pauseButton;
    public CanvasGroup winGame;
    public CanvasGroup loseGame;
    public GameObject restartMenu;
    public GameObject completedMenu;
    
    private void OnEnable()
    {
        EventBroker.OnLoadSceneDone += ActiveUI;
    }

    private void OnDisable()
    {
        EventBroker.OnLoadSceneDone -= ActiveUI;
    }
    
    private void ActiveUI()
    {
        joystick.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        pauseButton.GetComponent<Image>().enabled = true;
        pauseButton.GetComponent<Button>().enabled = true;
    }

    public void DisableUI()
    {
        joystick.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }
    
    public void DisplayWinGame()
    {
        winGame.gameObject.SetActive(true);
        completedMenu.SetActive(true);
    }

    public void DisplayLoseGame()
    {
        restartMenu.SetActive(true);
        loseGame.gameObject.SetActive(true);
    }
}
