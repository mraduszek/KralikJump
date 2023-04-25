using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    public float jumpForce = 10f; // S�la skoku
    public LayerMask groundLayer; // Vrstva povrchu
    public Transform groundCheck; // Bod pro detekci povrchu
    public float groundCheckRadius = 0.01f; // Polom�r kruhu pro detekci povrchu
    public bool isGrounded; // Indik�tor, zda je hr�� na zemi
    public GameObject platform;

    private Rigidbody2D rb; // Komponenta Rigidbody2D
    private bool shouldJump; // Indik�tor, zda by m�l hr�� sko�it

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     
    }

    void FixedUpdate()
    {   // Detekce povrchu
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Nastaven� indik�toru pro skok, pokud je hr�� na zemi
        if (isGrounded)
        {
            shouldJump = true;
        }
        // Skok, pokud by m�l hr�� sko�it
        if (shouldJump)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }
    }
}
