using UnityEngine;

public class ControlAim : MonoBehaviour
{
    [SerializeField] Aim aim;
    [SerializeField] Transform aimTransform;
    Camera cam;

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }
    void Update()
    {
        UpdateDirection();
        MoveAim();
    }

    void MoveAim()
    {
        aimTransform.position = transform.position + (Vector3)aim.Direction;
    }

    void UpdateDirection()
    {
        Vector3 pointerPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newDirection = pointerPosition - transform.position;
        newDirection.Normalize();
        aim.Direction = newDirection;
    }

}
