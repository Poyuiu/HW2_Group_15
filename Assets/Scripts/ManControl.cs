using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ManControl : MonoBehaviour
{
    public ParticleSystem hurtEffect;
    public ParticleSystem healEffect;

    public float forwardSpeed = 5.0f;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 2f;
    public float jumpPower = 4.0f;
    public float useCurveHeight = 0.3f;

    private Animator animator;
    private Rigidbody rb;
    private CapsuleCollider col;

    private int idleState;
    private int locomotionState;
    private int jumpState;
    private int attackState;
    private int walkState;
    private int shootState;

    private bool lockMoving;

    private float origColliderHeight;
    private Vector3 origColliderCenter;

    public float mouseSensitive = 0.2f;
    public Transform manBody;
    public CharacterController manController;
    // Use this for initialization
    void Start()
    {
        // Get component
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<CapsuleCollider>();
        origColliderHeight = col.height;
        origColliderCenter = col.center;

        // Get State Hash
        idleState = Animator.StringToHash("Base Layer.WAIT00");
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        jumpState = Animator.StringToHash("Base Layer.Jump00");
        attackState = Animator.StringToHash("Base Layer.Attack");
        walkState = Animator.StringToHash("Base Layer.Walk00_B");
        shootState = Animator.StringToHash("Base Layer.Shoot");
    }

    private void Update()
    {
        ManTransformControl();
        Anim();

        // Demo
        if (Input.GetKeyDown(KeyCode.C))
        {
            hurtEffect.Play();
        }

        // Demo
        if (Input.GetKeyDown(KeyCode.X))
        {
            healEffect.Play();
        }
    }

    void Anim()
    {
        // Get Animator State
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        lockMoving = false;

        // Play animation
        if (state.fullPathHash == locomotionState)
        {
            // If the character is moving, enable Jump
            if (Input.GetKey(KeyCode.Space))
            {
                // If not in the transition state
                if (!animator.IsInTransition(0))
                {
                    // Enable Jump
                    animator.SetBool("Jump", true);
                    // Add jump force to the rigidbody
                    rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                }
            }
            else if (Input.GetKey(KeyCode.F))
            {
                animator.SetBool("Attack", true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Shoot", true);
            }
        }
        else if (state.fullPathHash == jumpState)
        {
            // Disable Jump
            animator.SetBool("Jump", false);

            // Adjust collider's position
            this.AdjustCollider();
        }
        else if (state.fullPathHash == attackState)
        {
            animator.SetBool("Attack", false);
            lockMoving = true;
        }
        else if (state.fullPathHash == idleState)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // If not in the transition state
                if (!animator.IsInTransition(0))
                {
                    // Enable Jump
                    animator.SetBool("Jump", true);
                    // Add jump force to the rigidbody
                    rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                }
            }
            else if (Input.GetKey(KeyCode.F))
            {
                animator.SetBool("Attack", true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Shoot", true);
            }
        }
        else if (state.fullPathHash == walkState)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // If not in the transition state
                if (!animator.IsInTransition(0))
                {
                    // Enable Jump
                    animator.SetBool("Jump", true);
                    // Add jump force to the rigidbody
                    rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                }
            }
            else if (Input.GetKey(KeyCode.F))
            {
                animator.SetBool("Attack", true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Shoot", true);
            }
        }
        else if (state.fullPathHash == shootState)
        {
            animator.SetBool("Shoot", false);
        }

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", v);
        animator.SetFloat("Direction", h);

    }

    public void ManTransformControl()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x
        + transform.forward * z;

        manController.Move(forwardSpeed * Time.deltaTime * move);

        float mouseX = Input.GetAxis("Mouse X");
        mouseX *= mouseSensitive;
        manBody.Rotate(Vector3.up * mouseX);
    }

    public void AdjustCollider()
    {
        // Get Current Model Height
        Ray ray = new Ray(gameObject.transform.position, -Vector3.up);
        RaycastHit hitInfo = new RaycastHit();

        // If the heights differ too much, adjust the collider height
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.distance > useCurveHeight)
            {
                float jumpHeight = animator.GetFloat("JumpHeight");
                // Adjust collider's height during the jump state
                // The height of the model will decrease due to the jump pose
                col.height = origColliderHeight - jumpHeight;
                // Adjust collider's center during the jump state
                // The center of the collider will rise with the character
                float adjCenterY = origColliderCenter.y + jumpHeight;
                col.center = new Vector3(0, adjCenterY, 0);
            }
            else
            {
                col.height = origColliderHeight;
                col.center = origColliderCenter;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("monster"))
        {
            hurtEffect.Play();
        }

        //TODO
        // Update HP
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cure"))
        {
            healEffect.Play();
        }

        // TODO
        // Update HP
    }

}
