using System.Collections.Generic;
using UnityEngine;

public class SceneAssetManager : MonoBehaviour
{
    [System.Serializable]
    public class SceneAsset
    {
        public string name;
        public GameObject gameObject;
    }
    [SerializeField]
    public SceneAsset[] assets;
    private Dictionary<string, SceneAsset> assetDictionary;

    private static SceneAssetManager instance;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        assetDictionary = new Dictionary<string, SceneAsset>();
        foreach (SceneAsset asset in assets)
        {
            assetDictionary.Add(asset.name, asset);
        }
    }

    public static bool GetAsset(string name, out SceneAsset sceneAsset)
    {
        sceneAsset = new SceneAsset();
        if (SceneAssetManager.instance != null && SceneAssetManager.instance.assetDictionary != null)
        {
            bool found = SceneAssetManager.instance.assetDictionary.TryGetValue(name, out sceneAsset);
            return found;
        }
        return false;
    }

    public static bool GetAssetComponent<T>(string name, out T asset) {
        asset = default;
        if (SceneAssetManager.instance != null && SceneAssetManager.instance.assetDictionary != null) {
            SceneAsset sceneAsset = new SceneAsset();
            bool found = SceneAssetManager.instance.assetDictionary.TryGetValue(name, out sceneAsset);
            if (found && sceneAsset.gameObject != null) {
                asset = sceneAsset.gameObject.GetComponent<T>();
                return asset!=null;
            }
        }
        return false;
    }
}
