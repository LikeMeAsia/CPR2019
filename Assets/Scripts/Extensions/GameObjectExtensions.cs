using UnityEngine;

public static class GameObjectExtensions
{
    public static void ApplyRecursivelyOnDescendants(this GameObject gameObject, System.Action<GameObject> action)
    {
        if (gameObject != null)
        {
            action(gameObject);
            foreach (Transform transform in gameObject.transform)
            {
                transform.gameObject.ApplyRecursivelyOnDescendants(action);
            }
        }
    }
}