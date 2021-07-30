using UnityEngine;

public class GameVictory : MonoBehaviour
{
    private const string PlayerTag = "Player";
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            UIManager.Instance.DisplayWinGame();
            AudioManager.Instance.PlaySfxWinGame();
        }
    }
}
