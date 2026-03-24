using UnityEngine;
public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = other.transform.position;
            PlayerPrefs.SetFloat("x", pos.x);
            PlayerPrefs.SetFloat("y", pos.y);
            PlayerPrefs.SetFloat("z", pos.z);
            PlayerPrefs.Save();
            Debug.Log("Checkpoint Saved: " + pos);
        }
    }
}