using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public float ShotsPerSecond = 1f;
    public GameObject ProjectileToSpawn;
    
    [HideInInspector]
    public float NextShotTime = 0.0f;

    public abstract void Shoot(Transform SpawnPosition, Transform target = null);

}
