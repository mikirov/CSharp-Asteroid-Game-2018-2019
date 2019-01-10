using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Spawner {

    public static AsteroidSpawner Instance { get; private set; }


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

    void Update () {
        base.Update();
        if (CurrentCount == 0)
        {
            GameStateController.Instance.OnAsteroidsKilled();
        }
        //Debug.Log("current asteroids: " + CurrentCount);
    }

    protected override void SetupObject(GameObject prefab)
    {
        AsteroidMovementController asteroidMovementController = prefab.GetComponent<AsteroidMovementController>();
        if (asteroidMovementController)
        {
            asteroidMovementController.SetTarget(PlayerShip);
        }
    }
}
