using UnityEngine;

public class PlayerAudioListener : MonoBehaviour
{
    private AudioListener audioListener;
    
    // Start is called before the first frame update
    void Start()
    {
        audioListener = GetComponent<AudioListener>();
    }

    private void OnGamePause()
    {
        AudioListener.pause = true;
    }
}
