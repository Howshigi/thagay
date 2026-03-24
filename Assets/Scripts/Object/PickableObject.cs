using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public float weight = 1f; 

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Pick()
    {
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
    }

    public void Drop()
    {
        rb.useGravity = true;
    }
}