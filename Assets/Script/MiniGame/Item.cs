using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : RemovableObj
{
    [SerializeField]
    private GameObject cutOffItem = null; // 처치 후 이미지

    [SerializeField]
    private int score = 1; // 점수
    

    public GameObject getCutOffItem()
    {
        return cutOffItem;
    }

    // 터치해서 처치
    public void tapItem()
    {
        if(removableType == RemovableType.TAP)
        {
            if(--tapCount <= 0)
            {
                cutItemAndAddScore();
                return;
            }

            // 튀어오르기
            Vector2 dir = Vector2.up * 2;
            dir += this.transform.position.x < 0 ? Vector2.right : Vector2.left; 

            rigid.AddForce(dir.normalized * Random.Range(400f, 600f));
        }
    }
    
    // 잘라서 처치
    public void sliceItem()
    {
        if (removableType == RemovableType.SLICE)
        {
            cutItemAndAddScore();
        }
    }

    private void cutItemAndAddScore()
    {
        //cut
        GameObject instance = Instantiate(cutOffItem, this.transform);
        instance.transform.parent = this.transform.parent.parent;
        Destroy(this.gameObject);

        //add score
        if (objType < ObjectType.MAX_MG)
        {
            MiniGameManager.Instance.addScore(score, objType);
        }
        //}else if(type < Item.ItemType.MAX_ITEM)
        //{
        //    MiniGameManager.Instance.addItem(score, type);
        //}
    }
}
