using UnityEngine;

public class Watcher : MonoBehaviour
{
    private const string PlayerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            Debug.Log("Catch player");
        }
    }
}
