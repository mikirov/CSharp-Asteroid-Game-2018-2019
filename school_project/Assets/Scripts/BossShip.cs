using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : Ship {

    [SerializeField]
    Weapon rageModeWeapon;
    [SerializeField]
    List<Material> rageModeMaterials;
    [SerializeField]
    private float shootingDelay = 0.5f;
    [Range(0, 1)]
    public float rageModeHPMissing = 0.7f;

    private HitReceiver hitReceiver;

    private GameObject target;

    private float startShootingAfter;
    public void SetTarget(GameObject targetToSet)
    {
        target = targetToSet;
    }

    private void Start()
    {
        base.Start();
        startShootingAfter = Time.time + shootingDelay;

        hitReceiver = gameObject.GetComponent<HitReceiver>();
        if (!hitReceiver)
        {
            Debug.Log("no hit receiver");
        }
    }
    private bool ShouldEnableRageMode()
    {
        if ((float)hitReceiver.currentHits / (float)hitReceiver.hitsToKill > rageModeHPMissing)
        {
            return true;
        }
        return false;
    }
    private void EnableRageMode()
    {
        Destroy(gameObject.GetComponent<Weapon>());
        GetComponent<MeshRenderer>().materials = rageModeMaterials.ToArray();

        //SetWeapon(rageModeWeapon);
        GetComponent<WeaponComponent>().weapon = rageModeWeapon;
        Instantiate(rageModeWeapon, gameObject.transform);

    }
    private void FixedUpdate()
    {
        if (!target)
        {
            Debug.Log("target not set");
            return;
           
        }
        //Debug.Log("target: " + target.transform.position);
        //LookTarget(target.transform.position);

        if (ShouldEnableRageMode())
        {
            EnableRageMode();
        }
        if (Time.time > startShootingAfter)
        {
            Shoot(target.transform);
        }
        
    }
}
