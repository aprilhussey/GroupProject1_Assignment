using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D r2d;
    public DashState dashState;
    public float dashForce;
    public float dashTimer;
    public float maxDash = 1f;
    public Vector2 savedVelocity;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.X);
                if (isDashKeyDown)
                {
                    savedVelocity = r2d.velocity;
                    r2d.AddForce(new Vector2(r2d.velocity.x * dashForce, r2d.velocity.y));
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if(dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    r2d.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}
