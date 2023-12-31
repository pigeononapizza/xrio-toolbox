using UnityEngine;

public static class DebugColorConverter
{
    public static string ToHtmlStringRGB(this Color color)
    {
        return ColorUtility.ToHtmlStringRGB(color);
    }

    public static string Start(Color color)
    {
        return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>";
    }
    public static string End()
    {
        return "</color>";
    }
}

