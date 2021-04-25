using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_MiniGameManager : MiniGameManager
{
    [SerializeField]
    private Tutorial_MiniGame_UI tutorial_UI = null;

    [SerializeField]
    private int nowIndex = 0;
    [SerializeField]
    private bool throwMozi = true;
    [SerializeField]
    private bool explain = false;

    [SerializeField]
    private KnifeCtrl knifeCtrl = null;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    base.Start();
    //}

    // Update is called once per frame
    void Update()
    {
        if (start && !explain)
        {
            explain = true;
            StartCoroutine(explainItem());
        }
    }

    public new GameObject throwItem()
    {
        itemWaitTime -= Time.deltaTime;

        if (itemWaitTime < 0f)
        {
            int startIndex = Random.Range(0, startPos.Length); // 시작위치 설정

            // 던질 아이템 생성
            GameObject instance;
            if(throwMozi)
                instance = Instantiate(MoziPrefabs[nowIndex], startPos[1].transform);
            else
                instance = Instantiate(ItemPrefabs[nowIndex], startPos[1].transform);
            instance.transform.parent = Items.transform;
            instance.transform.localScale *= 1f; // objSize;

            itemWaitTime = Random.Range(1, 3);

            return instance;
        }
        return null;
    }

    // 모지, 아이템 설명
    IEnumerator explainItem()
    {
        GameObject item = throwItem();

        if (item != null)
        {
            //아이템 터치 못하게 막음
            knifeCtrl.enabled = false;

            yield return new WaitForSeconds(1f);

            Rigidbody2D a = item.GetComponent<Rigidbody2D>();
            a.constraints = RigidbodyConstraints2D.FreezeAll;

            tutorial_UI.showHighlight(item);

            yield return new WaitForSeconds(0.5f);

            //아이템 터치 가능하게
            knifeCtrl.enabled = true;

            while (item != null)
            {
                //사라질 때 까지 대기
                yield return new WaitForSeconds(0.5f);
            }

            tutorial_UI.hideHighlight();

            nowIndex++;
            explain = false;
            itemWaitTime = 0f;

            if (nowIndex > 3 && throwMozi)
            {
                // 모지 설명 끝, 아이템 설명 시작
                throwMozi = false;
                nowIndex = 0;
            }
            else if(nowIndex > 2 && !throwMozi)
            {
                // 모든 아이템 설명 끝, 실제 게임 시작
                SceneManager.LoadScene("miniGame");
            }
        }


    }
}
