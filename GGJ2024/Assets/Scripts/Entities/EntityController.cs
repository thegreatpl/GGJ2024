using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attributes))]
public class EntityController : MonoBehaviour
{
    Attributes attributes;


    public Direction MovementDirection; 

    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
        MovementDirection = Direction.None;
    }

    // Update is called once per frame
    void Update()
    {


        switch (MovementDirection)
        {

            case Direction.Up:
                transform.position += new Vector3(0, attributes.MovementSpeed, 0) * Time.deltaTime;
                break;
            case Direction.Right:
                transform.position += new Vector3(attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                break;
            case Direction.Down:
                transform.position += new Vector3(0, -attributes.MovementSpeed, 0) * Time.deltaTime;
                break;
            case Direction.Left:
                transform.position += new Vector3(-attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                break;            
            
            case Direction.None:
            default:
                break;
        }
    }
}
