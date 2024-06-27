using UnityEngine;

public class LevelLoader : GameObjectLoader<GameObject>{}// Навсякий, вдруг нам понадобятся скрипты level

public abstract class GameObjectLoader<T> where T : Object
{
    public static T Load(string path)
    {
        var prefabs = Resources.Load<T>(path);
        return prefabs;
    }

    public static T Create(string path)
    {
        var prefabs = Load(path);
        if (prefabs)
        {
            return Object.Instantiate(prefabs);
        }

        return null;
    }
}
    