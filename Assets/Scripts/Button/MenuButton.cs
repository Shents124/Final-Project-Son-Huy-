using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public int sceneIndex;

    private Button menuButton;

    private void Awake()
    {
        menuButton = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}