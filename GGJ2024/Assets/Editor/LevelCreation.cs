using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


    [MenuItem("Level Creation/CompileScenes")]
    public static void AddAllScenesToBuildSettings()
    {
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();

        var files = Directory.GetFiles("Assets/Scenes").Where(x => Path.GetExtension(x) == ".unity").ToList();

        var menu = files.FirstOrDefault(x => Path.GetFileName(x) == "MainMenu.unity");
        editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(menu, true));
        files.Remove(menu);


        foreach (var scen in files)
        {
            editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scen, true));
        }
        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();

    }
}
