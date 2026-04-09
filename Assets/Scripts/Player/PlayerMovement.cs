using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;

    [Header("Components")]
    public CharacterController controller;
    public Animator animator;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference runAction;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        runAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        runAction.action.Disable();
    }

    void Update()
    {
        // เช็คว่าติดพื้นไหม
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < -2f)
            playerVelocity.y = -2f;

        // รับ input เดิน
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        // เช็คกดวิ่ง (Shift)
        bool isRunning = runAction.action.IsPressed();

        // กำหนดความเร็วจริง
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // 🎯 ส่งค่า Speed เข้า Animator
        float animSpeed = move.magnitude;
        animSpeed *= isRunning ? 1f : 0.4f;

        animator.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);

        // หันตัวละครตามทิศที่เดิน
        if (move != Vector3.zero)
            transform.forward = move;

        // กระโดด
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // แรงโน้มถ่วง
        playerVelocity.y += gravityValue * Time.deltaTime;

        // เคลื่อนที่
        Vector3 finalMove = move * currentSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);
    }
}