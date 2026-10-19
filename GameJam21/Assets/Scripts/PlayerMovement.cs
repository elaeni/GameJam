using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement: MonoBehaviour
{
    public float MoveForce;
    public float MaxSpeed;

    public float JumpForce;
    public float MaxJump;
    private bool canJump;

    public Text ScoreText;
    private int score;

    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider2d;

    public AudioSource JumpAudio;

    [SerializeField] private LayerMask platformLayerMask;

    private Animator anim;
    private enum AnimationState {idle, walking, jumping };    // create varibale with datatype AnimationState, containing finite set of animation states

    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2d = GetComponent<CapsuleCollider2D>();
        CharacterController charContr = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(rb.velocity.x > 0 ? MaxSpeed : MaxSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
    }

    private void FixedUpdate()
    {
        IsGrounded();
        UpdateAnimationState();

        if (canJump)
        {
            Jump();
            rb.velocity = new Vector2(rb.velocity.x > 0 ? MaxSpeed : MaxSpeed, rb.velocity.y);
        }
    }

    private void IsGrounded() // Function to check if Player touches ground
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(capsuleCollider2d.bounds.center, capsuleCollider2d.bounds.size*.5f, capsuleCollider2d.direction, 0f, Vector2.down, 0.5f,platformLayerMask);
        Color rayColor;

        if (hit.collider != null) // check whether Player is touching ground
        {
            Debug.Log(hit.collider.tag);
            canJump = true;
            rayColor = Color.green;
            if (hit.collider.tag == "Placed_platform")
            {
                JumpAudio.Play();
            }
        }
        else
        {
            canJump = false;
            rayColor = Color.red;
        }
    }

    void Jump()
    { 
        if (rb.velocity.y < (Vector2.up*MaxJump).magnitude)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x > 0 ? MaxSpeed : MaxSpeed, JumpForce);
        }
    }

    private void UpdateAnimationState()
    {
        AnimationState state;
        if (canJump)
        {
            state = AnimationState.jumping;
        }
        else
        {
            state = AnimationState.walking;
        }
        anim.SetInteger("state", (int)state);
    }
}
