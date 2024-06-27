using UnityEngine;

public class LevelLoader : GameObjectLoader<MonoBehaviour>{}// Навсякий, вдруг нам понадобятся скрипты level

public abstract class GameObjectLoader<T> where T : MonoBehaviour
{
    public static T Load(string path)
    {
        var prefabs = Resources.Load<T>(path);
        return prefabs;
    }

    public static T Create(string path)
    {
        var prefabs = Load(path);
        return Object.Instantiate(prefabs);
    }
}
    