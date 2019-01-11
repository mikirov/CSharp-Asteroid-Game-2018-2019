using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementComponent : MonoBehaviour {

    public float movementSpeed = 5.0f;
    public float rotationSpeed = 30.0f;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Move(float x, float y)
    {


        Vector3 direction = new Vector3(x, 0, y);
        direction = direction.normalized;
        direction = direction * movementSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + direction;
        if (!isOutsideScreen(newPosition))
        {
            rb.MovePosition(transform.position + direction);
        }


    }
    public void Move(Vector3 direction)
    {


        direction = direction.normalized;
        direction = direction * movementSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + direction);

    }
    public void MoveTowards(Vector3 target)
    {
        
        float step = movementSpeed * Time.deltaTime;
        Vector3 moveTowards = Vector3.MoveTowards(transform.position, target, step);
        //if (!isOutsideScreen(moveTowards))
        //{
            GetComponent<Rigidbody>().MovePosition(moveTowards);
        //}
    }
    public void RotateAround(Vector3 target)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Quaternion q = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
        Vector3 newPosition = q * (rb.transform.position - target) + target;
        if (!isOutsideScreen(newPosition))
        {
            rb.MovePosition(newPosition);
            rb.MoveRotation(rb.transform.rotation * q);
        }
        //rb.MoveRotation(rb.transform.rotation * q);

    }

    public void Move(Vector2 direction)
    {
        float x = direction.x;
        float y = direction.y;
        Move(x, y);
    }

    public void LookTarget(Vector3 target)
    {
        Quaternion newRotation = Quaternion.LookRotation(target - transform.position);
        rb.MoveRotation(newRotation);
    }

    private bool isOutsideScreen(Vector3 position)
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(position);
        bool wrapped = false;

        for (int i = 0; i < 2; ++i)
        {
            if (viewportPos[i] > 1 || viewportPos[i] < 0)
            {
                viewportPos[i] = viewportPos[i] - Mathf.Floor(viewportPos[i]);
                wrapped = true;
            }
        }

        return wrapped;
    }

}
