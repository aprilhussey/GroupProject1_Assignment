using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerControlScript : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 5f;
    public float jumpHeight = 10f;
    public float gravityScale = 1.5f;

    public GameObject HUD;
    
    private UIScript UiScript;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.tag = "Player";
        UiScript = HUD.GetComponent<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if ((Input.GetKey(KeyCode.LeftArrow) || UiScript.leftArrow || Input.GetKey(KeyCode.RightArrow) || UiScript.rightArrow) && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
        {
            if (Input.GetKey(KeyCode.LeftArrow) || UiScript.leftArrow)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = 1;
            }
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if ((Input.GetKeyDown(KeyCode.Space) || UiScript.jumpButton) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(GetComponent<CapsuleCollider2D>(), LayerMask.GetMask("Platform"));
        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
    }
}