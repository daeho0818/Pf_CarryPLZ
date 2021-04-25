using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : RemovableObj
{
    [SerializeField]
    private float time = 10f; // 추가 될 시간 (초단위)

    public override void remove(RemovableType tryRemoveType)
    {
        if (tryRemoveType == RemovableType.TAP)
        {
            MiniGameManager.Instance.getTimerItem(time);
            Destroy(this.gameObject);
        }
    }
}
