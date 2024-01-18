using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight = true;

    [HideInInspector]
    public bool isDoubleJumping = false;

    [HideInInspector]
    public bool isGrounded = false;

    public float jumpForce = Constants.playerJumpForce;
    public float maxSpeed = Constants.playerMaxSpeed;

    public Transform groundCheck;
    public LayerMask groundLayers;

    public float groundCheckRadius = Constants.playerGroundCheckRadius;

    public PhysicsMaterial2D jumpMaterial;

    private Animator anim;

    public AudioClip[] footstepSounds;
    public AudioClip jumpSound;
    public AudioClip damageSound;

    private AudioSource audioSource;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

        private void Update()
    {
        if (Input.GetButtonDown(Constants.inputJump))
        {
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);

                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

                anim.SetTrigger("Jump");
                //anim.SetBool("Ground", false);
                PlayJumpAudio();
            }

            else if (isDoubleJumping)
            {
                isDoubleJumping = true;

                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

                anim.SetTrigger("Jump");
                PlayJumpAudio();
            }
        }

        //if (Input.GetButtonDown(Constants.inputClimb))
        //{
        //    FindGameObjectWithTag("Ladder");
        //}
    }
    private void FixedUpdate()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder); //Ladder

        //if(hitInfo.collider != null) // Ladder
        //{
        //    if(Input.GetKeyDown(KeyCode.UpArrow))
        //    {
        //        isClimbing = true;
        //    }
        //}
        //else
        //{
        //    isClimbing = false;
        //}

        //if(isClimbing = true) //Ladder
        //{
        //    inputVertical = Input.GetAxisRaw("Vertical");
        //    rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
        //    rb.gravityScale = 0;
        //}
        //else
        //{
        //    rb.gravityScale = 5;
        //}

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        PhysicsMaterial2D material = gameObject.GetComponent<CircleCollider2D>().sharedMaterial;

        if (isGrounded)
        {
            isDoubleJumping = false;
        }

        if (isGrounded && material == jumpMaterial)
        {
            CircleCollider2D collision = gameObject.GetComponent<CircleCollider2D>();
            collision.sharedMaterial = null;
            collision.enabled = false;
            collision.enabled = true;
        }
        else if (!isGrounded && gameObject.GetComponent<CircleCollider2D>().sharedMaterial == null)
        {
            CircleCollider2D collision = gameObject.GetComponent<CircleCollider2D>();
            collision.sharedMaterial = jumpMaterial;
            collision.enabled = false;
            collision.enabled = true;
        }

        try
        {
            float move = Input.GetAxis(Constants.inputMove);

            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            anim.SetFloat(Constants.animSpeed, move);

            if (move < 0)
            {
                anim.SetFloat(Constants.animSpeed, move * -1);
            }

            if ((move > 0.0f && isFacingRight == false) || (move < 0.0f && isFacingRight == true))
            {
                Flip();
            }
        }
        catch (UnityException error)
        {
            Debug.Log(error.ToString());
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    public void PlayFootstepAudio()
    {
        audioSource.clip = footstepSounds[UnityEngine.Random.Range(0, footstepSounds.Length)];
        audioSource.Play();
    }

    public void PlayJumpAudio()
    {
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }

    public void PlayDamageAudio()
    {
        audioSource.clip = damageSound;
        audioSource.Play();
    }
}
