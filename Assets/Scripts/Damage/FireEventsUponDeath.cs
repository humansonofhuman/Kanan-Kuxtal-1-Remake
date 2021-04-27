using System.Collections.Generic;
using UnityEngine;

public class FireEventsUponDeath : MonoBehaviour
{
    [SerializeField] Damageable theOneWhoDies;
    [SerializeField] List<VoidEventChannelSO> events;

    private void OnEnable()
    {
        theOneWhoDies.OnDie += FireEvents;
    }

    private void OnDisable()
    {
        theOneWhoDies.OnDie -= FireEvents;
    }

    private void FireEvents()
    {
        events.ForEach(e => e.RaiseEvent());
    }

}
