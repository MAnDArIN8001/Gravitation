using UnityEngine;

public class LevelLayer : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            Destroy(gameObject);
        }
    }
}
