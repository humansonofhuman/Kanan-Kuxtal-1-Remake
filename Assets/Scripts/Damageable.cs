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
        if (IsDead) return;

        durability = Mathf.Clamp(durability - amount, 0, maxDurability); ;
        if (durability <= 0)
        {
            IsDead = true;
            OnDie?.Invoke();
        }
    }

    public void RecoverDurability(float amount)
    {
        durability = Mathf.Clamp(durability + amount, 0, maxDurability);
    }

}
