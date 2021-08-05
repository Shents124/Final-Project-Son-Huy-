using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    private const string PlayerTag = "Player";

    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform targetPlayer;
    
    private int currentWaypointIndex;
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            UIManager.Instance.DisplayLoseGame();
            AudioManager.Instance.PlaySfxLoseGame();
            navMeshAgent.speed = 0f;
        }
    }
}