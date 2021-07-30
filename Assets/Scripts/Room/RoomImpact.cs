using UnityEngine;
using UnityEngine.Events;

public class RoomID : MonoBehaviour
{
    
    public UnityEvent playerInRoom;
    public UnityEvent playerOutRoom;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRoom?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOutRoom?.Invoke();
        }
    }
}