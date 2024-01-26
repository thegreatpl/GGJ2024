using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnDamage();

public delegate void OnDeath();

public class Attributes : MonoBehaviour
{
    public float MovementSpeed;
    public int MaxHealth;
    public int AttackDamage;
    public float AttackDistance; 
    public float AttackSpeed;

    public int CurrentHealth;

    //register actions to take on certain things. 
    public OnDamage OnDamage;
    public OnDeath OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
