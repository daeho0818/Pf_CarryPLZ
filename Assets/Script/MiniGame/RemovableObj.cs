using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovableObj : MonoBehaviour
{
    public enum ObjectType
    {
        REMOVABLE_OBJ=-1,
        BLUE_MG, // 모지
        YELLOW_MG,
        RED_MG,
        BOOM_MG,
        MAX_MG, 
        TIMER_ITEM, // 아이템
        SIZE_ITEM,
        MAX_ITEM, 
    };

    public enum RemovableType
    {
        SLICE,
        TAP,
    };

    [SerializeField]
    protected RemovableType removableType = RemovableType.SLICE; // 처치방법
    [SerializeField]
    protected ObjectType objType = ObjectType.REMOVABLE_OBJ; // 종류

    [SerializeField]
    protected Rigidbody2D rigid = null;

    [SerializeField]
    protected int tapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 dir = -Vector3.up;
        float power = 0f;

        dir.x = Random.Range(-5, 5);
        power = Random.Range(20, 40);
        rigid.AddForce(dir.normalized * power);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RemovableType GetCutType()
    {
        return removableType;
    }

    public ObjectType GetObjectType()
    {
        return objType;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deadline에 닿으면 삭제
        if (other.tag == "Finish")
        {
            if(objType != ObjectType.BOOM_MG)
                MiniGameManager.Instance.lossLife();
            Destroy(this.gameObject);
        }
    }

    public virtual void remove(RemovableType tryRemoveType)
    {
        Debug.Log("RemoveableObj");
    }
}
