using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    public List<string> TagsToHit;
    //public List<string> TagsToIgnore;

	void OnTriggerEnter(Collider collision)
	{
        foreach (string TagToHit in TagsToHit)
        {
            if (collision.gameObject.CompareTag(TagToHit))
            {
                Destroy(gameObject);
                HitReceiver hitReceiver = collision.gameObject.GetComponent<HitReceiver>();
                if (hitReceiver)
                {
                    hitReceiver.ReceiveHit(gameObject);

                }
                else if (collision.CompareTag("Shield"))
                {
                    return;
                }
                else {

                    Debug.Log("hit receiver not found");
                    Destroy(collision.gameObject);
                    
                }


            }
        }
	}
}
