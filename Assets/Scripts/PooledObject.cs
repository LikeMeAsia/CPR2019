using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public string label;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        // WHEN SETACTIVE(FALSE), THIS FUNC WILL BE CALLED.
        if (ObjectPooler.Instance.poolDictionary != null)
        {
            Debug.Log("Enqueue [" + label + "]");
            ObjectPooler.Instance.poolDictionary[label].queue.Enqueue(gameObject); //ENQUEUE WHEN INACTIVE
        }
    }
}
