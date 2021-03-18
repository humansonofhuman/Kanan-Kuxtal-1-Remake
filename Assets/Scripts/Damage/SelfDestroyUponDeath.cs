using UnityEngine;

public class SelfDestroyUponDeath : MonoBehaviour
{
    [SerializeField] Damageable theOneWhoDies;

    private void OnEnable()
    {
        theOneWhoDies.OnDie += SelfDestroy;
    }
    private void OnDisable()
    {
        theOneWhoDies.OnDie -= SelfDestroy;
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

}
