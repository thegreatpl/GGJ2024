using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{

    public Vector3 PlayerSpawn = Vector3.zero;

    public string NextLevel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadWorld()
    {
        yield return null;
        if (GameManager.Instance.Player != null) 
            GameManager.Instance.Player.transform.position = PlayerSpawn;
    }
}
