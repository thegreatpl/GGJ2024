using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string FirstLevel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NewGame()
    {
        GameManager.Instance.StartNewGame(FirstLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
