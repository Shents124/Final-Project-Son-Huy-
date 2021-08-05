using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    public float turnSpeed = 20f;

    private Animator lemonAnimator;
    private Rigidbody lemonRigidBody;
    private Quaternion lemonRotation = Quaternion.identity;
    private Vector3 lemonMovement;
    private AudioSource audioSource;
    
    private float horizontal;
    private float vertical;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        lemonAnimator = GetComponent<Animator>();
        lemonRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        horizontal = JoystickInput.Instance.GetHorizontal();
        vertical = JoystickInput.Instance.GetVertical();

        Move();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();

        if (isWalking)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
            audioSource.Stop();
    }

    private void Move()
    {
        lemonMovement = new Vector3(horizontal, 0f, vertical).normalized;
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        isWalking = hasHorizontalInput || hasVerticalInput;
        lemonAnimator.SetBool(IsWalking, isWalking);
    }

    void Rotation()
    {
        Vector3 desireForward =
            Vector3.RotateTowards(transform.forward, lemonMovement, turnSpeed * Time.deltaTime, 0f);
        lemonRotation = Quaternion.LookRotation(desireForward);
    }

    private void OnAnimatorMove()
    {
        lemonRigidBody.MovePosition(lemonRigidBody.position + lemonMovement * lemonAnimator.deltaPosition.magnitude);
        lemonRigidBody.MoveRotation(lemonRotation);
    }
    
}