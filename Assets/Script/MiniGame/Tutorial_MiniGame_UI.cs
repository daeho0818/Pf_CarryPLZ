using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_MiniGame_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject highlight = null;
    [SerializeField]
    private Text highlightTxt = null;

    [SerializeField]
    private Camera cam = null;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void showHighlight(GameObject item)
    {
        highlight.transform.position = cam.WorldToScreenPoint(item.transform.position);
        highlightTxt.text = item.name;
        highlight.SetActive(true);
    }

    public void hideHighlight()
    {
        highlight.SetActive(false);
    }
}
