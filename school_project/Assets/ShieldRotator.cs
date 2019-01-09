using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotator : MonoBehaviour {

    [SerializeField]
    private float rotationPerSecond = 30.0f;
    [SerializeField]
    private List<string> passTroughTags;

    private void Update()
    {
        //rotate shield around Z;
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0, rotationPerSecond * Time.deltaTime));

    }
    private void OnTriggerEnter(Collider other)
    {
        foreach(string s in passTroughTags)
        {
            if (other.CompareTag(s))
            {
                return;
            }
        }
        HitReceiver hitReceiver = other.gameObject.GetComponent<HitReceiver>();
        if (hitReceiver)
        {
            hitReceiver.ReceiveHit(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }


}
