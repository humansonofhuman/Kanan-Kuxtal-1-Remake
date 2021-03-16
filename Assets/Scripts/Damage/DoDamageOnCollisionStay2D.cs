using UnityEngine;

[RequireComponent(typeof(DoDamageBase))]
public class DoDamageOnCollisionStay2D : MonoBehaviour
{
    [SerializeField] DoDamageBase doDamage;

    private void OnCollisionStay2D(Collision2D other)
    {
        doDamage.TryToDamage(other.gameObject);
    }

}
