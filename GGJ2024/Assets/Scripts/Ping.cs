using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    public float Range;

    public float ExpansionSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(ExpansionSpeed, ExpansionSpeed); 

        if (transform.localScale.x > Range)
        {
            Destroy(gameObject);
        }
    }

     
}
