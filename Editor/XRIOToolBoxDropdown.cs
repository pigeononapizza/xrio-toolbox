//This script creates helpful menu items under the menu name "XRIO"
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


//https://docs.unity3d.com/ScriptReference/MenuItem.html
//see link to add shortcut keys
// ^(ctrl), # (shift), & (alt), _ (no key)
namespace UnityLibrary
{
#if UNITY_EDITOR
    public class XRIOToolBoxDropdown : MonoBehaviour
    {
        [MenuItem("XRIO/Unparent &u")]
        static void UnParent()
        {
            // TODO: add undo
            if (Selection.activeGameObject != null && Selection.activeGameObject.transform.parent != null)
            {
                foreach (var sel in Selection.gameObjects)
                {
                    Debug.Log($"Unparented {sel.name} via UnparentMe.cs");
                    sel.transform.parent = sel.transform.parent.parent;
                }
                // Selection.activeGameObject.transform.parent = Selection.activeGameObject.transform.parent.parent;
            }
        }


        [MenuItem("XRIO/UnparentCompletely &#u")]
        static void UnparentCompletely()
        {
            UnSelectIfChildOfSelection();

            for (int i = Selection.gameObjects.Length - 1; i >= 0; i--)
            {
                var sel = Selection.gameObjects[i];
                sel.transform.parent = null;
                sel.transform.SetAsFirstSibling();
            }
        }

        [MenuItem("XRIO/ParentToLastSelected")]
        static void ParentToLastSelected()
        {
            GameObject lastSelectedObj = Selection.activeGameObject;
            UnSelectIfChildOfSelection();

            for (int i = Selection.gameObjects.Length - 1; i >= 0; i--)
            {
                var sel = Selection.gameObjects[i];
                sel.transform.parent = lastSelectedObj.transform;
                // sel.transform.SetParent(lastSelectedObj.transform, true);
            }
        }

        //This will move selected objects to the top of their object hierarchy
        [MenuItem("XRIO/MoveObjectsToTop &1")]
        static void MoveSiblingsToTop()
        {
            if (Selection.activeGameObject != null)
            {
                for (int i = Selection.gameObjects.Length - 1; i >= 0; i--)
                {
                    var sel = Selection.gameObjects[i];
                    Debug.Log($"Moving {sel.name} to top of order");
                    sel.transform.SetAsFirstSibling();
                }
                // Selection.activeGameObject.transform.SetAsFirstSibling();
            }
        }

        [MenuItem("XRIO/MoveObjectsToBottom &0")]
        static void MoveSiblingsToBottom()
        {
            if (Selection.activeGameObject != null)
            {
                for (int i = Selection.gameObjects.Length - 1; i >= 0; i--)
                {
                    var sel = Selection.gameObjects[i];
                    Debug.Log($"Moving {sel.name} to bottom of order");
                    sel.transform.SetAsLastSibling();
                }
            }
        }

        [MenuItem("XRIO/SortChildren")]

        static void MenuAddChild()
        {
            Sort(Selection.activeTransform);
        }

        static void Sort(Transform current)
        {
            foreach (Transform child in current)
                Sort(child);
            current.parent = current.parent;
        }

        [MenuItem("XRIO/UnSelectIfChildOfSelection")]
        static void UnSelectIfChildOfSelection()
        {
            if (Selection.activeGameObject != null)
            {
                List<GameObject> newSelection = new List<GameObject>();
                int originalSelectionCount = Selection.transforms.Length;
                int newSelectionCount = 0;
                for (int i = 0; i < Selection.transforms.Length; i++)
                {
                    bool foundChildParentPairInSelection = false;
                    for (int j = 0; j < Selection.transforms.Length; j++)
                    {
                        if (Selection.transforms[i].parent == Selection.transforms[j])
                        {
                            foundChildParentPairInSelection = true;
                            break;
                        }
                    }
                    if (!foundChildParentPairInSelection)
                    {
                        newSelection.Add(Selection.gameObjects[i]);
                    }
                }
                // newSelection.Add(Selection.transforms[i]);
                newSelectionCount = newSelection.Count;
                Selection.objects = newSelection.ToArray();
                string debug = $"Unselected {originalSelectionCount - newSelectionCount} children. Selection went from {originalSelectionCount} to {newSelectionCount}";
                Debug.Log(debug);
            }
        }

        [MenuItem("XRIO/ZeroOutParent")]
        static void ZeroOutParent()
        {
            if (Selection.activeGameObject != null)
            {
                //get the children of the object that is selected. Save them to a new list. Unparent them. Move the selected object to Vector3.zero. Parent the children back to the selected object.
                List<GameObject> children = new List<GameObject>();
                foreach (Transform child in Selection.activeTransform)
                {
                    children.Add(child.gameObject);
                    child.transform.parent = null;
                }
                Selection.activeTransform.position = Vector3.zero;
                foreach (GameObject child in children)
                {
                    child.transform.parent = Selection.activeTransform;
                }
            }
        }

    }
#endif
}
