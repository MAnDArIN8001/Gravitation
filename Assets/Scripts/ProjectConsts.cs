using System.Collections.Generic;

public static class ProjectConsts
{
    public static readonly int MainMenuLvlId = 0;
    public static readonly int MenuLvlId = 1;
    public static readonly int LvlsMenuId = 2;

    public static readonly string LevelDataResourceName = "LevelData";

    public static readonly Dictionary<LevelResult, string> LevelResults = new Dictionary<LevelResult, string>() 
    {
        { LevelResult.Win, "Win" },
        { LevelResult.Loose, "Loose" }
    };
}
