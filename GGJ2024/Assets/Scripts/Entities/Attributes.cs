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
    public int AttackSpeed;
    public float Sight; 

    public int CurrentHealth;
    public int AttackCooldown; 

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
        if (AttackCooldown > 0)
            AttackCooldown--; 
    }


    public void DealDamage(int damage)
    {
        CurrentHealth -= damage;
        OnDamage.Invoke();
        if (CurrentHealth < 0)
            Death();
    }

    public void Death()
    {
        OnDeath.Invoke();
    }
}
