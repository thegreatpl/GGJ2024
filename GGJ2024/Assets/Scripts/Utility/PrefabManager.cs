using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public List<PrefabDefinition> Prefabs;

    Dictionary<string, PrefabDefinition> prefabsDict = new Dictionary<string, PrefabDefinition>();

    void Start()
    {
        foreach (var prefab in Prefabs)
        {
            prefabsDict.Add(prefab.Name, prefab);
        }
    }

    public GameObject GetPrefab(string name)
    {
        if (prefabsDict.ContainsKey(name))
            return prefabsDict[name].Prefab;
        return null;
    }


   
    // Update is called once per frame
    void Update()
    {

    }
}
