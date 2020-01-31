using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PhysicalButtonSkin", menuName = "PhysicalButton/Skin", order = 1)]
public class PhysicalButtonSkin : ScriptableObject
{
    public Color textColor = Color.black;
    public Sprite iconSprite;
    public Sprite backgroundSprite;
    public Color backgroundColor = Color.white;
    public Color rendColor = Color.white;
}
