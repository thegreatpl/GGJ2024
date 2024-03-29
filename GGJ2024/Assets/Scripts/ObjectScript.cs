using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public PacificationType type;

    public Sprite Sprite;

    public string SoundEffectName;

    public string attackanimation; 

    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>()?.PickupObject(gameObject); 
        }
    }
}
