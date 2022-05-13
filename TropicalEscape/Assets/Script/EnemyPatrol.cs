using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private float moveDirection;
    private float moveSpeed;
    private Rigidbody2D r2d;
    private bool facingRight = true;
    private Vector3 localScale;

    bool changeDirection = false;
    public Transform groundCheckPos;
    public Transform wallCheckPos;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        r2d = GetComponent<Rigidbody2D>();
        moveDirection = -1f;
        moveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeDirection)
        {
            moveDirection *= -1f;
        }
    }

    void FixedUpdate()
    {
        r2d.velocity = new Vector2(moveDirection * moveSpeed, r2d.velocity.y);
        changeDirection = Physics2D.OverlapCircle(wallCheckPos.position, 0.1f, groundLayer);
        if (!changeDirection)
        {
        	changeDirection = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
	   }
    }

    void LateUpdate()
    {
        Flip();
    }

    void Flip()
    {
        if (moveDirection > 0)
            facingRight = true;
        else if (moveDirection < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
}