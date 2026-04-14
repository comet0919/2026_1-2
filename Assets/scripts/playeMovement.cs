using Unity.Mathematics;
using UnityEngine;

public class playeMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    public float turnSpeed = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    public float coyoteTime = 2.5f;
    public float coyoteTimeCounter;
    public bool realGrouned = true;
    public GameObject gliberObject;
    public float gliberFallSpeed = 1.0f;
    public float gliberMovespeed = 7.0f;
    public float gliberMaxTime = 5.0f;
    public float gliberTimeLeft;
    public bool isGliding = false;
    public Rigidbody rb;

    public bool isGrounded = true;

    public int coincount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coyoteTimeCounter = 0;
        if(gliberObject != null)
        {
            gliberObject.SetActive(false);
        }
        gliberTimeLeft = gliberMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGrounededState();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movemen = new Vector3(moveHorizontal, 0, moveVertical);
        if (movemen.magnitude>0.1f)
        {
            quaternion targeRotation = Quaternion.LookRotation(movemen);
            transform.rotation = Quaternion.Slerp(transform.rotation, targeRotation, turnSpeed * Time.deltaTime);
        }
        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
        if (rb.linearVelocity.y<0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y>0&&!Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            realGrouned = false;
            coyoteTimeCounter = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("coin"))
        {
            coincount++;
            Destroy(other.gameObject);
        }
    }
    void UpdateGrounededState()
    {
        if (realGrouned)
        {
            coyoteTimeCounter = coyoteTime;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void EnableGlider()
    {
        isGliding = true;
        if(gliberObject != null)
        {
            gliberObject.SetActive(true);
        }
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, -gliberFallSpeed, rb.linearVelocity.z);
    }
}
