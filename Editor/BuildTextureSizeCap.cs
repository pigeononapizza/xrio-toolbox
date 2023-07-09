#if UNITY_EDITOR
using UnityEditor;

public static class BuildTextureSizeCap
{
    [MenuItem("XRIO/Switch textures to import with max 512 size")]
    public static void CapProjectTextureSize()
    {
        EditorUserBuildSettings.overrideMaxTextureSize = 512;
        AssetDatabase.Refresh();
    }
    [MenuItem("XRIO/Refresh Asset Database")]
    public static void RefreshAssetDatabase()
    {
        AssetDatabase.Refresh();
    }
}
#endif
