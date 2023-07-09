using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[HelpURL("https://www.youtube.com/watch?v=kSVVQbMVhfA&ab_channel=WarpedImagination")]
public class FindMissingScripts
{
    [MenuItem("XRIO/Missing Scripts/Find Missing Scripts in Project")]
    static void FindMissingScriptsInProjectMenuItem()
    {
        string[] prefabPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".prefab", System.StringComparison.OrdinalIgnoreCase)).ToArray();

        foreach (string path in prefabPaths)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            foreach (Component component in prefab.GetComponentsInChildren<Component>())
            {
                if (component == null)
                {
                    Debug.Log("Missing Component in " + path, prefab);
                    break;
                }
            }
        }
    }

    [MenuItem("XRIO/Missing Scripts/Find Missing Scripts in Scene")]
    static void FindMissingScriptsInSceneMenuItem()
    {
        foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>(true))
        {
            foreach (Component component in gameObject.GetComponentsInChildren<Component>())
            {
                if (component == null)
                {
                    Debug.Log("GameObject found with missing script:" + gameObject.name, gameObject);
                    break;
                }
            }
        }
    }
}

