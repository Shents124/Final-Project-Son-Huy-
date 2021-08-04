using UnityEngine;
using UnityEngine.SceneManagement;

public enum CheckMethod
{
    Distance,
    Trigger
}

public class ScenePartLoader : MonoBehaviour
{
    public Transform player;
    public CheckMethod checkMethod;
    public float loadRange;

    private bool isLoaded;
    private bool shouldLoaded;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.sceneCount > 0)
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == gameObject.name)
                {
                    isLoaded = true;
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(checkMethod == CheckMethod.Distance)
        {
            DistanceCheck();
        }
        else
        {
            TriggerCheck();
        }
    }

    private void DistanceCheck()
    {
        if (Vector3.Distance(player.position, transform.position) < loadRange)
            LoadScene();
        else
            UnLoadScene();
    }

    private void LoadScene()
    {
        if (isLoaded == false)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }
    
    private void UnLoadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoaded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoaded = false;
        }
    }

    private void TriggerCheck()
    {
        if(shouldLoaded)
            LoadScene();
        else 
            UnLoadScene();
    }
}
