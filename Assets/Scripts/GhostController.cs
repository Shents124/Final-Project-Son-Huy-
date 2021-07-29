using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform targetPlayer;
    private float playerInRoomGhostSpeed = 2.25f;
    private float playerOutRoomGhostSpeed = 1.5f;
    
    private bool isPlayerInGhostRoom = false;
    int CurrentWaypointIndex;
    

    private Rigidbody ghostRigidbody;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start ()
    {
        ghostRigidbody = GetComponent<Rigidbody>();
        navMeshAgent.SetDestination (waypoints[0].position);
    }

    void Update ()
    {
        if (isPlayerInGhostRoom == true)
        {
            navMeshAgent.SetDestination(targetPlayer.position);
        }
        
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            CurrentWaypointIndex = (CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[CurrentWaypointIndex].position);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().OnPlayerDeath();
        }
    }
    
    

    public void DetectPlayer()
    {
        isPlayerInGhostRoom = true;
        navMeshAgent.speed = playerInRoomGhostSpeed;
    }

    public void NotDetectPlayer()
    {
        isPlayerInGhostRoom = false;
        navMeshAgent.speed = playerOutRoomGhostSpeed;
    }
}
