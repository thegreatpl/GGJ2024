using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image Heart1;

    public Image Heart2;

    public Image Heart3;


    public Image Item; 

   
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController == null && GameManager.Instance.Player != null)
        {
            playerController = GameManager.Instance.Player.GetComponent<PlayerController>();    
        }

        if (playerController != null)
        {
            UpdateHealth();
            UpdateItem();
        }
    }


    void UpdateHealth()
    {
        var hp = playerController.Attributes.CurrentHealth; 
        if (hp < 1)
        {
            Heart1.color = Color.clear; 
        }
        if (hp < 2)
        {
            Heart2.color = Color.clear;
        }
        if (hp < 3) 
        { 
            Heart3.color = Color.clear;
        }
    }


    void UpdateItem()
    {
        if (playerController.CarriedObject == null)
            Item.color = Color.clear;
        else
        {
            Item.color = Color.white;
            Item.sprite = playerController.CarriedObject.Sprite; 
        }
    }

    public void ResetHealth()
    {
        Heart1.color = Color.white;
        Heart2.color = Color.white;
        Heart3.color= Color.white;
    }
}
