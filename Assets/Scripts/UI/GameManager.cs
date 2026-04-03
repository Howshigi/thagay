using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector3 checkpointPos;
    void Awake()
    {
        // ทำให้มีตัวเดียวในเกม
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 🔥 ไม่หายตอนเปลี่ยน Scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // ใช้เซฟ Checkpoint
    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPos = pos;
        Debug.Log("Checkpoint Saved: " + pos);
    }
   
}