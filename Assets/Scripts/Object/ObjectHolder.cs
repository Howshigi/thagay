using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public Transform holdPoint;
    private PickableObject currentObject;
    private Rigidbody rb;

    public void Hold(PickableObject obj)
    {
        currentObject = obj;
        rb = obj.GetComponent<Rigidbody>();
        obj.Pick();
    }

    public void Release()
    {
        if (currentObject != null)
        {
            currentObject.Drop();
            currentObject = null;
        }
    }

    void Update()
    {
        if (currentObject != null)
        {
            Vector3 dir = holdPoint.position - currentObject.transform.position;
            rb.linearVelocity = dir * 10f;
        }
    }

    public bool IsHolding()
    {
        return currentObject != null;
    }
}