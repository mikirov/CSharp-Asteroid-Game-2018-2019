using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {

    public Weapon weaponPrefab;
    public List<Transform> SpawnPositions;

    [HideInInspector]
    public Weapon weapon;


    public void Shoot(Transform target = null)
    {
        if (weapon)
        {
            foreach (Transform spawnPosition in SpawnPositions)
            {
                weapon.Shoot(spawnPosition, target);

            }
        }
        else
        {
            Debug.Log("no weapon attached");
        }
    }
    public void SetWeapon(Weapon weaponToSet)
    {
        if (weapon)
        {
            Destroy(weapon);
        }
        weapon = Instantiate(weaponToSet, gameObject.transform);
        weapon.NextShotTime = 0.0f;
    }
    private void Start()
    {
        weapon = Instantiate(weaponPrefab, gameObject.transform);
        weapon.NextShotTime = 0.0f;
    }
}
