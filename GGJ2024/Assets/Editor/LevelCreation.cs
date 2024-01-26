using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCreation : MonoBehaviour
{
    [MenuItem("Level Creation/New")]
    public static void CreateNewLevel()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        scene.name = "New Level";

        var mapprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Utility/World.prefab");
        var levelmap = PrefabUtility.InstantiatePrefab(mapprefab) as GameObject;
        PrefabUtility.UnpackPrefabInstance(levelmap, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

        var gamemanager = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Utility/GameManager.prefab");
        PrefabUtility.InstantiatePrefab(gamemanager); 
    }
}
