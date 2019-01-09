using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(SpellComponent))]
[RequireComponent(typeof(HitReceiver))]
[RequireComponent(typeof(DamageDealer))]
public class Ship : MonoBehaviour {

    

    Weapon weapon;
    MovementComponent movementComponent;
    SpellComponent spellComponent;
    protected void Start()
    {
        weapon = GetComponent<Weapon>();
        movementComponent = GetComponent<MovementComponent>();
        spellComponent = GetComponent<SpellComponent>();
    }

    protected void Shoot()
    {
        weapon.Shoot();
    }


    protected void Move(float x, float y)
    {
        movementComponent.Move(x, y);

    }
    protected void Move(Vector2 direction)
    {
        movementComponent.Move(direction);
    }
    protected void Move(Vector3 direction)
    {
        movementComponent.Move(direction);
    }
    protected void MoveTowards(Vector3 target)
    {
        movementComponent.MoveTowards(target);
    }
    protected void RotateAround(Vector3 target)
    {
        movementComponent.RotateAround(target);
    }
    protected void LookTarget(Vector3 target)
    {
        movementComponent.LookTarget(target);
    }
    protected void CastSpell(int index)
    {
        spellComponent.CastSpell(index);
    }




}
