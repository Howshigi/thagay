using UnityEngine;
public class MoveLeft : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.left * 45f * Time.deltaTime);
    }
}