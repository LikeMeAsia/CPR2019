using UnityEngine;
using UnityEngine.UI;

public class LookMarker : MonoBehaviour
{
    Animator anim;
    float progress;
    public Image progressImg;

    // Start is called before the first frame update
    void Start()
    {
        SetProgress(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProgress(float amount) {
        progress = amount;
        progressImg.fillAmount = progress;
    }
}
