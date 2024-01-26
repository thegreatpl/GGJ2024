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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyObject (PacificationType type)
    {
        if (type == PacifyObjectType)
        {
            CurrentMood = Mood.Pacified;
            SpriteLibrary.spriteLibraryAsset = Pacified; 
        }
        else
        {
            CurrentMood = Mood.Enraged; 
            SpriteLibrary.spriteLibraryAsset = Enraged; 
        }
    }



    public enum Mood
    {
        Normal,
        Enraged, 
        Pacified
    }
}
