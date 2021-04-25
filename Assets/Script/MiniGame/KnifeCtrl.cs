using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject knifeImg = null;

    private Vector3 mouse = Vector3.zero;

    private Ray ray = new Ray();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.Instance.isGameOver())
        {
            tryMoveMouse();
        }
    }

    private void tryMoveMouse()
    {
        //클릭
        if (Input.GetMouseButtonDown(0))
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = -1f;
            knifeImg.SetActive(true);
            tryCutItem(RemovableObj.RemovableType.TAP);
        }

        //드래그 중
        if (Input.GetMouseButton(0))
        {
            Vector3 newMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newMouse.z = -1f;
            knifeImg.transform.position = newMouse;
            if (Vector3.Distance(newMouse, mouse) > 0.1f)
            {
                tryCutItem(RemovableObj.RemovableType.SLICE);
            }
            mouse = newMouse;
        }

        //드래그 끝
        if (Input.GetMouseButtonUp(0))
        {
            knifeImg.SetActive(false);
        }
    }

    private void tryCutItem(RemovableObj.RemovableType tryRemoveType)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (!hit || hit.collider == null || hit.transform.tag != "Item")
        {
            return;
        }

        //Item targetItem = hit.transform.GetComponent<Item>();

        RemovableObj target = hit.transform.GetComponent<RemovableObj>();
        if (target == null)
        {
            return;
        }
        
        target.remove(tryRemoveType);
        
    }
}
