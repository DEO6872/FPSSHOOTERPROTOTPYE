using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;
public void Shoot()
{
    Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
    if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
    {
        if(hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
        {
            enemy.Health -= Damage;
        }
    }
}
}
