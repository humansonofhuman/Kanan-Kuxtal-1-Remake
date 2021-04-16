using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public event Action OnDie;
    public bool IsDead;
    [SerializeField] float maxDurability;
    [SerializeField] float durability;
    [SerializeField] bool destroyGameObjectOnDeath;

    public void TakeDamage(float amount)
    {
        if (IsDead) return;

        if (amount < 0)
            durability = 0;
        else
            durability = Mathf.Clamp(durability - amount, 0, maxDurability);

        if (durability <= 0)
        {
            IsDead = true;
            OnDie?.Invoke();
            if (destroyGameObjectOnDeath)
            {
                Destroy(gameObject);
            }
        }
    }

    public void RecoverDurability(float amount)
    {
        durability = Mathf.Clamp(durability + amount, 0, maxDurability);
    }

}
