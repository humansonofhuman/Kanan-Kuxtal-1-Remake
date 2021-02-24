using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] Vector2 direction = default;
    public Vector2 Direction
    {
        get => direction;
        set => direction = value;
    }
}
