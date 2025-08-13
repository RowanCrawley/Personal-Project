
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    bool isGrounded;
    Rigidbody2D RBody;
    public Transform groundCheck;
    public LayerMask groundLayer;


    private void Start() {
        RBody = GetComponent<Rigidbody2D>();
    }
    void Update() {
        //basic horizontal movement
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * speed;
        //charcter self-aligns its rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5);
        //jumping + ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            RBody.AddForce(Vector2.up*jumpForce);
        }
    }
    private void FixedUpdate() {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Respawn")) {
            transform.position = Vector2.zero;
            transform.rotation = Quaternion.identity;
        }
    }
}
