using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitReceiver : HitReceiver {

    public override void ReceiveHit(GameObject damageDealer)
    {
        base.ReceiveHit(damageDealer);
        Debug.Log("enemy hit recceiver called");
        if (currentHits == hitsToKill)
        {
            EnemySpawner.Instance.CurrentCount -= 1;
        }
    }
}
