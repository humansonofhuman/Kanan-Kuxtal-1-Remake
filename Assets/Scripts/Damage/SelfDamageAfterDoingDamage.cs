using UnityEngine;

[RequireComponent(typeof(DoDamageBase))]
public class SelfDamageAfterDoingDamage : MonoBehaviour
{
    [SerializeField] DoDamageBase doDamage;
    [SerializeField] Damageable selfDamageable;
    [Tooltip("Negative values kills in one hit")]
    [SerializeField] float damage;

    private void OnEnable()
    {
        doDamage.OnDoingDamage += SelfDamage;
    }

    private void OnDisable()
    {
        doDamage.OnDoingDamage -= SelfDamage;
    }

    private void SelfDamage()
    {
        selfDamageable.TakeDamage(damage);
    }
}
