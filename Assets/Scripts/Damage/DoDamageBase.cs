using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageBase : MonoBehaviour
{
    public event Action OnDoingDamage;
    [SerializeField] List<string> tagsToDamage;
    [SerializeField] float damage;
    [Tooltip("Time in seconds. On 0 just does damage one time.")]
    [SerializeField] float cooldownTime;
    [SerializeField] bool isOnCooldown;

    public void TryToDamage(GameObject other)
    {
        if (CanHurtTo(other))
        {
            if (!isOnCooldown)
            {
                OnDoingDamage?.Invoke();
                DealDamage(other);
                StartCooldown();
            }
        }
    }

    private void DealDamage(GameObject victim)
    {
        Damageable damageable = victim.GetComponent<Damageable>();
        damageable.TakeDamage(damage);
    }

    private bool CanHurtTo(GameObject other)
    {
        return tagsToDamage.Exists(tag => other.CompareTag(tag));
    }

    private void StartCooldown()
    {
        if (cooldownTime > 0)
        {
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
        yield break;
    }
}
