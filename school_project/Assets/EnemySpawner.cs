using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner {

    public static EnemySpawner Instance { get; private set; }

    [SerializeField]
    private uint waves = 2;

    private uint currentWave = 0;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(CurrentCount == 0 && currentWave <= waves)
        {
            IsSpawningFinished = false;
            base.Update();
        }

    }

    protected override void SetupObject(GameObject prefab)
    {
        //prefab.transform.position = new Vector3(prefab.transform.position.x, 0, prefab.transform.position.z);
        prefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        EnemyShip enemyShip = prefab.GetComponent<EnemyShip>();
        
        enemyShip.SetTarget(PlayerShip.transform.position);

    }
}
