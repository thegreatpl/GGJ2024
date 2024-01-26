using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

[RequireComponent(typeof(EntityController))]
public class PlayerController : MonoBehaviour
{
    public EntityController controller;

    ObjectScript CarriedObject; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EntityController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            DropObject(); 



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

    public void PickupObject(GameObject gm) 
    {
        if (CarriedObject == null)
        {
            if (!gm.GetComponent<ObjectScript>())
                return; 

            gm.SetActive(false);
            gm.transform.parent = transform; 
            gm.transform.position = Vector3.zero;
            CarriedObject = gm.GetComponent<ObjectScript>();
        }
    }


    public void DropObject()
    {
        if (CarriedObject != null)
        {  
            CarriedObject.gameObject.SetActive(true);
            CarriedObject.transform.parent = null;
            CarriedObject.transform.position = transform.position.GetInDirection(controller.FacingDirction); 
            CarriedObject = null; 
        }
    }
}
