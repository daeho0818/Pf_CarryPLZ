using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAfterImg : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps = null;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (ps != null)
        {
            ParticleSystem.MainModule main = ps.main;
            if(main.startRotation.mode == ParticleSystemCurveMode.Constant)
            {
                main.startRotation = -transform.eulerAngles.z * Mathf.Deg2Rad;
            }
        }
    }
}
