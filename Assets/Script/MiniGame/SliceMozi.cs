using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceMozi : RemovableObj
{
    [SerializeField]
    private GameObject cutOffItem = null; // 처치 후 이미지

    [SerializeField]
    private int score = 1; // 점수

    public GameObject getCutOffItem()
    {
        return cutOffItem;
    }

    public override void remove(RemovableType tryRemoveType)
    {
        if (tryRemoveType == RemovableType.SLICE)
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
