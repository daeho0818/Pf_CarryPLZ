using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCamera : MonoBehaviour
{
    private int shakeCount = 3;
    private Vector3 defaultPos;
    private bool shake = false;


    // Start is called before the first frame update
    void Start()
    {
        defaultPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cameraShake()
    {
        if (shake)
            return;

        StartCoroutine(TryShake());
    }

    IEnumerator TryShake()
    {
        shake = true;
        Vector3 shakeDir = new Vector3(0.5f, 0f , 0f);

        for (int i = 0; i < shakeCount; i++)
        {
            while (this.transform.position.x < shakeDir.x)
            {
                this.transform.position += shakeDir * 0.3f;
                yield return null;
            }
            while (this.transform.position.x > -shakeDir.x)
            {
                this.transform.position -= shakeDir * 0.3f;
                yield return null;
            }
        }
        this.transform.position = defaultPos;
        shake = false;
    }
    
}
