using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship {

    public float rotationSpeed;
    public float castSpellTime = 2.0f; // cast spell every 2 seconds
    private Vector3 target;

    public void SetTarget(Vector3 targetToSet)
    {
        target = targetToSet;
    }

    private bool isMovingRight;
    private void Start()
    {
        isMovingRight = (Random.Range(0, 100) > 49) ? true : false;

    }
    void Update () {
        if (target != null)
        {
            Debug.Log("target:" + target);
            LookTarget(target);
            MoveSideways();
            MoveForward();
            if(Time.time % castSpellTime == 0)
            {
                CastSpell(Random.Range(0, 1)); // TODO make it get the number of spells from the spell component
            }
        }
        else
        {
            Debug.Log("target not set");
        }
        
	}
    private void MoveSideways()
    {
        Vector2 direction = (isMovingRight) ? Vector2.right : Vector2.left;
        direction *= rotationSpeed;
        direction *= Time.deltaTime;
        Move(direction);

    }
    private void MoveForward()
    {
        Vector2 direction = Vector3.forward;
        Move(direction);
    }
}
