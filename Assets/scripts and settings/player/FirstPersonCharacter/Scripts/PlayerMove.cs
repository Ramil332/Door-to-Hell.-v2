using System;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    CharacterController controller;

    [Header("Move Sound")]
    AudioSource audioSource;
    [SerializeField] private AudioClip[] footstepSounds;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;

    [SerializeField] LayerMask mask;

    [SerializeField] Transform groundCheck;

    //параметры скорости
    [Header("Speed Parameters")]
    [SerializeField] float _walkSpeed;
    [SerializeField] float _runSpeed;
    [SerializeField] float _crouchSpeed;

    //начальная скорость
    float _currentSpeed;

    //кинематика
    [Header("Gravitation and Jump")]
    [SerializeField] float _jumpForce;
    [SerializeField] float _gravity;
    [SerializeField] float _groundCheckDistance;

    //эффект покачивания
    [Header("Head Bobber")]
    [SerializeField] float walkingBobbingSpeed = 14f;
    [SerializeField] float bobbingAmount = 0.05f;

    float defaultPosY = 0;
    float timer = 0;


    private bool _isGrounded;
    private bool _isSpinting = false;

    Vector3 directionMove = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    public bool _canMove { get; set; } = true;
    public bool _canJump { get; set; } = true;
    public bool _canCrouch { get; set; } = true;

    float horizontal;
    float vertical;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    private void Update()
    {
        if (_canMove)
        {
            Walk();

            if (_canJump)
            {
                if (Input.GetButtonDown("Jump") && _isGrounded)
                {
                    velocity.y = Mathf.Sqrt(_gravity * -2 * _jumpForce);
                    JumpSound();
                }

            }

            HundleGravity();

            Sprint(Input.GetKey(KeyCode.LeftShift));

            Crouch(Input.GetKey(KeyCode.LeftControl));

            // HeadBobber();
        }
    }

    private void Walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        directionMove = (transform.forward * vertical + transform.right * horizontal).normalized;

        controller.Move(directionMove * _currentSpeed * Time.deltaTime);

        Invoke("FootStepSound", 2f);


    }

    void HundleGravity()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, _groundCheckDistance, mask);

        velocity.y += _gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (_isGrounded && velocity.y < 0f)
        {
            velocity.y = -2;


        }
    }

    void Sprint(bool canSprint)
    {
        //_currentSpeed = 2f;
        _currentSpeed = canSprint ? _runSpeed : _walkSpeed;
    }

    void Crouch(bool canCrouch)
    {
        if (canCrouch)
        {
            controller.height = 1f;
            //controller.center = new Vector3(0f, 0.5f, 0f); // Половина высоты
        }
        else
        {
            controller.height = 1.5f;
            //controller.center = Vector3.zero;
        }
    }

    void HeadBobber()
    {
        if (Mathf.Abs(directionMove.x) > 0.1f || Mathf.Abs(directionMove.z) > 0.1f)
        {
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }

    void JumpSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    void FootStepSound()
    {
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(footstepSound);
        }
    }

}

