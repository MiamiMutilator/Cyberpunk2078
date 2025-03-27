using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    public bool isGrounded;

    public float jumpNumber;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    //health and dodging
    public int Health = 100;
    int rngSeed;
    int rngShoot;
    int rngSound;
    public bool isMoving;

    AudioSource audioSource;
    public AudioClip bulletHit;
    public AudioClip bulletMiss1;
    public AudioClip bulletMiss2;
    public AudioClip bulletMiss3;
    public AudioClip bulletMiss4;
    public AudioClip bulletMiss5;

    private void Start()
    {
        //health and dodging
        rngSeed = Random.Range(1, 101);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded)
        {
            jumpNumber = 0;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            Debug.Log("Jumped");
            jumpNumber++;
        }
        if (Input.GetButtonDown("Jump") && isGrounded == false && jumpNumber != 1)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            Debug.Log("Jumped");
            jumpNumber++;

        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //health and dodging
        {

            if (Input.GetButton("Vertical") && isGrounded == true || Input.GetButton("Horizontal") && isGrounded == true)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            if (isGrounded == false)
            {
                isMoving = true;
            }

        }
    }

    public void Damage(int damage)
    {
        if (isMoving == true)
        {
            rngShoot = Random.Range(1, 5);
        }
        else if (isMoving == false)
        {
            rngShoot = 1;
        }

        if (rngShoot == 1)
        {
            Health -= damage;
            audioSource.PlayOneShot(bulletHit);
        }
        if (rngShoot >= 2)
        {
            rngSound = Random.Range(1, 6);
            if (rngSound == 1)
            {
                audioSource.PlayOneShot(bulletMiss1);
            }
            else if (rngSound == 2)
            {
                audioSource.PlayOneShot(bulletMiss2);
            }
            else if (rngSound == 3)
            {
                audioSource.PlayOneShot(bulletMiss3);
            }
            else if (rngSound == 4)
            {
                audioSource.PlayOneShot(bulletMiss4);
            }
            else if (rngSound == 5)
            {
                audioSource.PlayOneShot(bulletMiss5);
            }
        }
    }
}