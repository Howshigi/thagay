using UnityEngine;

public class RestartToCheckpoint : MonoBehaviour
{
    public Vector3 checkpointPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = checkpointPosition;
            if (TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    public void SetNewCheckpoint(Vector3 newPos)
    {
        checkpointPosition = newPos;
        Debug.Log("Checkpoint Updated to: " + newPos);
    }
}