using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;

[InitializeOnLoad] // This attribute means the constructor is called when Unity loads
public class DependencyChecker
{
    static DependencyChecker()
    {
        // Perform the check when Unity loads, before entering play mode, and when scripts reload
        EditorApplication.update += CheckForOdinInspector;
    }

    private static void CheckForOdinInspector()
    {
        // Remove the callback after the check is done to avoid checking every frame
        EditorApplication.update -= CheckForOdinInspector;

        // Here's where you check if Odin Inspector is present
        // This example checks for the presence of a specific Odin Inspector namespace
        // Replace "Sirenix.OdinInspector" with the appropriate namespace if this is incorrect
        var odinInspectorPresent = System.Type.GetType("Sirenix.OdinInspector") != null;
        if (!odinInspectorPresent)
        {
            // Display a dialog prompting the user to import Odin Inspector
            EditorUtility.DisplayDialog(
                "Dependency Reminder",
                "This package requires Odin Inspector.",
                "OK");
        }
    }
}