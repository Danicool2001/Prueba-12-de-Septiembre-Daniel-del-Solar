using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using FMODUnity;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb2d;
    public float speed = 10f;
    public float jumpForce = 10f;
    public bool canJump;
    [SerializeField] private UnityEngine.UI.Image m_imageRenderer;
    [SerializeField] private FMODUnity.StudioEventEmitter m_audioEmitter;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    void Move(Vector2 input)
    {
        this.input = input;
        m_audioEmitter.Play();
    }

    void Jump(bool pressed)
    {
        if(pressed && canJump)
        {
            rb2d.AddForce(transform.up * jumpForce);
            canJump = false;
            m_audioEmitter.Play();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = Vector2.right * input.x;
        rb2d.position -= velocity * speed * Time.fixedDeltaTime;
    }

    private void OnEnable()
    {
        InputSystem.OnPlayerMovement += Move;
        InputSystem.OnJump += Jump;
    }

    private void OnDisable()
    {
        InputSystem.OnPlayerMovement -= Move;
        InputSystem.OnJump -= Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            m_audioEmitter.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
