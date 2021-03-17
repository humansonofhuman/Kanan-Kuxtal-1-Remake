using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    public Transform Target;
    [SerializeField] float speed = 3f;
    bool isMoving = true;

    void Update()
    {
        if (isMoving)
            Chase();
    }

    void Chase()
    {
        Vector2 direction = Target.position - transform.position;
        direction.Normalize();
        transform.position += (Vector3)direction * (Time.deltaTime * speed);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (IsTarget(other))
        {
            isMoving = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (IsTarget(other))
        {
            isMoving = true;
        }
    }

    private bool IsTarget(Collision2D other)
    {
        return other.gameObject.Equals(Target.gameObject);
    }

}
