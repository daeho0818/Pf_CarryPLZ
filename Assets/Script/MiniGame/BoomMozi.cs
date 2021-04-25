using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMozi : RemovableObj
{
    [SerializeField]
    private float time = -10f; // 삭제 될 시간 (초단위)

    public override void remove(RemovableType tryRemoveType)
    {
        MiniGameManager.Instance.getTimerItem(time);
        MiniGameManager.Instance.cameraShake();
        Destroy(this.gameObject);
    }
}
