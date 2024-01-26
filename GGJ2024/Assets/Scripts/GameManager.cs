using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
