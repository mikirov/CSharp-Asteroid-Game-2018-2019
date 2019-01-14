using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(WeaponComponent))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(SpellComponent))]
[RequireComponent(typeof(HitReceiver))]

public class Ship : MonoBehaviour {

    

    WeaponComponent weaponComponent;
    MovementComponent movementComponent;
    SpellComponent spellComponent;
    List<Vector4> PositionAtTime;
    protected void Start()
    {
        weaponComponent = GetComponent<WeaponComponent>();
        movementComponent = GetComponent<MovementComponent>();
        spellComponent = GetComponent<SpellComponent>();

        PositionAtTime = new List<Vector4>();
      
    }
    protected void Update()
    {
        AddPosition(transform.position);
    }

    protected void Shoot(Transform target = null)
    {
        weaponComponent.Shoot(target);
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
    protected void SetWeapon(Weapon weapon)
    {
        weaponComponent.SetWeapon(weapon);
    }

    public void AddPosition(Vector3 position)
    {
        Vector4 positionAtTime = new Vector4(position.x, position.y, position.z, Time.time);
        PositionAtTime.Add(positionAtTime);
    }

    public Vector3? GetPositionAtTime(float time)
    {
        for (int i = 0; i < PositionAtTime.Count; i++)
        {
            if (PositionAtTime[i].w - time <= Time.deltaTime)
            {
                Vector3 result = new Vector3(PositionAtTime[i].x, PositionAtTime[i].y, PositionAtTime[i].z);
                return result;
            }
        }
        return null;
    }


}
