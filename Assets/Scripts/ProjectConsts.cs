using System.Collections.Generic;

public static class ProjectConsts
{
    public const int MainMenuSceneId = 0;
    public const int MenuSceneId = 1;
    public const int GameplaySceneId = 2;

    public const string LevelDataResourceName = "LevelData";
    public const string LevelScorePrefsName = "Score";

    public static readonly Dictionary<LevelResult, string> LevelResults = new Dictionary<LevelResult, string>() 
    {
        { LevelResult.Win, "Win" },
        { LevelResult.Loose, "Loose" }
    };
}
