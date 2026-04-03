using UnityEngine;

public class ClimbingPlayer : MonoBehaviour
{
    [Header("Settings")]
    public float climbJumpForce = 5f;
    public float detectionDistance = 0.6f;
    public LayerMask wallLayer;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isClimbing = false;
    private float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckForWall();

        if (isClimbing)
        {
            HandleClimbing();
        }
        else
        {
            ApplyGravity();
        }
    }

    void CheckForWall()
    {
        // ยิง Raycast ออกไปข้างหน้าตัวละคร
        RaycastHit hit;
        bool hitWall = Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance, wallLayer);

        // เงื่อนไข: ต้องมีกำแพงข้างหน้า และ กดปุ่ม Shift ค้างไว้
        if (hitWall && Input.GetKey(KeyCode.LeftShift))
        {
            if (!isClimbing) StartClimbing();
        }
        else
        {
            if (isClimbing) StopClimbing();
        }
    }

    void StartClimbing()
    {
        isClimbing = true;
        velocity.y = 0; // รีเซ็ตความเร็วตก เพื่อให้ "อยู่นิ่ง" ทันทีที่เกาะ
    }

    void StopClimbing()
    {
        isClimbing = false;
    }

    void HandleClimbing()
    {
        // 1. อยู่นิ่งๆ (Velocity.y เป็น 0 อยู่แล้วถ้าไม่กดอะไร)
        
        // 2. ถ้ากด Space ให้ปีนขึ้น (ในที่นี้คือการเพิ่มแรงในแกน Y)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = climbJumpForce;
        }

        // เคลื่อนที่ตามแรง Velocity (ใช้ Move เพื่อให้ CharacterController ทำงาน)
        controller.Move(velocity * Time.deltaTime);

        // ลดแรงส่งหลังจากกระโดด (ค่อยๆ กลับมาเป็น 0 เพื่อให้หยุดนิ่งหลังปีน)
        if (velocity.y > 0)
        {
            velocity.y -= Time.deltaTime * 10f; 
        }
        else
        {
            velocity.y = 0; // ล็อคให้หยุดนิ่งจริงๆ
        }
    }

    void ApplyGravity()
    {
        // ระบบแรงโน้มถ่วงปกติเมื่อไม่ได้ปีน
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
