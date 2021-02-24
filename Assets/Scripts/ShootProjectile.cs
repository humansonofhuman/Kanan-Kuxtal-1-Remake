using System.Collections;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] Transform projectilePrefab;
    [SerializeField] float fireRate = 1;
    [SerializeField] Aim aim;
    bool isShooting => Input.GetMouseButton(0);
    bool gunIsLoaded = true;

    void Update()
    {
        if (isShooting && gunIsLoaded) Shoot();
    }

    void Shoot()
    {
        float angle = GetAngle();
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(projectilePrefab, transform.position, targetRotation);

        gunIsLoaded = false;
        StartCoroutine(ReloadGun());
    }

    float GetAngle()
    {
        return Mathf.Atan2(aim.Direction.y, aim.Direction.x) * Mathf.Rad2Deg;
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / fireRate);
        gunIsLoaded = true;
    }

}
