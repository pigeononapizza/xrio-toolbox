// unparents selected gameobject in hierarchy (by moving to grandparents if available)

using UnityEditor;
using UnityEngine;

namespace UnityLibrary
{
#if UNITY_EDITOR
    public class UnparentMe
    {
        // https://docs.unity3d.com/ScriptReference/MenuItem.html
        // shift U shortcut key
        [MenuItem("GameObject/Unparent #u")]
        static void UnParent()
        {
            // TODO: add undo
            if (Selection.activeGameObject != null && Selection.activeGameObject.transform.parent != null)
            {
                Debug.Log($"Unparented {Selection.activeGameObject.name} via UnparentMe.cs");
                Selection.activeGameObject.transform.parent = Selection.activeGameObject.transform.parent.parent;
            }
        }
    }
#endif
}