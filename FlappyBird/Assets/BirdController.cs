using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float jumpForce;

    private float originalGravityScale;
    private bool hasStarted;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalGravityScale = rb2D.gravityScale;
        rb2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (hasStarted == false)
            {
                rb2D.gravityScale = originalGravityScale;
                hasStarted = true;
            }
            
            rb2D.linearVelocityY = 0;
            rb2D.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
}
