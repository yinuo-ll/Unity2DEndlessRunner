using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float rollingSpeed = 1.0f;
    public float jumpPower = 10f;
    public int extraJumps = 1;

    [SerializeField] GameOverScreen GameOverScreen;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;

    bool isGrounded = false;
    int jumpCount = 0;
    float jumpCoolDown;
    Vector2 screenBounds;
    float distanceTravelled;
    
    public void GameOver() {
        GameOverScreen.Setup(distanceTravelled);
    }
    
    // Start is called before the first frame update
    void Start() {
        int distanceTravelled = 0;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) * -1;
    }

    // Update is called once per frame
    void Update() {   
        // Check If Tomato Out of Bounds
        if(transform.position.x < screenBounds.x){
            Destroy(this.gameObject);
            GameOver();
        } else {
            // Calculate Distance Travelled
            CalculateDistance();
        }

        // Check if Tomato Jump/Bounce Called
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        CheckGrounded();
    }

    void CalculateDistance() {
        distanceTravelled = distanceTravelled + rollingSpeed/10000;
    }

    void Jump() {
        if (isGrounded || jumpCount < extraJumps) {
            rb.velocity = new Vector2(0f, jumpPower);
            jumpCount++;
            // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        }
    }

    void CheckGrounded() {
        if (Physics2D.OverlapCircle(groundCheck.position, 2f, groundLayer)) {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        } else if (Time.time < jumpCoolDown) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
}
