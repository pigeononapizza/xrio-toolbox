public class PPKeys
{
    //PlayerPrefs.Save();
    //PlayerPrefs.DeletKey(key);
    //PlayerPrefs.DeleteAll();
    //saving colors : string colorString = ColorUtility.ToHtmlStringRGB(myColor);
    //PlayerPrefs.SetString("myColor", ColorUtility.ToHtmlStringRGB(myColor);
    //get color : Color myColor = ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("myColor"), out myColor);
    public static string USERNAME = "USERNAME";
    public static string GAMESTATE = "GAMESTATE";
    public enum GAMESTATES { MENU, GAME, PAUSED, GAMEOVER, LOBBY, ROUND, ROUNDEND, CREDITS };
}