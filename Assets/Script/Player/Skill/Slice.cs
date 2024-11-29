using System.Collections;
using UnityEngine;

public class Slice : MonoBehaviour, SkillInterface
{
    [SerializeField]
    private GameObject[] sliceObject = null;

    [SerializeField]
    private SkillData skillDB = null;

    private IEnumerator corutine = null;
    //활성화
    private void OnEnable()
    {
        corutine = CorutinePlay();
        StartCoroutine(corutine);
    }

    //비활성화
    private void OnDisable()
    {
        StopCoroutine(corutine);
        Debug.Log("비활성화");
        skillDB.ResetData();
    }

    private IEnumerator CorutinePlay()
    {
        while (true)
        {
            sliceObject[0].SetActive(true);
            sliceObject[1].SetActive(false);
            yield return new WaitForSeconds(0.2f);

            //스킬 랭크가 1 늘어나면 슬라이스 공격도 늘어남
            if (skillDB.Rank > 1)
            {
                sliceObject[0].SetActive(false);
                sliceObject[1].SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }

            sliceObject[0].SetActive(false);
            sliceObject[1].SetActive(false);

            //쿨타임
            Debug.Log(skillDB.Rank);
            yield return new WaitForSeconds(skillDB.RankDB[skillDB.Rank-1].skillCoolTime);
        }
    }

    //공격이 몬스터에게 닿으면 데미지
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerName.Monster)
        {
            Debug.Log("감지");
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void SkillReset()
    {
        StopCoroutine(corutine);

        sliceObject[0].SetActive(false);
        sliceObject[1].SetActive(false);

        //랭크 초기화
        skillDB.ResetData();
    }

    //랭크가 늘었났으면 베리어도 늘어나고 위치도 리셋
    public void PlusRank()
    {
        Debug.Log("플러스");

    }
}
