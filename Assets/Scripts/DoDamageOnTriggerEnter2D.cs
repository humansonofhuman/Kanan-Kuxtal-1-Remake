using UnityEngine;

[RequireComponent(typeof(DoDamageBase))]
public class DoDamageOnTriggerEnter2D : MonoBehaviour
{
    [SerializeField] DoDamageBase doDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        doDamage.TryToDamage(other.gameObject);
    }
}
