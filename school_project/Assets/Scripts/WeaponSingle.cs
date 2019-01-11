using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSingle : Weapon {

    public override void Shoot(Transform SpawnPosition)
    {
        float cooldown = 1 / ShotsPerSecond;
        Debug.Log("nextShotTime:" + NextShotTime);
        if (Time.time > NextShotTime)
        {
            var newProjectile = Instantiate(ProjectileToSpawn, SpawnPosition.position, SpawnPosition.rotation);
            newProjectile.transform.position = new Vector3(newProjectile.transform.position.x, 0, newProjectile.transform.position.z);

            //Physics.IgnoreCollision(gameObject.GetComponentInParent<Collider>(), newProjectile.GetComponent<Collider>());
            NextShotTime = Time.time + cooldown;
            Debug.Log("nextShotTime:" + NextShotTime);
        }
    }

}
