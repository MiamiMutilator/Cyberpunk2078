using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform cam;

    public float baseSpeed = 6;
    public float jumpHeight = 3;
    public float airStrafeMultiplier = 0.5f;
    public bool isGrounded;
    public bool jumped;
    float speed;
    bool canDoubleJump;

    public float jumpNumber;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public Transform playerCenter;

    Rigidbody rb;
    IEnumerator coroutine;
    bool vulverable;
    [SerializeField] float blinkDistance = 5f;
    [SerializeField] float blinkCooldown = 1f;
    KeyCode blinkKeyboard = KeyCode.C;
    KeyCode blinkController = KeyCode.JoystickButton1;
    float blinkTimer;
    bool canBlink;
    float horizontal, vertical;
    public float groundDrag = 5f;

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
    public AudioClip jumpSound;
    public AudioClip dashSound;

    public Slider healthSlider;

    //animations
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        canBlink = true;
        Input.ResetInputAxes();
    }

    private void Start()
    {
        //health and dodging
        rngSeed = Random.Range(1, 101);
        audioSource = GetComponent<AudioSource>();

        //set speed
        speed = baseSpeed;
        HandleSpeedCheat();

        //find camera
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();

        //set double jump
        canDoubleJump = true;

        //find health slider
        //healthSlider = GameObject.Find("Slider").GetComponent<Slider>();

        animator = GetComponent<Animator>();

        animator.SetBool("Idle", true);

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        /*
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        */

        if (isGrounded)
        {
            jumpNumber = 0;
        }
        //Debug.Log(isGrounded);

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

        //health and dodging
        {
            if (Input.GetButton("Vertical") && isGrounded == true || Input.GetButton("Horizontal") && isGrounded == true || Input.GetAxis("Vertical") > .1f && isGrounded == true || Input.GetAxis("Horizontal") > .1f && isGrounded == true || Input.GetAxis("Vertical") < -.1f && isGrounded == true || Input.GetAxis("Horizontal") < -.1f && isGrounded == true || Input.GetAxis("Vertical") < -.1f && Input.GetAxis("Horizontal") < -.1f && isGrounded == true)
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

        //Debug.Log(rb.linearVelocity);
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

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") || Input.GetAxis("Vertical") > .1f || Input.GetAxis("Horizontal") > .1f || Input.GetAxis("Vertical") < -.1f || Input.GetAxis("Horizontal") < -.1f || Input.GetAxis("Vertical") < -.1f && Input.GetAxis("Horizontal") < -.1f)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            isMoving = true;
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            isMoving = false;
        }



        if ((Input.GetKeyDown(blinkKeyboard) || Input.GetKeyDown(blinkController)) && (canBlink || CheatMenu.instance.GetDashCheatStatus()))
            StartCoroutine(Blink());
        else
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                audioSource.PlayOneShot(jumpSound);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpHeight * 3f, rb.linearVelocity.z);
                //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                //Debug.Log("Jumped");
                jumpNumber++;
                animator.SetBool("Jump", true);
                jumped = true;
                StartCoroutine(Wait());
            }
            else if (Input.GetButtonDown("Jump") && isGrounded == false && (jumpNumber <= 1 || CheatMenu.instance.GetJumpCheatStatus()) && canDoubleJump)
            {
                audioSource.PlayOneShot(jumpSound);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpHeight * 3f, rb.linearVelocity.z);
                //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                //Debug.Log("Jumped");
                jumpNumber = 2;
                //animator.SetBool("Jump", true);
                animator.SetTrigger("Double Jump");
                canDoubleJump = false;
                StartCoroutine(Wait());
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

            if (isGrounded) rb.AddForce(moveDir * speed * 5f, ForceMode.Force);
            else rb.AddForce(moveDir * speed * 5f * airStrafeMultiplier, ForceMode.Force);
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
            //Debug.Log("speed controlled");
        }
    }


    IEnumerator Blink()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        RaycastHit hit;
        float adjustedDistance;
        canBlink = false;
        blinkTimer = blinkCooldown;
        audioSource.PlayOneShot(dashSound);
        LayerMask mask = LayerMask.GetMask("Ground", "Wall");


        //step 1: record player velocity & freeze player SKIP


        //step 2: hide player and make invulverable
        transform.GetChild(0).gameObject.SetActive(false);
        vulverable = false;

        //step 3: make sure blink is going to be in correct direction
        Vector3 forward = transform.TransformDirection(Vector3.forward) * blinkDistance;
        Debug.DrawRay(playerCenter.transform.position, forward, Color.blue, 5f);

        //step 4: check if blink can go max distance
        if (Physics.Raycast(playerCenter.transform.position, transform.forward, out hit, blinkDistance, mask))
        {
            //shorten distance so that you stop in front of obstacle
            adjustedDistance = hit.distance - 1f;

            //ensure player doesn't go backwards
            if (adjustedDistance < 0) adjustedDistance = 0;

            //hit.distance - distance from player to collision
            //hit.point - impact point in world space
        }
        else adjustedDistance = blinkDistance;

        //step 4.5: calculate new position after blink
        Vector3 finalBlinkPosition = transform.position + new Vector3(transform.forward.x * adjustedDistance, transform.forward.y * adjustedDistance, transform.forward.z * adjustedDistance);

        //step 4.6: attack enemies in dash path
        DashAttack(adjustedDistance);

        //step 5: move player based on distance from step 4
        rb.position = finalBlinkPosition;

        //step 6: freeze player wait for small amount of time so that dash is not instant
        //rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(0.05f);

        //step 7: if player went max blink distance, restore velocity
        if (adjustedDistance != blinkDistance)
            rb.linearVelocity = new Vector3(0, 0, 0);

        //step 8: show player and make vulnerable and unfreeze
        transform.GetChild(0).gameObject.SetActive(true);
        //rb.constraints = RigidbodyConstraints.None;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        vulverable = true;

        //might need to record velocity & freeze player at begining of blink
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
            UpdateHealth(damage);
            audioSource.PlayOneShot(bulletHit);
            GameManager.instance.UpdateHealth(-15);
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

    void UpdateHealth(int damage)
    {
        Health -= damage;
        //healthSlider.value = Health;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("Jump", false);
        animator.SetBool("Idle", true);
        canDoubleJump = true;
        yield break;
    }

    void DashAttack(float length)
    {
        GameObject player = GameObject.Find("Player");


        GameObject attack = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //decouple from player
        attack.transform.parent = null;

        //set size and position and rotation
        attack.transform.localScale = new Vector3(length, 3f, 0.5f);
        attack.transform.position = player.transform.position; //move to player position
        attack.transform.Translate(player.transform.forward * (length / 2)); //move to halfway past player
        attack.transform.rotation = player.transform.rotation; //rotate to same as player
        attack.transform.Rotate(0, -90, 0);    //rotate again to correct angle


        //make invisible
        attack.GetComponent<Renderer>().enabled = false;
        //make trigger
        attack.GetComponent<Collider>().isTrigger = true;
        //give it attack tag
        attack.tag = "AttackBox";
        //assign its script
        attack.AddComponent<AttackBox>();
    }

    public void HandleSpeedCheat()
    {
        if (CheatMenu.instance.GetSpeedCheatStatus())
        {
            speed = baseSpeed * 2;
        }
        else
            speed = baseSpeed;

        Debug.Log(speed);
    }
}