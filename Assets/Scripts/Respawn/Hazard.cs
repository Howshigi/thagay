using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //เช็คว่าสิ่งที่มาชนมี Tag ว่า "Player" หรือไม่
        if (other.CompareTag("Player"))
        {
            //ดึงสคริปต์ PlayerRespawn จากตัวผู้เล่นมาใช้งาน
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();

            if (player != null)
            {
                //สั่งให้ผู้เล่นวาร์ปกลับจุด Checkpoint
                player.Respawn();
                Debug.Log("Player hit a hazard!");
            }
        }
    }

    // กรณีที่วัตถุอันตรายไม่ได้ติ๊ก Is Trigger (เป็นของแข็งที่ชนแล้วติด)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRespawn player = collision.gameObject.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                player.Respawn();
            }
        }
    }
}