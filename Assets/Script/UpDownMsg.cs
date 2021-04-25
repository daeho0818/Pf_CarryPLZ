using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDownMsg : MonoBehaviour
{
    public RectTransform messenger;
    bool isUp;
    void Update()
    {
        StartCoroutine("MessengerUpDown");
    }
    IEnumerator MessengerUpDown()
    {
        if (!isUp)
        {
            messenger.position = new Vector3(messenger.position.x, messenger.position.y + 0.3f * Time.deltaTime, messenger.position.z);
            yield return new WaitForSeconds(1);
            isUp = true;
        }
        else
        {
            messenger.position = new Vector3(messenger.position.x, messenger.position.y - 0.3f * Time.deltaTime, messenger.position.z);
            yield return new WaitForSeconds(1);
            isUp = false;
        }
    }
}
