using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(SpriteLibrary))]
public class PacificationComponent : MonoBehaviour
{
    public PacificationType PacifyObjectType;

    public SpriteLibraryAsset Normal; 

    public SpriteLibraryAsset Enraged;

    public SpriteLibraryAsset Pacified;

    public SpriteLibrary SpriteLibrary;

    public Mood CurrentMood; 


    // Start is called before the first frame update
    void Start()
    {
        SpriteLibrary = GetComponent<SpriteLibrary>();
        CurrentMood = Mood.Normal; 
        SpriteLibrary.spriteLibraryAsset = Normal;

       // GameManager.Instance.World.RegisterEnemy(this); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyObject (PacificationType type)
    {
        if (type == PacifyObjectType)
        {
            SetMood(Mood.Pacified); 
        }
        else
        {
            SetMood(Mood.Enraged); 
        }
    }

    public void SetMood(Mood mood)
    {
        CurrentMood = mood; 
        switch (mood)
        {
            case Mood.Normal:
                SpriteLibrary.spriteLibraryAsset = Normal;
                break;
            case Mood.Enraged:
                SpriteLibrary.spriteLibraryAsset = Enraged;
                break;
            case Mood.Pacified:
                SpriteLibrary.spriteLibraryAsset = Pacified;             
                break;
        }
    }



    public enum Mood
    {
        Normal,
        Enraged, 
        Pacified
    }
}
