using UnityEngine;

public class ControlMovement : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] Animator animator;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        ModifyAnimation(h, v);

        transform.position += new Vector3(h, v, 0) * (Time.deltaTime * speed);
    }

    void ModifyAnimation(float h, float v)
    {
        animator.SetFloat("horizontal", h);
        animator.SetFloat("vertical", v);
    }

}
