using UnityEngine;

public class DoDamageOnCollisionStay2D : DoDamageBase
{
    private void OnCollisionStay2D(Collision2D other)
    {
        TryToDamage(other.gameObject);
    }

}
