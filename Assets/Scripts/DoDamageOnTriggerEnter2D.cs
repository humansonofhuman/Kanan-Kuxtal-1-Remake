using UnityEngine;

public class DoDamageOnTriggerEnter2D : DoDamageBase
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        TryToDamage(other.gameObject);
    }
}
