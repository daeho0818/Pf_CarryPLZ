using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOffItem : MonoBehaviour
{
    public float power = 3f;
    
    [SerializeField]
    private Rigidbody2D leftRigid = null;
    [SerializeField]
    private Rigidbody2D rightRigid = null;



    // Start is called before the first frame update
    void Start()
    {
        leftRigid.AddForce(new Vector2(-1f, 4f).normalized * power);
        rightRigid.AddForce(new Vector2(1f, 4f).normalized * power);

        StartCoroutine(TryFadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 2초 후 삭제
    IEnumerator TryFadeIn()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}
