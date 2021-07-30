using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    private const string PlayerTag = "Player";

    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform targetPlayer;
    
    private float playerInRoomGhostSpeed = 3f;
    private float playerOutRoomGhostSpeed = 2f;
    
    private bool isPlayerInGhostRoom = false;
    private int currentWaypointIndex;
    
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
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[currentWaypointIndex].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            UIManager.Instance.DisplayLoseGame();
            AudioManager.Instance.PlaySfxLoseGame();
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
