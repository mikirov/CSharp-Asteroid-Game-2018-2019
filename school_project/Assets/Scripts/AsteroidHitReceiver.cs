using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHitReceiver : HitReceiver {

    public override void ReceiveHit(GameObject damageDealer)
    {
        base.ReceiveHit(damageDealer);
        if (currentHits == hitsToKill)
        {
            if (ObjectToSpawnOnDeath)
            {
                AsteroidSpawner.Instance.CurrentCount += 2;
            }
            AsteroidSpawner.Instance.CurrentCount -= 1;
        }

    }
}
