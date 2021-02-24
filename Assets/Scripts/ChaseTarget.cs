using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    public Transform Target;
    [SerializeField] float speed = 3f;

    void Update()
    {
        Chase();
    }

    void Chase()
    {
        Vector2 direction = Target.position - transform.position;
        direction.Normalize();
        transform.position += (Vector3)direction * (Time.deltaTime * speed);
    }

}
