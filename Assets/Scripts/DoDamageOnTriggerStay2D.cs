using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageOnTriggerStay2D : MonoBehaviour
{
    [SerializeField] List<string> tagsToHurt;
    [SerializeField] float damage;
    [SerializeField] float cooldown;
    [SerializeField] List<GameObject> beenDamaged;
    Coroutine doDamageCoroutine = default;

    private void Awake()
    {
        beenDamaged = new List<GameObject>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (CanHurtTo(other))
        {
            if (!IsAlreadyBeenDamaged(other.gameObject))
            {
                StartCoroutine(DoDamage(other));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (CanHurtTo(other))
        {
            if (IsAlreadyBeenDamaged(other.gameObject))
            {
                beenDamaged.Remove(other.gameObject);
            }
        }
    }
    private bool IsAlreadyBeenDamaged(GameObject gameObject)
    {
        return beenDamaged.Exists(g => g.Equals(gameObject));
    }

    private bool CanHurtTo(Collider2D other)
    {
        return tagsToHurt.Exists(tag => other.CompareTag(tag));
    }

    IEnumerator DoDamage(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable.IsDead) yield break;

        beenDamaged.Add(other.gameObject);
        while (!damageable.IsDead && IsAlreadyBeenDamaged(other.gameObject))
        {
            damageable.TakeDamage(damage);
            yield return new WaitForSeconds(cooldown);
        }
        if (damageable.IsDead) beenDamaged.Remove(damageable.gameObject);
    }

    private void OnDisable()
    {
        StopCoroutine(doDamageCoroutine);
    }
}
