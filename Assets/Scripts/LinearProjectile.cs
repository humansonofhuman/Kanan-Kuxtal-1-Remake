using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float lifeSpan = 5f;

    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    void Update()
    {
        transform.position += transform.right * (Time.deltaTime * speed);
    }

}
