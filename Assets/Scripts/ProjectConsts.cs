using System.Collections.Generic;

public static class ProjectConsts
{
    public static readonly int MainMenuSceneId = 0;
    public static readonly int MenuSceneId = 1;
    public static readonly int GameplaySceneId = 2;

    public static readonly string LevelDataResourceName = "LevelData";
    public static readonly string LevelScorePrefsName = "Score";

    public static readonly Dictionary<LevelResult, string> LevelResults = new Dictionary<LevelResult, string>() 
    {
        { LevelResult.Win, "Win" },
        { LevelResult.Loose, "Loose" }
    };
}
