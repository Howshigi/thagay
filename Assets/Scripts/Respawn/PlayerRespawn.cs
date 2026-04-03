using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 currentCheckpoint;
    private CharacterController controller;
    private Rigidbody rb;

    [Header("Respawn Settings")]
    public float fallThreshold = -10f; // ถ้าตกลงต่ำกว่าค่า Y นี้ จะ Respawn ทันที
    public KeyCode respawnKey = KeyCode.R; // ปุ่มกดสำหรับ Respawn เอง

    void Start()
    {
        currentCheckpoint = transform.position; // เริ่มเกมมา ให้จุดเกิดคือตำแหน่งที่วางตัวละครไว้
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ระบบตกเหวแล้วเกิดใหม่เอง
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }

        // ระบบกดปุ่ม R เพื่อ Respawn
        if (Input.GetKeyDown(respawnKey))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // ถ้าใช้ Character Controller ต้องปิดก่อนวาร์ป ไม่งั้นตำแหน่งจะไม่เปลี่ยน
        if (controller != null) controller.enabled = false;

        // วาร์ปกลับจุด Checkpoint ล่าสุด
        transform.position = currentCheckpoint;

        if (controller != null) controller.enabled = true;

        // รีเซ็ตความเร็ว (ถ้ามี Rigidbody)
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // รีเซ็ตวัตถุในฉาก
        ObjectResetter.Instance.ResetAllObjects(); // เรียกใช้งาน Singleton ของสคริปต์รีเซ็ตวัตถุ
    }

    public void UpdateCheckpoint(Vector3 newPoint)
    {
        currentCheckpoint = newPoint;
        Debug.Log("Checkpoint Updated!");
    }
}