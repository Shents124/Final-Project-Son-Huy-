using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject joystick;
    public GameObject pauseButton;
    
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
    
    public void Destroy()
    {
        Destroy(this);
    }
}
