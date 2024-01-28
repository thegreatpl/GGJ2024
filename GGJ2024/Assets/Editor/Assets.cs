using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Assets : MonoBehaviour
{
    [MenuItem("AssetImport/Load Prefabs")]
    public static void LoadPrefabs()
    {
        using (var gameManagerobj = new PrefabUtility.EditPrefabContentsScope("Assets/Prefabs/Utility/GameManager.prefab"))
        {
            var prefabs = new List<PrefabDefinition>();

            var directories = Directory.GetDirectories("Assets/Prefabs");
            foreach (var d in directories)
            {
                prefabs.AddRange(GetPrefabsFromFolder(d));
            }

            var gamemanager = gameManagerobj.prefabContentsRoot.GetComponent<PrefabManager>();
            gamemanager.Prefabs = prefabs;

        }
    }

    static List<PrefabDefinition> GetPrefabsFromFolder(string d)
    {
        var prefabs = new List<PrefabDefinition>();
        var files = Directory.GetFiles(d).Where(x => Path.GetExtension(x) == ".prefab").ToList();
        foreach (var f in files)
        {
            Debug.Log(f);
            var name = Path.GetFileNameWithoutExtension(f);
            prefabs.Add(new PrefabDefinition()
            {
                Name = name,
                Prefab = (GameObject)AssetDatabase.LoadAssetAtPath(f, typeof(GameObject)),
                Type = Path.GetFileName(d)
            });
        }
        var directories = Directory.GetDirectories(d);
        foreach (var d2 in directories)
        {
            prefabs.AddRange(GetPrefabsFromFolder(d2));
        }


        return prefabs;
    }

    [MenuItem("AssetImport/Create Animations")]
    public static void CreateSpriteLibraries()
    {
        string direct = "Assets/Resources/Entities";
        var files = Directory.GetFiles(direct)
                .Where(x => new string[] { ".png", ".jpg" }.Contains(Path.GetExtension(x))).ToList();

        foreach (var file in files)
        {
            CreateSpriteLibaryFiles(file);
        }
    }

    static void CreateSpriteLibaryFiles(string file)
    {
        var sprites = AssetDatabase.LoadAllAssetsAtPath(file).Where(z => z is Sprite).Cast<Sprite>().ToList();

        if (!(sprites.Count > 1))
            return;

        var name = Path.GetFileNameWithoutExtension(file);

        var asset = ScriptableObject.CreateInstance<SpriteLibraryAsset>();

        for (int idx = 0; idx < 3; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "idle", $"idle{idx}"); 
        }
        for (int idx = 3; idx < 6; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "walk", $"walk{idx}");
        }
        for (int idx = 6; idx < 9; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "useitem", $"useitem{idx}");
        }
        for (int idx = 9; idx < 11; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "damage", $"damage{idx}");
            
        }
        for (int idx = 11; idx < 15; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "useitem2", $"useitem2{idx}");
        }

        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath("Assets/SpriteLibraries/" + $"{name}Library.asset"));
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.SetDirty(asset);
    }
}
