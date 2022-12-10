using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 5.0f;

    [SerializeField]
    private float jumpForce = 11.0f;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private UserInputs.IPlayerMovementHelper playerMovementHelper;

    private float movemnetX;
    private bool isGrounded = true;

    private const string GROUND_TAG = "Ground";
    private const string ENEMY_TAG = "Enemy";
    private const string ANIMATION_CONDITION_IS_WALKING = "IsWalking";
   


    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovementHelper = new KeyboardPlayerMovementHelper();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    private void HandlePlayerMovement()
    {
        movemnetX = playerMovementHelper.getHorizontalInput();

        transform.position += new Vector3(movemnetX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") &&  isGrounded)
        {
            Debug.Log("Jump Called");
            isGrounded = false;
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;


        // To kill player
        // if (collision.gameObject.CompareTag(ENEMY_TAG))
          //  Destroy(gameObject);
    }

    private void AnimatePlayer()
    {
        if(movemnetX > 0)
        {
            animator.SetBool(ANIMATION_CONDITION_IS_WALKING, true);
            spriteRenderer.flipX = false;
        }
        else if (movemnetX < 0){
            animator.SetBool(ANIMATION_CONDITION_IS_WALKING, true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(ANIMATION_CONDITION_IS_WALKING, false);
        }
    }

}
