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

    public static void SetEnabledComponents<T>(this GameObject gameObject, bool enabled) where T : Behaviour
    {
        T[] comps = gameObject.GetComponentsInChildren<T>();
        foreach (T comp in comps) {
            comp.enabled = enabled;
        }
    }

    public static void SetEnabledColliders(this GameObject gameObject, bool enabled)
    {
        Collider[] comps = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider comp in comps)
        {
            comp.enabled = enabled;
        }
    }

    public static void SetEnabledRenderers(this GameObject gameObject, bool enabled)
    {
        Renderer[] comps = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer comp in comps)
        {
            comp.enabled = enabled;
        }
    }
}