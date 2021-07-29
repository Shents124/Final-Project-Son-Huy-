using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button confirmExitButton;

    private void Awake()
    {
        confirmExitButton = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        confirmExitButton.onClick.AddListener(() => GameManager.Instance.ExitGame());
    }
}
