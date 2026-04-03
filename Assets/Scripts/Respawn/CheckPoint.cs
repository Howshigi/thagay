using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าสิ่งที่มาชนคือ Player และยังไม่เคยเปิดใช้งานจุดนี้
        if (other.CompareTag("Player") && !isActivated)
        {
            // สั่งอัปเดตตำแหน่งในสคริปต์ของผู้เล่น
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                player.UpdateCheckpoint(transform.position);
                isActivated = true; // เปิดแล้วเปิดเลย ไม่ต้องบันทึกซ้ำ

                //เปลี่ยนสีหรือเล่น Effect ตรงนี้ได้
                Debug.Log("Checkpoint Reached!");
            }
        }
    }
}