using UnityEngine;

public class ControlMovement : MonoBehaviour
{
    [SerializeField] float speed = 4;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0) * (Time.deltaTime * speed);
    }

}
