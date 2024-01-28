using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EntityController))]
[RequireComponent(typeof(SoundEffectController))]
public class PlayerController : MonoBehaviour
{
    public EntityController controller;

    public ObjectScript CarriedObject;

    public float DropDistance = 2;

    public Attributes Attributes;

    public SoundEffectController SoundEffectController;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EntityController>();
        Attributes = GetComponent<Attributes>();
        SoundEffectController = GetComponent<SoundEffectController>();

        Attributes.OnDamage += () =>
        {
            SoundEffectController.PlaySound("takeDamage");
            controller.Animator.SetTrigger("damaged"); 
        };

        Attributes.OnDeath += () =>
        {
            GameManager.Instance.UIScript.DeathScreen();
            Destroy(gameObject); 
        }; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DropObject"))
            DropObject();

        if (Input.GetButtonDown("UseObject"))
            UseObject();


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
            CarriedObject.transform.position = transform.position.GetInDirection(controller.FacingDirction, DropDistance);
            //prevent the object being brought between levels. 
            SceneManager.MoveGameObjectToScene(CarriedObject.gameObject, SceneManager.GetActiveScene());
            CarriedObject = null; 
        }
    }


    public void UseObject()
    {
        if (CarriedObject == null)
            return;
        controller.Animator.SetTrigger(CarriedObject.attackanimation);
        Attributes.AttackCooldown = Attributes.AttackSpeed; //give time for the animation to run. 

        SoundEffectController.PlaySound(CarriedObject.SoundEffectName); 

        var colliders = Physics2D.OverlapCircleAll(transform.position, Attributes.AttackDistance);

        foreach(var coll in colliders)
        {
            var pacifscript = coll.gameObject.GetComponent<PacificationComponent>();
            if (pacifscript != null)
            {
                pacifscript.ApplyObject(CarriedObject.type); 
            }
        }

        
    }
}
