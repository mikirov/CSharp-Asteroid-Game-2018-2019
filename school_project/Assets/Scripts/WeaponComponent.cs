using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {

    public Weapon weapon;
    public Transform SpawnPosition;

    public void Shoot()
    {
        if (weapon)
        {
            weapon.Shoot(SpawnPosition);
        }
        else
        {
            Debug.Log("no weapon attached");
        }
    }
    private void Start()
    {
        //Instantiate(weapon, gameObject.transform);
        weapon.NextShotTime = 0.0f;
    }
}
