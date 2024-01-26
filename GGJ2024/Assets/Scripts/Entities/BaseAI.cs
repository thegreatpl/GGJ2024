using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityController))]
public class BaseAI : MonoBehaviour
{
    public Attributes Attributes; 
    public EntityController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EntityController>();
        Attributes = GetComponent<Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void MoveToPositionDumb(Vector3 targetPos)
    {
        var distance = targetPos - transform.position;

        if (Vector3.Distance(distance, transform.position) < 0.1f)
        {
            controller.MovementDirection = Direction.None; 
        }
        else if (Mathf.Abs(distance.x) >  Mathf.Abs(distance.y))
        {
            if (distance.x < 0)
            {
                controller.MovementDirection = Direction.Left;
            }
            else
            {
                controller.MovementDirection= Direction.Right;
            }
        }
        else
        {
            if (distance.y < 0)
            {
                controller.MovementDirection = Direction.Down;
            }
            else
            {
                controller.MovementDirection= Direction.Up;
            }
        }
    }
}
