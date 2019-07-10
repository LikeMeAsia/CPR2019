using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image _sprite;
    public Sprite[] allSprite;
    public float animationTime;
    float spriteChangeSpeed;
    public float startWait;
    

    void Start()
    {
        spriteChangeSpeed = animationTime /allSprite.Length;
    }

    private void OnEnable()
    {
        StartCoroutine(Play());
    }


    void Update()
    {
        
    }

    IEnumerator Play()
    {
        
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < allSprite.Length; i++)
            {
                //Debug.Log(allSprite[i].name + "is Play");
                yield return new WaitForSeconds(spriteChangeSpeed);
                _sprite.sprite = allSprite[i];
            }
        }
    }
}
