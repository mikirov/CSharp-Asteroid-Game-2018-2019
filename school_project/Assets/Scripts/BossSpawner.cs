using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

    [SerializeField]
    private Transform position;

    [SerializeField]
    private GameObject bossPrefab;

    [SerializeField]
    private GameObject target;

    private void Start()
    {
        GameObject boss = Instantiate(bossPrefab);
        //boss.transform.position = new Vector3(position.position.x, 0, position.position.z);
        BossShip bossShip = boss.GetComponent<BossShip>();
        bossShip.SetTarget(target);
        
    }
}
