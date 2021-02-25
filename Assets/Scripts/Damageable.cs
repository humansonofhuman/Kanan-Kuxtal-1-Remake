using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public event UnityAction OnDie;
    public bool IsDead;
    [SerializeField] float maxDurability;
    [SerializeField] float durability;
    public void TakeDamage(float amount)
    {
        durability -= amount;
        if (durability <= 0)
        {
            IsDead = true;
            OnDie?.Invoke();
        }
    }

    public void RecoverDurability(float amount)
    {
        durability += amount;
        if(durability > maxDurability)
            durability = maxDurability;
    }

}
