using System.Collections.Generic;
using UnityEngine;

public class DoDamageOnTriggerEnter2D : MonoBehaviour
{
    [SerializeField] List<string> tagsToHurt;
    [SerializeField] float enterDamage;
    [SerializeField] bool dieAfterEnterDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CanHurtTo(other))
        {
            other.GetComponent<Damageable>().TakeDamage(enterDamage);
            if (dieAfterEnterDamage) Destroy(gameObject);
        }
    }

    private bool CanHurtTo(Collider2D other)
    {
        return tagsToHurt.Exists(tag => other.CompareTag(tag));
    }
}
