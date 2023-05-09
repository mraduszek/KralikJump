using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    public float jumpForce = 10f; // S�la skoku
    public LayerMask groundLayer; // Vrstva povrchu
    public Transform groundCheck; // Bod pro detekci povrchu
    public float groundCheckRadius = 0.08f; // Polom�r kruhu pro detekci povrchu
    public bool isGrounded; // Indik�tor, zda je hr�� na zemi
    public GameObject platform;
    public Joystick joy;

    private Rigidbody2D rb; // Komponenta Rigidbody2D
    private bool shouldJump; // Indik�tor, zda by m�l hr�� sko�it

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        gameObject.transform.position += new Vector3(joy.Horizontal * Time.deltaTime * 3, 0, 0);
    }

    void FixedUpdate()
    {   // Detekce povrchu


        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);
        isGrounded = (hit.collider != null);
        // Nastaven� indik�toru pro skok, pokud je hr�� na zemi
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }
        // Skok, pokud by m�l hr�� sko�it
        /*if (shouldJump)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }*/
    }
}
