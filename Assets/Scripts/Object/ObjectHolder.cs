using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public Transform holdPoint;
    public float maxCarryWeight = 10f; // รับได้สูงสุด

    private PickableObject currentObject;
    private Rigidbody rb;

    public void Hold(PickableObject obj)
    {
        if (obj.weight > maxCarryWeight)
        {
            Debug.Log("ของหนักเกิน!");
            return;
        }

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
            float weightFactor = 1f / currentObject.weight; // ยิ่งหนัก ยิ่งช้า

            Vector3 dir = holdPoint.position - currentObject.transform.position;
            rb.linearVelocity = dir * 10f * weightFactor;
        }
    }

    public bool IsHolding()
    {
        return currentObject != null;
    }
}