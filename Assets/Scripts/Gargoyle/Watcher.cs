using UnityEngine;

public class Watcher : MonoBehaviour
{
    private const string PlayerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            UIManager.Instance.DisplayLoseGame();
            AudioManager.Instance.PlaySfxLoseGame();
        }
    }
}
