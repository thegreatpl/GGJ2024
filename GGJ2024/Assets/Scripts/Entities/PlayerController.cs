using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityController))]
public class PlayerController : MonoBehaviour
{
    public EntityController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EntityController>();
    }

    // Update is called once per frame
    void Update()
    {




        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical"); 

        if (x < 0)
            controller.MovementDirection = Direction.Left;
        else if (x > 0)
            controller.MovementDirection = Direction.Right;

        if (y < 0)
            controller.MovementDirection = Direction.Down;
        else if (y > 0)
            controller.MovementDirection = Direction.Up;

        if (x == 0 && y == 0)
            controller.MovementDirection = Direction.None; 

    }
}
