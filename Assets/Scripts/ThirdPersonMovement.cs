using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ThirdPersonMovement : MonoBehaviour
{
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

    Rigidbody rb;
    IEnumerator coroutine;
    bool vulverable;
    [SerializeField] float blinkDistance = 5f;
    [SerializeField] float blinkCooldown = 1f;
    public KeyCode blinkKeybind = KeyCode.C;
    float blinkTimer;
    bool canBlink;
    float horizontal, vertical;
    public float groundDrag = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        canBlink = true;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded)
        {
            jumpNumber = 0;
        }

        //handle drag
        if (isGrounded) rb.linearDamping = groundDrag;
        else rb.linearDamping = 0;

        MyInput();
        SpeedControl();


        

        if (!canBlink)
        {
            blinkTimer -= Time.deltaTime;
            if (blinkTimer <= 0)
                canBlink = true;
        }
        
        
        
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        //walk
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(blinkKeybind) && canBlink)
            StartCoroutine(Blink());
        else
        {
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
        }
    }

    void MovePlayer()
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir * speed * 5f, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }


    IEnumerator Blink()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        RaycastHit hit;
        float adjustedDistance;
        canBlink = false;
        blinkTimer = blinkCooldown;

        //step 1: record player velocity & freeze player SKIP


        //step 2: hide player and make invulverable
        //mesh.enabled = false;
        vulverable = false;

        //step 3: make sure blink is going to be in correct direction
        Vector3 forward = transform.TransformDirection(Vector3.forward) * blinkDistance;
        Debug.DrawRay(transform.position, forward, Color.blue, 3f);

        //step 4: check if blink can go max distance
        if (Physics.Raycast(transform.position, transform.forward, out hit, blinkDistance))
        {
            //shorten distance so that you stop in front of obstacle
            adjustedDistance = blinkDistance; //placeholder value

            //hit.distance - distance from player to collision
            //hit.point - impact point in world space
        }
        else adjustedDistance = blinkDistance;

        //step 4.5: calculate new position after blink
        Vector3 finalBlinkPosition = transform.position + new Vector3(transform.forward.x * adjustedDistance, transform.forward.y * adjustedDistance, transform.forward.z * adjustedDistance);
        
        //step 5: move player based on distance from step 4
        rb.position = finalBlinkPosition;

        //step 6: freeze player wait for small amount of time so that dash is not instant
        //rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(0.5f);

        //step 7: if player went max blink distance, restore velocity
        if (adjustedDistance != blinkDistance)
            rb.linearVelocity = new Vector3(0,0,0);

        //step 8: show player and make vulnerable and unfreeze
        //mesh.enabled = true;
        //rb.constraints = RigidbodyConstraints.None;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        vulverable = true;

        //might need to record velocity & freeze player at begining of blink
    }
}