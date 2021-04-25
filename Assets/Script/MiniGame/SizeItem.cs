using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeItem : RemovableObj
{
    [SerializeField]
    private float size = 1.5f; // 변경 할 사이즈
    [SerializeField]
    private float time = 10f; // 효과 유지 시간 (초단위)

    public override void remove(RemovableType tryRemoveType)
    {
        if (tryRemoveType == RemovableType.TAP)
        {
            MiniGameManager.Instance.getSizeItem(size, time);
            Destroy(this.gameObject);
        }
    }
}
