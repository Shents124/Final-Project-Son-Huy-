using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public FixedJoystick joystickController;
    public float turnSpeed = 20f;

    private Animator lemonAnimator;
    private Rigidbody lemonRigidBody;
    private Quaternion lemonRotation;
    private Vector3 lemonMovement;
   
    // Start is called before the first frame update
    void Start()
    {
        lemonAnimator = GetComponent<Animator>();
        lemonRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LemonMoveAndRotation();
    }

    void LemonMoveAndRotation()
    {
        float horizontal = joystickController.Horizontal;
        float vertical = joystickController.Vertical;
        lemonMovement = new Vector3(horizontal, 0f, vertical).normalized;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        lemonAnimator.SetBool("IsWalking", isWalking);

        Vector3 desireForward = Vector3.RotateTowards(transform.forward, lemonMovement, turnSpeed * Time.deltaTime, 0f);
        lemonRotation = Quaternion.LookRotation(desireForward);
    }

    private void OnAnimatorMove()
    {
        lemonRigidBody.MovePosition(lemonRigidBody.position + lemonMovement * lemonAnimator.deltaPosition.magnitude);
        lemonRigidBody.MoveRotation(lemonRotation);
    }

   

    public void OnPlayerDeath()
    {
        Debug.Log("Player Died");
    }

    
}