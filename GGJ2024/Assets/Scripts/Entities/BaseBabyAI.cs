using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PacificationComponent))]
[RequireComponent(typeof(SoundEffectController))]
public class BaseBabyAI : BaseAI
{
    public PacificationComponent PacificationComponent;

    public SoundEffectController SoundEffectController;
    // Start is called before the first frame update
    void Start()
    {
        PacificationComponent = GetComponent<PacificationComponent>();
        controller = GetComponent<EntityController>();
        Attributes = GetComponent<Attributes>();
        SoundEffectController = GetComponent<SoundEffectController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (PacificationComponent.CurrentMood)
        {
            case PacificationComponent.Mood.Normal:
                NormalBehaviour();
                break;
            case PacificationComponent.Mood.Enraged:
                EnragedBehaviour();
                break;
            case PacificationComponent.Mood.Pacified:
                PacifiedBehaviour(); 
                break;
        }
    }

    protected virtual void EnragedBehaviour()
    {
        if (GameManager.Instance.Player != null)
        {
            var loc = GameManager.Instance.Player.transform.position;
            var dist = Vector3.Distance(loc, transform.position);
            if (dist < Attributes.AttackDistance && Attributes.AttackCooldown == 0)
            {
                GameManager.Instance.Player.GetComponent<Attributes>()?.DealDamage(Attributes.AttackDamage);
                Attributes.AttackCooldown = Attributes.AttackSpeed;
            }
            else if (CanSee(GameManager.Instance.Player))
                MoveToPositionDumb(loc);
            else
                controller.MovementDirection = Direction.None; //stop wandering off. 
        }
    }

    protected virtual void PacifiedBehaviour()
    {
        //add in idle sounds. 
    }

    protected virtual void NormalBehaviour()
    {
        //add in idle sounds. 
    }
}

