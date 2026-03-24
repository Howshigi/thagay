using UnityEngine;
public class LoadCheckpoint : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("x"))
        {
            float x = PlayerPrefs.GetFloat("x");
            float y = PlayerPrefs.GetFloat("y");
            float z = PlayerPrefs.GetFloat("z");
            transform.position = new Vector3(x, y, z);
        }
    }
}