using UnityEngine;

public class ControlAim : MonoBehaviour
{
    [SerializeField] Transform aim;
    Camera cam;
    Vector2 facingDirection;

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }
    void Update()
    {
        MoveAim();
    }

    void MoveAim()
    {
        Vector3 pointerPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        facingDirection = pointerPosition - transform.position;
        facingDirection.Normalize();
        aim.position = transform.position + (Vector3)facingDirection;
    }

}
