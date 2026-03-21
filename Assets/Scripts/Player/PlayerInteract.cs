using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float range = 3f;
    private ObjectHolder holder;

    void Start()
    {
        holder = GetComponent<ObjectHolder>();
    }

    void Update()
    {
        // กดเมาส์ซ้ายค้าง
        if (Input.GetMouseButton(0))
        {
            if (!holder.IsHolding())
            {
                TryPick();
            }
        }

        // ปล่อยเมาส์
        if (Input.GetMouseButtonUp(0))
        {
            holder.Release();
        }
    }

    void TryPick()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            PickableObject obj = hit.collider.GetComponent<PickableObject>();

            if (obj != null)
            {
                holder.Hold(obj);
            }
        }
    }
}