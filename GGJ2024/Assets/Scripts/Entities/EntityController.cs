using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attributes))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EntityController : MonoBehaviour
{
    Attributes attributes;

    Direction _movementDirection; 

    SpriteRenderer _spriteRenderer;

    public Animator Animator;

    public Direction MovementDirection
    {
        get { return _movementDirection; }
        set 
        {
            if (value == Direction.None && _movementDirection != Direction.None)
                FacingDirction = _movementDirection; 
            else if (value != Direction.None)
                FacingDirction = value;

            _movementDirection = value; 
        }
    }
    public Direction FacingDirction; 

    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
        MovementDirection = Direction.None;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        switch (MovementDirection)
        {

            case Direction.Up:
                transform.position += new Vector3(0, attributes.MovementSpeed, 0) * Time.deltaTime;
                Animator.SetBool("IsWalking", true);
                break;
            case Direction.Right:
                transform.position += new Vector3(attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                _spriteRenderer.flipX = true;
                Animator.SetBool("IsWalking", true);
                break;
            case Direction.Down:
                transform.position += new Vector3(0, -attributes.MovementSpeed, 0) * Time.deltaTime;
                Animator.SetBool("IsWalking", true);
                break;
            case Direction.Left:
                transform.position += new Vector3(-attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                _spriteRenderer.flipX = false;
                Animator.SetBool("IsWalking", true);
                break;            
            
            case Direction.None:
            default:
                Animator.SetBool("IsWalking", false); 
                break;
        }
    }
}
