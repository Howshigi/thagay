using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public float climbSpeed = 3f;
    public float climbRange = 1.5f;

    private CharacterController controller;
    private PlayerMovement playerController;

    private bool isClimbing = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (!isClimbing)
            {
                TryStartClimb();
            }
            else
            {
                Climb();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopClimb();
        }
    }

    void TryStartClimb()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, climbRange))
        {
            if (hit.collider.CompareTag("Climbable"))
            {
                isClimbing = true;
            }
        }
    }

    void Climb()
    {
        // ปิด gravity จาก PlayerController
        playerController.enabled = false;

        float vertical = Input.GetAxis("Vertical");

        Vector3 move = Vector3.up * vertical * climbSpeed;
        controller.Move(move * Time.deltaTime);
    }

    void StopClimb()
    {
        if (isClimbing)
        {
            isClimbing = false;
            playerController.enabled = true;
        }
    }
}